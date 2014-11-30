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
		Vector3 pos =new Vector3(StartPos.position.x, 0.5f, StartPos.position.z), direction, point;
		float angle,randnumb;
		// first points
		List<JunctionTier> junctiontier = new List<JunctionTier> ();

		int jindex = 0;
		junctiontier.Add (new JunctionTier ());
		junctiontier[jindex].Junction.Add(new Junction());
		junctiontier[jindex].Junction[0].Point = pos;

		junctiontier.Add (new JunctionTier());
		jindex++;
		for (int numJunc=0; numJunc<4; numJunc++) {
			junctiontier[jindex].Junction.Add(new Junction());
		 	angle =Random.Range(180,270); //(135, 315);
			direction = new Vector3 (Mathf.Cos (Mathf.Deg2Rad * angle), 0, Mathf.Sin (Mathf.Deg2Rad * angle));
			point=pos+direction*Random.Range(5,7);
			bool canbeplaced=true;
			foreach(Junction t in junctiontier[1].Junction){
				if(Vector3.Distance(point,t.Point)<3){
					canbeplaced=false;
				}
			}
			if(canbeplaced){
				junctiontier[1].Junction[numJunc].Point = point;
				Instantiate(cube,point,Quaternion.identity);
			}
			
		}

		for (int t=0; t<junctiontier[jindex].Junction.Count; t++){
			if(Vector3.Distance(junctiontier[jindex-1].Junction[0].Point,junctiontier[jindex].Junction[t].Point)<7){
				junctiontier[jindex-1].Junction[0].ConnectedTo.Add(t);
			}
		}

		int pathnumber = 0;
		float deltax, deltaz;

		foreach (Junction p in junctiontier[jindex-1].Junction){
			foreach(int c in p.ConnectedTo){
				if(Vector3.Distance(p.Point,junctiontier[jindex].Junction[c].Point)<8){
					Paths.Add (new Path ());
					deltax=(junctiontier[jindex].Junction[c].Point.x-p.Point.x)/20;
					deltaz=(junctiontier[jindex].Junction[c].Point.z-p.Point.z)/20;
					for (var i = 0; i<20; i++) {
						Paths[pathnumber].Points.Add(new Vector3(p.Point.x+deltax*i,0.5f,p.Point.z+deltaz*i));
						Instantiate(cube,Paths[pathnumber].Points[i],Quaternion.identity);
					}
					pathnumber++;
				}

			}
		}
		// generalization of above for the rest of the paths



	}

		// sin function


	
	// Update is called once per frame
	void Update () {
	
	}


	/*

	List<Vector3> parabola(Vector3 pos, Vector3 direction){
		float deltax, a;
		Vector3 endpos;
		endpos = pos + direction *Random.Range (5, 10);
		a = (pos.z - endpos.z) / Mathf.Pow ((pos.x - endpos.x), 2);
		deltax=(endpos.x-pos.x)/20;
		List<Vector3> points = new List<Vector3> ();
		for (var i = 0; i<20; i++) {
			points.Add(new Vector3(pos.x+deltax*i,0.5f,a*(Mathf.Pow((pos.x+deltax*i-endpos.x),2))+endpos.z));
			Instantiate(cube,points[i],Quaternion.identity);
		}
		return points;
	}*/

	/*List<Vector3> sine(Vector3 pos, Vector3 direction){
		float deltax, deltaz;
		Vector3 endpos;
		float Y, phi, frequency=0.2f;
		endpos = pos + direction *Random.Range (5, 10);
		Y = (Mathf.Sqrt (Mathf.Pow (pos.z, 2) + Mathf.Pow (endpos.z, 2) - 2f * pos.z * endpos.z * Mathf.Cos (frequency * (endpos.x - pos.x)))) / (Mathf.Sin (frequency * (endpos.x - pos.x)));
		phi=2*Mathf.PI-Mathf.Atan((endpos.z*Mathf.Sin(frequency*pos.x)-pos.z*Mathf.Sin(frequency*endpos.x))/(endpos.z*Mathf.Cos(frequency*pos.x)-pos.z*Mathf.Cos(frequency*endpos.x)));
		deltax=(endpos.x-pos.x)/20;
		deltaz=(endpos.z-pos.z)/20;
		List<Vector3> points = new List<Vector3> ();
		for (var i = 0; i<20; i++) {
			points.Add(new Vector3(pos.x+deltax*i,0.5f,pos.z+Y*Mathf.Sin(frequency*(deltax*i)*phi)));
			Instantiate(cube,points[i],Quaternion.identity);
		}
		return points;
	}*/

	/*

	List<Vector3> sine(Vector3 pos, Vector3 direction){
		float deltax, deltaz;
		float distance = 2;
		deltax=distance/16;
		deltaz=distance/16;
		List<Vector3> points = new List<Vector3> ();
		for (var i = 0; i<20; i++) {
			points.Add(new Vector3(pos.x-deltax*i-Mathf.Sin(i*0.25f),0.5f,pos.z-deltaz*i));
			Debug.Log (deltax*i+Mathf.Sin (i*0.25f));
			Instantiate(cube,points[i],Quaternion.identity);
		}
		return points;
	}*/

	
	/*List<Vector3> template = new List<Vector3> ();
		float d = 0.1f;

		------------------------
		-dx-dz	|-dx	|-dx+dz
		------------------------
		-dz		|player	|
		------------------------
		+dx-dz	|		|
		------------------------


	
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, 0));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, 0));
		template.Add (new Vector3 (-d, 0, 0));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (-d, 0, -d));
		template.Add (new Vector3 (0, 0, -d));
		template.Add (new Vector3 (0, 0, -d));



		int pathnumber = 0;
		Paths.Add (new Path ());
		Paths [pathnumber].Index = pathnumber;
		for (int point=0; point<template.Count-1; point++) {
			pos=pos+template[point];
			Paths [pathnumber].Points.Add(pos);
			Instantiate(cube,pos,Quaternion.identity);
		}
		pathnumber++;
		Paths.Add (new Path ());
		Paths [pathnumber].Index = pathnumber;
		for (int point=0; point<template.Count-1; point++) {
			pos=pos+template[point];
			Paths [pathnumber].Points.Add(pos);
			Instantiate(cube,pos,Quaternion.identity);
		}

		*/


}
