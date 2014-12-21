using UnityEngine;
using System.Collections;

public class Healthbar : MonoBehaviour {

	public float maxHealth = 100;
	public float curHealth = 100f;
	private float PhysicalResistance=10;
	private float FireResistance=5;
	
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {
		healthBarLength = (Screen.width / 25) * (curHealth / maxHealth);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI()
	{
		
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		
		GUI.Box(new Rect(targetPos.x - 20, Screen.height- targetPos.y - 20, healthBarLength, 5), curHealth + "/" + maxHealth);
		
	}
	
	public void AddjustCurrentHealth(DamageClass Damage) {

		curHealth -= (Damage.Fire-FireResistance);
		curHealth -= (Damage.Physical-PhysicalResistance);

		FireResistance -= Damage.FirePen;
		PhysicalResistance -= Damage.PhysicalPen;
		
		if (curHealth < 0)
			curHealth = 0;
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 25) * (curHealth / maxHealth);
	}

}
