using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MobTooltip : MonoBehaviour
{
    public GameObject mob;
    public Image healtBar;
    public Image physicalResistance;
    
   

    void Update()
    {
        healtBar.fillAmount = mob.GetComponent<Healthbar>().healthBarLength;
        physicalResistance.fillAmount = mob.GetComponent<Healthbar>().me.PhysicalResistance;
    }

}
