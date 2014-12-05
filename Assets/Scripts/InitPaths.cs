using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitPaths : MonoBehaviour {
	public GameObject cube;
	public List<Path> Paths = new List<Path>();
	public Transform StartPos;
	public int Seed;

	private GameObject placeholder;

	// Use this for initialization
	void Start () { // 3 forskellige start paths
		Random.seed = Seed;
		Vector3 pos = new Vector3 (StartPos.position.x, 0.5f, StartPos.position.z), direction, point;
		float angle, randnumb, Bx, Bz, T;
		// first points
		List<JunctionTier> junctiontier = new List<JunctionTier> ();

		int jtier = 0;
		int jindex;
		junctiontier.Add (new JunctionTier ());
		junctiontier [jtier].Junction.Add (new Junction ());
		junctiontier [jtier].Junction [0].Point = pos;
		int pathnumber = 0;
		float deltax, deltaz; // det er lige før man selv skal lave de 3 første paths

		for (int q =0; q<3; q++) {
			junctiontier.Add (new JunctionTier ());
			jtier++;
			jindex = 0;
			foreach (Junction r in junctiontier[jtier-1].Junction) {
				for (int numJunc=0; numJunc<3+jtier; numJunc++) {
					angle = Random.Range (180f, 270f); //(135, 315) something odd here with wide angles;
					direction = new Vector3 (Mathf.Cos (Mathf.Deg2Rad * angle), 0, Mathf.Sin (Mathf.Deg2Rad * angle));
					point = r.Point + direction * Random.Range (5f, 7f);
					bool canbeplaced = true;
					if (point.x > 8 || point.z > 8) { // farlig men skulle holde dem inde
						canbeplaced = false;
					}
					foreach (Junction f in junctiontier[jtier-1].Junction) {
						if (Vector3.Distance (point, f.Point) < 5) {
							canbeplaced = false;
						}
					}
					foreach (Junction t in junctiontier[jtier].Junction) {
						if (Vector3.Distance (point, t.Point) < 3) {
							canbeplaced = false;
						}
					}
					if (canbeplaced) {
						junctiontier [jtier].Junction.Add (new Junction ());
						junctiontier [jtier].Junction [jindex].Point = point;
						junctiontier [jtier].Junction [jindex].Index = jindex;
						Instantiate (cube, point, Quaternion.identity);
						jindex++;
						}
					}

					foreach (Junction b in junctiontier[jtier].Junction) {
						if (Vector3.Distance (r.Point, b.Point) < 7) { // should just be max value of random range line 37
							Paths.Add (new Path ());
							List<Vector3> juncs = new List<Vector3> ();
							juncs.Clear ();
							juncs.Add (r.Point);
							for (int k=0; k<3; k++) {
								juncs.Add (new Vector3 (r.Point.x - Random.Range (0 + (k*0.5f + 1), 2 * (k*0.5f + 1)), 0.5f, r.Point.z - Random.Range (0 + (k*0.5f + 1), 2 * (k*0.5f + 1))));
							}
							juncs.Add (b.Point);
							float n = juncs.Count - 1;
							for (int u = 0; u<20; u++) {
								T = u / 20f;
								Bx = 0; 
								Bz = 0;
								for (int i=0; i<n+1; i++) {
									float h = i;
									Bx = Bx + (Factorial (n) / (Factorial (h) * Factorial (n - h))) * Mathf.Pow ((1 - T), (n - h)) * Mathf.Pow (T, h) * juncs [i].x;
									Bz = Bz + (Factorial (n) / (Factorial (h) * Factorial (n - h))) * Mathf.Pow ((1 - T), (n - h)) * Mathf.Pow (T, h) * juncs [i].z;
								}
								Paths [pathnumber].Points.Add (new Vector3 (Bx, 0.5f, Bz));
								Instantiate (cube, Paths [pathnumber].Points [u], Quaternion.identity);
							}
							Paths [pathnumber].Junction = b;
							foreach (Path m in Paths) {
								if (m.Junction == r) {
									m.ConnectedTo.Add (pathnumber);
								}
							} 
							pathnumber++;
						}
					}
				}
			}
		}

	float Factorial(float number){
		if (number == 0) {
			return 1;
		}
		return number*Factorial(number-1);
	}



	// Update is called once per frame
	void Update () {

	}
	
}
