using UnityEngine;
using System.Collections;

public class MobType  {

	public float Health;
	public float PhysicalResistance;
	public float FireResistance;

	public MobType(){

	}
	public MobType(MobType type){
		Health = type.Health;
		PhysicalResistance = type.PhysicalResistance;
		FireResistance = type.FireResistance;
	}
}
