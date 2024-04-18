using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoupitKartu : MonoBehaviour
{
    public GameObject EventKamarad;
    public VytvorKartuTed VKT;
    public GameObject MesecObj;
    public Mesec_System MesecSys;
    public KartaVybINF UlKarta;

    public int tag_kup;
    public int penize;
     void Start()
    {
        EventKamarad = GameObject.Find("EventKamarad");
        VKT = EventKamarad.GetComponent<VytvorKartuTed>();
        MesecObj = GameObject.Find("Mesec_objekt");
        MesecSys = MesecObj.GetComponent<Mesec_System>();
    }
    public void KartaKup(GameObject button)
    {
        
        string tag = button.tag;
        int.TryParse(tag, out tag_kup);
        penize = VKT.cenaKarty_koupit[tag_kup];
        if(MesecSys.mnozstviMeny >= penize && VKT.Hratelne[tag_kup].karta.activeSelf == true)
        {
            MesecSys.MesecPridej(-penize);
            VKT.Hratelne[tag_kup].karta.SetActive(false);
            VKT.Hratelne[tag_kup].UlozMe();
            button.SetActive(false);
        }
        else { Debug.Log("nechi prachyn"); }
        
    }

    
}
