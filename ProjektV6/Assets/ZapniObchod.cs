using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapniObchod : MonoBehaviour
{
    public GameObject EventKamarat;
    public VytvorKartuTed vytvorKartu;
    // Start is called before the first frame update
    public void ZapniVytvorKartuTed()
    {
        EventKamarat = GameObject.Find("EventKamarad");
        vytvorKartu = EventKamarat.GetComponent<VytvorKartuTed>();
        vytvorKartu.VytvorKartus();
    }

}
