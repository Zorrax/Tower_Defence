using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public float StartHealth;
    public MobType me;
    public float healthBarLength;

    public void SetType(MobType type)
    {
        me = new MobType(type);
        StartHealth = me.health;
        healthBarLength = (me.health / StartHealth);
    }


    public void AddjustCurrentHealth(DamageClass Damage)
    {

        me.health -= Damage.Physical * (1f - me.physicalResistance / 100f);
        me.health -= Damage.type1 * (1f - me.physicalResistance / 100f) * (1f - me.resistance1 / 100f);
        me.health -= Damage.type2 * (1f - me.physicalResistance / 100f) * (1f - me.resistance2 / 100f);
        me.health -= Damage.type3 * (1f - me.physicalResistance / 100f) * (1f - me.resistance3 / 100f);
        me.health -= Damage.type4 * (1f - me.physicalResistance / 100f) * (1f - me.resistance4 / 100f);
       

        if (me.health > 0)
        {
            me.resistance1 -= Damage.type1Pen;
            me.resistance2 -= Damage.type2Pen;
            me.resistance3 -= Damage.type3Pen;
            me.resistance4 -= Damage.type4Pen;
            me.physicalResistance -= Damage.PhysicalPen;

        }
        else
        {
            me.resistance1 = 0;
            me.resistance2 = 0;
            me.resistance3 = 0;
            me.resistance4 = 0;
            me.physicalResistance = 0;
            me.health = 0;

        }

        if (me.health > StartHealth)
            me.health = StartHealth;

        if (StartHealth < 1)
            StartHealth = 1;

        healthBarLength = (me.health / StartHealth);
    }

}
