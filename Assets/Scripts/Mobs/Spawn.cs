﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour
{

    public Transform StartPos;
    public GameObject MobWave;


    private GameObject curmobwave;
    private float InstantiationTimer = 1f;
    private GameObject CurrentPath;
    private State state;
    private List<Path> Paths = new List<Path>();
    private List<Vector3> waypoints = new List<Vector3>();
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
                List<Vector3> points = new List<Vector3>(waypoints);
                MobType mobtype = new MobType();
                mobtype.Health = 100f + Mathf.Pow(state.SpawnCounter, 1.5f);
                mobtype.PhysicalResistance = 5f + Random.Range(0f, (state.SpawnCounter / 100f) * 95f);
                mobtype.FireResistance = 5f + Random.Range(0f, (state.SpawnCounter / 100f) * 95f);

                state.SpawnCounter++;

                curmobwave = Instantiate(MobWave, StartPos.position, Quaternion.identity) as GameObject;
                curmobwave.GetComponent<Healthbar>().SetType(mobtype);
                curmobwave.GetComponent<Mover>().SetWaypoints(points);


                InstantiationTimer = 3f;


                waypoints.Clear();


            }
        }
    }
}
