using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MobTooltip : MonoBehaviour
{
    public GameObject mob;
    public Image healtBar;
    public Image physicalResistance;
    public Image resistance1;
    public Image resistance2;
    public Image resistance3;
    public Image resistance4;
    
   

    void Update()
    {
        healtBar.fillAmount = mob.GetComponent<Healthbar>().healthBarLength;
        physicalResistance.fillAmount = mob.GetComponent<Healthbar>().me.PhysicalResistance/100f;
        resistance1.fillAmount = mob.GetComponent<Healthbar>().me.resistance1 / 435f;
        resistance2.fillAmount = mob.GetComponent<Healthbar>().me.resistance2 / 435f;
        resistance3.fillAmount = mob.GetComponent<Healthbar>().me.resistance3 / 435f;
        resistance4.fillAmount = mob.GetComponent<Healthbar>().me.resistance4 / 435f;
    }

}
