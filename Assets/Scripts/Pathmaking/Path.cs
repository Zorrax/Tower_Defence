using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path {

	public List<Vector3> points = new List<Vector3>();
	public List<int> connectedTo = new List<int>();
	public Junction junction;
	
}
