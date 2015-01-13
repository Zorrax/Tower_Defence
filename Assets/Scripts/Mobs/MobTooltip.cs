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
        physicalResistance.fillAmount = mob.GetComponent<Healthbar>().me.physicalResistance/100f;
        if (mob.GetComponent<Healthbar>().me.resistance1<100f)
        {
            resistance1.fillAmount = mob.GetComponent<Healthbar>().me.resistance1 / 435f;
        }
        else
        {
            resistance1.fillAmount = 100f / 435f;
            resistance1.GetComponent<Image>().color = new Color(0,0,0);
        }

        if (mob.GetComponent<Healthbar>().me.resistance2 < 100f)
        {
            resistance1.fillAmount = mob.GetComponent<Healthbar>().me.resistance2 / 435f;
        }
        else
        {
            resistance2.fillAmount = 100f / 435f;
            resistance2.GetComponent<Image>().color = new Color(0, 0, 0);
        }

        if (mob.GetComponent<Healthbar>().me.resistance3 < 100f)
        {
            resistance1.fillAmount = mob.GetComponent<Healthbar>().me.resistance3 / 435f;
        }
        else
        {
            resistance3.fillAmount = 100f / 435f;
            resistance3.GetComponent<Image>().color = new Color(0, 0, 0);
        }

        if (mob.GetComponent<Healthbar>().me.resistance4 < 100f)
        {
            resistance1.fillAmount = mob.GetComponent<Healthbar>().me.resistance4 / 435f;
        }
        else
        {
            resistance4.fillAmount = 100f / 435f;
            resistance4.GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }

}
