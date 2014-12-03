using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	public Transform StartPos;
	public GameObject Mob;

	private float InstantiationTimer = 3f;
	private float GroupInstantiationTimer = 0.7f;
	private int mobsperwave=5;
	private bool pathnotset=true;
	private GameObject curmob;
	private GameObject CurrentPath;
	private List<Path> Paths = new List<Path>();
	private List<Vector3> waypoints = new List<Vector3>();
	float randnumb;

	// Use this for initialization
	void Start () {
		CurrentPath = GameObject.Find ("PathMaker");
		Paths = CurrentPath.GetComponent<InitPaths>().Paths; // reference
	}
	
	// Update is called once per frame
	void Update () {
		spawnmob ();
	
	}

	void spawnmob(){

		InstantiationTimer -= Time.deltaTime;
		GroupInstantiationTimer -= Time.deltaTime;

		if (InstantiationTimer <= 0){

			if(pathnotset){

				randnumb = Random.value;
				List<int> mobpaths = new List<int>();
				int index = 0;
				if(randnumb<0.5){
					mobpaths.Add (0);
				}else{
					mobpaths.Add (1);
				}
				bool morepaths = true;
				bool moreconnections = true;
				while (morepaths) {
					moreconnections=true;
					while(moreconnections){
						foreach( int t in Paths[mobpaths[index]].ConnectedTo){
							randnumb=Random.value;
							if(randnumb<0.3){
								mobpaths.Add(t);
								index++;
								moreconnections=false; // problem here
								break;
							}
						}
					}
					if(index>1){
						morepaths=false;
					}
				}
				foreach ( int y in mobpaths ){
					for (int i =0; i < Paths[y].Points.Count-1 ; i++){
						waypoints.Add(Paths[y].Points[i]);
					}
				}
				pathnotset=false;
			}

			if(mobsperwave>0 && GroupInstantiationTimer <= 0){
				Vector3 pos= new Vector3(StartPos.position.x,StartPos.position.y,StartPos.position.z);
				curmob = Instantiate (Mob, pos, Quaternion.identity) as GameObject;
				curmob.GetComponent<Mover>().waypoints = new List<Vector3>(waypoints);
				GroupInstantiationTimer = 0.7f;
				mobsperwave--;
			}
			if(mobsperwave == 0){
				InstantiationTimer = 3f;
				mobsperwave=5;
				pathnotset=true;
				waypoints.Clear();

			}

		}


	}
}
