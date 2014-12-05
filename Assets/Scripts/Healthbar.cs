using UnityEngine;
using System.Collections;

public class Healthbar : MonoBehaviour {

	public int maxHealth = 100;
	public float curHealth = 100F;
	
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);   
	}
	
	void OnGUI()
	{
		
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		
		GUI.Box(new Rect(targetPos.x - 20, Screen.height- targetPos.y - 20, healthBarLength, 5), curHealth + "/" + maxHealth);
		
	}
	
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;
		
		if (curHealth < 0)
			curHealth = 0;
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 25) * (curHealth / maxHealth);
	}

}
