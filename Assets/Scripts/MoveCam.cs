using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.forward*Input.GetAxis("Mouse ScrollWheel"));

		if (Input.GetKey("w")){

			transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z+0.1f);
		}
		if (Input.GetKey("s")){
			
			transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z-0.1f);
		}

		if (Input.GetKey("a")){
			
			transform.position=new Vector3(transform.position.x-0.1f,transform.position.y,transform.position.z);
		}
		if (Input.GetKey("d")){
			
			transform.position=new Vector3(transform.position.x+0.1f,transform.position.y,transform.position.z);
		}
	
	}
}
