using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public float StartHealth;
    public MobType me;

    public float healthBarLength;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetType(MobType type)
    {
        me = new MobType(type);
        StartHealth = me.Health;
        healthBarLength = (me.Health / StartHealth);
    }


    public void AddjustCurrentHealth(DamageClass Damage)
    {

        me.Health -= Damage.Fire * (1f - me.resistance1 / 100f);
        me.Health -= Damage.Physical * (1f - me.PhysicalResistance / 100f);

        if (me.Health > 0)
        {
            me.resistance1 -= Damage.FirePen;
            me.PhysicalResistance -= Damage.PhysicalPen;

        }
        else
        {
            me.resistance1 = 0;
            me.resistance2 = 0;
            me.resistance3 = 0;
            me.resistance4 = 0;
            me.PhysicalResistance = 0;
            me.Health = 0;

        }

        if (me.Health > StartHealth)
            me.Health = StartHealth;

        if (StartHealth < 1)
            StartHealth = 1;

        healthBarLength = (me.Health / StartHealth);
    }

}
