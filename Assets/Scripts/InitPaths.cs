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
		Vector3 pos =new Vector3(StartPos.position.x, 0.5f, StartPos.position.z), direction, point;
		float angle,randnumb;
		// first points
		List<JunctionTier> junctiontier = new List<JunctionTier> ();

		int jtier = 0;
		int jindex;
		junctiontier.Add (new JunctionTier ());
		junctiontier[jtier].Junction.Add(new Junction());
		junctiontier[jtier].Junction[0].Point = pos;
		int pathnumber = 0;
		float deltax, deltaz;

		for (int q =0; q<3; q++) {
			junctiontier.Add (new JunctionTier ());
			jtier++;
			jindex = 0;
			foreach (Junction r in junctiontier[jtier-1].Junction) {
				for (int numJunc=0; numJunc<4; numJunc++) {
					angle = Random.Range (180, 270); //(135, 315);
					direction = new Vector3 (Mathf.Cos (Mathf.Deg2Rad * angle), 0, Mathf.Sin (Mathf.Deg2Rad * angle));
					point = r.Point + direction * Random.Range (5, 7);
					bool canbeplaced = true;
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
	
				foreach (Junction a in junctiontier[jtier-1].Junction) {
					foreach (Junction b in junctiontier[jtier].Junction) {
						if (Vector3.Distance (a.Point, b.Point) < 7) {
							a.ConnectedTo.Add (b.Index);
						}
					}
				}
				foreach (Junction p in junctiontier[jtier-1].Junction) {
					foreach (int c in p.ConnectedTo) {
						Junction v = junctiontier [jtier].Junction [c];
						if (Vector3.Distance (p.Point, v.Point) < 8) {
							Paths.Add (new Path ());
							deltax = (v.Point.x - p.Point.x) / 20;
							deltaz = (v.Point.z - p.Point.z) / 20;
							for (var i = 0; i<20; i++) {
								Paths [pathnumber].Points.Add (new Vector3 (p.Point.x + deltax * i, 0.5f, p.Point.z + deltaz * i));
								Instantiate (cube, Paths [pathnumber].Points [i], Quaternion.identity);
							}
							Paths [pathnumber].Junction= v;
							foreach(Path m in Paths ){
								if(m.Junction==p){
									m.ConnectedTo.Add(pathnumber);
								}
							}
							pathnumber++;
						}
					}
				}
			}
		}
	}



	// Update is called once per frame
	void Update () {

	}
	
}
