using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitPaths : MonoBehaviour {
	public GameObject cube;
	public List<Path> Paths = new List<Path>();
	public Transform StartPos;
	public Transform EndPos;
	public int Seed;

	private GameObject placeholder;




	// Use this for initialization
	void Start () { // 3 forskellige start paths
		Random.seed = Seed;
		float x = StartPos.position.x;
		float y = 0.5f;
		float z = StartPos.position.z;
		float angle;
		Vector3 pos =new Vector3(x, y, z);
		Vector3 direction;
		Vector3 endpos;
		endpos = pos;
		float randnumb;

		for (int pathnumber=0; pathnumber<4; pathnumber++) {
			Paths.Add (new Path ());
			Paths [pathnumber].Index = pathnumber;
			pos = endpos; // udgangspunkt
			angle =250;// Random.Range(180,270); //(135, 315);
			direction = new Vector3 (Mathf.Cos (Mathf.Deg2Rad * angle), 0, Mathf.Sin (Mathf.Deg2Rad * angle));
			endpos = pos + direction *5; //Random.Range (5, 10);
			randnumb=Random.value;
			if(randnumb>0.5f){
				Paths [pathnumber].Points = parabola (pos, endpos);
			}else{
				Paths [pathnumber].Points = sine (pos, endpos);
			}
		}

	}
		// sin function


	
	// Update is called once per frame
	void Update () {
	
	}


	List<Vector3> parabola(Vector3 pos, Vector3 endpos){
		float deltax, a;
		a = (pos.z - endpos.z) / Mathf.Pow ((pos.x - endpos.x), 2);
		deltax=(endpos.x-pos.x)/20;
		List<Vector3> points = new List<Vector3> ();
		for (var i = 0; i<20; i++) {
			points.Add(new Vector3(pos.x+deltax*i,0.5f,a*(Mathf.Pow((pos.x+deltax*i-endpos.x),2))+endpos.z));
		}
		return points;
	}


	List<Vector3> sine(Vector3 pos, Vector3 endpos){
		float deltax, deltaz;
		deltax=(endpos.x-pos.x)/20;
		deltaz=(endpos.z-pos.z)/20;
		List<Vector3> points = new List<Vector3> ();
		for (var i = 0; i<20; i++) {
			points.Add(new Vector3(pos.x+deltax*i+Mathf.Cos(Mathf.Deg2Rad*i*40),0.5f,pos.z-deltaz*i));
		}
		return points;
	}


}
