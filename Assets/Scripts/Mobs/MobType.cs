using UnityEngine;
using System.Collections;

public class MobType  {

	public float health;
	public float physicalResistance;
	public float resistance1;
    public float resistance2;
    public float resistance3;
    public float resistance4;
    public int value;
    public float size;

	public MobType(){

	}
	public MobType(MobType type){
		health = type.health;
		physicalResistance = type.physicalResistance;
		resistance1 = type.resistance1;
        resistance2 = type.resistance2;
        resistance3 = type.resistance3;
        resistance4 = type.resistance4;
        value = type.value;
	}
}
