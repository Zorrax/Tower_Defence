﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	public float StartHealth;
	public MobType me;

	public float healthBarLength;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	public void SetType(MobType type){
		me = new MobType (type);
		StartHealth = me.Health;
		healthBarLength =  (me.Health / StartHealth);
	}

	
	public void AddjustCurrentHealth(DamageClass Damage) {


		me.Health -= (Damage.Fire*(1-(me.FireResistance/100f)));
		me.Health -= (Damage.Physical-(1-(me.PhysicalResistance/100f)));

		me.FireResistance -= Damage.FirePen;
		me.PhysicalResistance -= Damage.PhysicalPen;
		
		if (me.Health < 0)
			me.Health = 0;
		
		if (me.Health > StartHealth)
			me.Health = StartHealth;
		
		if(StartHealth < 1)
			StartHealth = 1;
		
		healthBarLength = (me.Health / StartHealth);
	}

}
