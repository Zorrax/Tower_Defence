using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updatebar : MonoBehaviour {

	public GameObject mob;
	
	// Update is called once per frame
	void Update () {
		if(mob!=null){
			gameObject.GetComponent<Image> ().fillAmount = mob.GetComponent<Healthbar> ().healthBarLength;
		}
	}
}
