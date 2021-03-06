﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{

    public float fireRate = 0.5f;
    private float firetime = 0.5f;
    public int baseDamage = 20;
    public List<GameObject> mobList = new List<GameObject>();
    public List<GameObject> AugList = new List<GameObject>();
    private DamageClass Damage = new DamageClass();

    void Start()
    {
        for (int a = 0; a < 5; a++)
        {
            AugList.Add(null);
        }
    }



    private bool fireAtGameObject(GameObject target)
    {
        bool destroyGameObject = false;


        target.GetComponent<Healthbar>().AddjustCurrentHealth(Damage);
        if (target.GetComponent<Healthbar>().me.health <= 0f)
        {
            destroyGameObject = true;
        }

        return destroyGameObject;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Aug")
        {
            return;
        }

        GameObject theObject = other.attachedRigidbody.gameObject;

        if (!mobList.Contains(theObject))
        {
            mobList.Add(theObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject theObject = other.attachedRigidbody.gameObject;

        if (mobList.Contains(theObject))
        {
            mobList.Remove(theObject);
        }
    }

    private void UpdateDamage()
    {
        Damage.Reset();
        Damage.Physical = baseDamage;
        foreach (GameObject beef in AugList)
        { // update damage based on the augumentations
            if (beef)
            {
                Aug me = beef.GetComponent("Aug") as Aug;
                if (me.type == "damage")
                {
                    Damage.Physical = Damage.Physical + 20 * me.level;
                }
                if (me.type == "fire") // && andre typer der der passer ind på type 1
                {
                    Damage.type1 = Damage.type1 + 20 * me.level; // håndtere special chance og penetration også
                }

            }
        }
    }

    private void doFireSequence()
    {
        firetime -= Time.deltaTime;
        if (firetime <= 0)
        {
            UpdateDamage();

            if (mobList.Count > 0)
            {
                // check if you hit it
                int savedSeed = Random.seed;
                Random.seed = (int)Time.time;
                if (Random.value > 0.2)
                {
                    if (fireAtGameObject(mobList[0]))
                    {
                        Destroy(mobList[0]);
                        mobList.RemoveAt(0);
                    }
                }
                Random.seed = savedSeed;
            }
            firetime = fireRate;
        }
    }
    void Update()
    {
        if (GameObject.Find("GameState").GetComponent<State>().Running)
        {
            foreach (GameObject Mob in mobList)
            {
                if (Mob == null)
                {
                    mobList.Remove(Mob);
                    break;
                }
            }
            doFireSequence();

        }
    }
}
