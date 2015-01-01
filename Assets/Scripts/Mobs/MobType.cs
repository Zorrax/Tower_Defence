using UnityEngine;
using System.Collections;

public class MobType  {

	public float Health;
	public float PhysicalResistance;
	public float resistance1;
    public float resistance2;
    public float resistance3;
    public float resistance4;

	public MobType(){

	}
	public MobType(MobType type){
		Health = type.Health;
		PhysicalResistance = type.PhysicalResistance;
		resistance1 = type.resistance1;
        resistance2 = type.resistance2;
        resistance3 = type.resistance3;
        resistance4 = type.resistance4;
	}
}
