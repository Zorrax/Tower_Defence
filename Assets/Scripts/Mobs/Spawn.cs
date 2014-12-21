using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	public Transform StartPos;
	public GameObject Mob;

	private float InstantiationTimer = 6f;
	private float GroupInstantiationTimer = 1.4f;
	private int mobsperwave=5;
	private bool pathnotset=true;
	private GameObject curmob;
	private GameObject CurrentPath;
	private State state;
	private List<Path> Paths = new List<Path>();
	private List<Vector3> waypoints = new List<Vector3>();
	float randnumb;

	// Use this for initialization
	void Start () {
		CurrentPath = GameObject.Find ("PathMaker");
		Paths = CurrentPath.GetComponent<InitPaths>().Paths; // reference
		state = GameObject.Find ("GameState").GetComponent<State>();
	}
	
	// Update is called once per frame
	void Update () {
		spawnmob ();
	}

	void spawnmob(){
		if (GameObject.Find ("GameState").GetComponent<State> ().Running) {
						InstantiationTimer -= Time.deltaTime;
						GroupInstantiationTimer -= Time.deltaTime;

						if (InstantiationTimer <= 0) {

								if (pathnotset) {

										randnumb = Random.value;
										List<int> mobpaths = new List<int> ();
										int index = 0;
										if (randnumb < 0.5) {
												mobpaths.Add (0);
										} else {
												mobpaths.Add (1);
										}
										bool morepaths = true;
										while (morepaths) {
												mobpaths.Add (Paths [mobpaths [index]].ConnectedTo [Random.Range (0, Paths [mobpaths [index]].ConnectedTo.Count)]);
												index++;
												if (index == 3) {//state.CurrentJunctionTier){
														morepaths = false;
												}
										}
										foreach (int y in mobpaths) {
												for (int i =0; i < Paths[y].Points.Count-1; i++) {
														waypoints.Add (Paths [y].Points [i]);
												}
										} // define the type of mob here 
										state.SpawnCounter++;
										pathnotset = false;
								}

								if (mobsperwave > 0 && GroupInstantiationTimer <= 0) {
										Vector3 pos = new Vector3 (StartPos.position.x, StartPos.position.y, StartPos.position.z);
										curmob = Instantiate (Mob, pos, Quaternion.identity) as GameObject;
										curmob.GetComponent<Mover> ().waypoints = new List<Vector3> (waypoints);
										curmob.GetComponent<Healthbar> ().curHealth =100+ Mathf.Pow (1.5f, state.SpawnCounter); // virker ikke helt // assign mob traits here 
										curmob.GetComponent<Healthbar> ().maxHealth=curmob.GetComponent<Healthbar> ().curHealth;
										curmob.GetComponent<Healthbar> ().AddjustCurrentHealth(new DamageClass() );
										GroupInstantiationTimer = 1.4f;
										mobsperwave--;
								}
								if (mobsperwave == 0) {
										InstantiationTimer = 6f;
										mobsperwave = 5;
										pathnotset = true;
										waypoints.Clear ();

								}

						}
				}

	}
}
