using UnityEngine;
using System.Collections;

public class Draganddrop : MonoBehaviour {
	
	private bool dragging = false;
	private float distance;
	
	
	void OnMouseEnter()
	{
	
	}
	
	void OnMouseExit()
	{

	}
	
	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}
	
	void OnMouseUp()
	{
		dragging = false;
	}
	
	void Update()
	{	
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = new Vector3(rayPoint.x,2,rayPoint.z);
		}
	}
}
