using UnityEngine;
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

        float fireDamage = Damage.Fire*(1f-me.FireResistance/100f);
        float physicalDamage = Damage.Physical * (1f - me.PhysicalResistance / 100f);

        float fireRatio = fireDamage / me.Health;
        float physicalRatio = physicalDamage / me.Health;


        me.Health -= fireDamage;
        me.Health -= physicalDamage;

		me.FireResistance -= Damage.FirePen-fireRatio*10;
		me.PhysicalResistance -= Damage.PhysicalPen-physicalRatio*10;
		
		if (me.Health < 0)
			me.Health = 0;
		
		if (me.Health > StartHealth)
			me.Health = StartHealth;
		
		if(StartHealth < 1)
			StartHealth = 1;
		
		healthBarLength = (me.Health / StartHealth);
	}

}
