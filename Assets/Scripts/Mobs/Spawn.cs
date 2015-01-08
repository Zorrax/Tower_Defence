using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour
{

    public Transform StartPos;
    public GameObject MobWave;


    private GameObject curmobwave;
    private float InstantiationTimer = 0f;
    private float groupInstantiationTimer = -2f;
    private GameObject CurrentPath;
    private State state;
    private List<Path> Paths = new List<Path>();

    private List<Vector3> waypoints = new List<Vector3>();
    private List<Vector3> points;
    private MobType mobtype;
    private float AP, APMob;
    private float mobsInWave;

    float randnumb;

    // Use this for initialization
    void Start()
    {
        CurrentPath = GameObject.Find("PathMaker");
        Paths = CurrentPath.GetComponent<InitPaths>().paths; // reference
        state = GameObject.Find("GameState").GetComponent<State>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnmobwave();
    }

    void spawnmobwave()
    {
        if (GameObject.Find("GameState").GetComponent<State>().Running)
        {
            InstantiationTimer -= Time.deltaTime;
            groupInstantiationTimer -= Time.deltaTime;

            if (InstantiationTimer <= 0)
            {
                List<int> mobpaths = new List<int>();
                int index = 0;
                mobpaths.Add(0);
                bool morepaths = true;
                while (morepaths)
                {
                    mobpaths.Add(Paths[mobpaths[index]].connectedTo[Random.Range(0, Paths[mobpaths[index]].connectedTo.Count)]);
                    index++;
                    if (index == 3)
                    {//state.CurrentJunctionTier){
                        morepaths = false;
                    }
                }
                foreach (int y in mobpaths)
                {
                    for (int i = 0; i < Paths[y].points.Count - 1; i++)
                    {
                        waypoints.Add(Paths[y].points[i]);
                    }
                } // define the type of mob here 
                points = new List<Vector3>(waypoints);
                waypoints.Clear();

                mobtype = new MobType();
                AP = Mathf.Pow(state.SpawnCounter+2, 1.5f);
                mobsInWave = Random.Range(4, 10);
                
                APMob = AP / mobsInWave;
                mobtype.Health = 100f + APMob * 20;
                mobtype.PhysicalResistance = 5f + Random.Range(0f, Mathf.Log10(APMob) * 20f);
                mobtype.resistance1 = 5f + Random.Range(0f, Mathf.Log10(APMob) * 20f);
                mobtype.resistance2 = 5f + Random.Range(0f, Mathf.Log10(APMob) * 20f);
                mobtype.resistance3 = 5f + Random.Range(0f, Mathf.Log10(APMob) * 20f); 
                mobtype.resistance4 = 5f + Random.Range(0f, Mathf.Log10(APMob) * 20f);

               

                float randnumb = Random.Range(1, 4);
                if (randnumb == 1)
                {
                    mobtype.resistance1 = mobtype.resistance1 + Random.Range(0f, Mathf.Log10(APMob) * 20f - mobtype.resistance1);
                }
                if (randnumb == 2)
                {
                    mobtype.resistance2 = mobtype.resistance2 + Random.Range(0f, Mathf.Log10(APMob) * 20f - mobtype.resistance2);
                }
                if (randnumb == 3)
                {
                    mobtype.resistance3 = mobtype.resistance3 + Random.Range(0f, Mathf.Log10(APMob) * 20f - mobtype.resistance3);
                }
                if (randnumb == 4)
                {
                    mobtype.resistance4 = mobtype.resistance4 + Random.Range(0f, Mathf.Log10(APMob) * 20f - mobtype.resistance4);
                }
                

                state.SpawnCounter++;

                InstantiationTimer = 2.1f * mobsInWave;
                groupInstantiationTimer = 4f;
            }

            if (groupInstantiationTimer <= 0)
            {
                curmobwave = Instantiate(MobWave, StartPos.position, Quaternion.identity) as GameObject;
                curmobwave.GetComponent<Healthbar>().SetType(mobtype);
                curmobwave.GetComponent<Mover>().SetWaypoints(points);

                groupInstantiationTimer = 2f;
            }
        }
    }
}
