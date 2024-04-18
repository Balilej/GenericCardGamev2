using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VytvorBojovnika : MonoBehaviour
{

    public KartaINF karta;
    public KartaVybavaData KVD;

    public Mesec_System MesecSys;

    public TextMeshProUGUI Btn_Kt;
    public Button Btn_K;

    public int zivoty;
    public int lvl;
    public int[] UO_stats;

    public System.Func<float> OnZiskejHracMult;
    public float multhrac = 1;

    //public float multhrac = 4;
    public int cena;
    private void Start()
    {
        Btn_K.interactable = false;
        KVD = GetComponent<KartaVybavaData>();
        MesecSys = GameObject.Find("Mesec_objekt").GetComponent<Mesec_System>();
        // NactiKartu();
       
    }
   
    public void NactiKartu()
    {
         multhrac = OnZiskejHracMult.Invoke();
     
        // float multhrac = OnZiskejHracMult.Invoke();
        Debug.Log(multhrac);
        
        int stesti = Random.Range(1, 26);
        if (stesti < 25)
        {
            zivoty = (int)(Random.Range(50, 200) * multhrac);
            lvl = (int)(1+multhrac);
            UO_stats = new int[4];

            for (int i = 0; i < UO_stats.Length - 1; i++)
            {
                UO_stats[i] = (int)(Random.Range(10, 50)*multhrac);
            }

        }
        else if (stesti == 25)
        {
            zivoty = (int)(Random.Range(10, 1000) * multhrac);
            lvl = (int)(Random.Range(1, 5)+multhrac);
            UO_stats = new int[4];

            for (int i = 0; i < UO_stats.Length -1; i++)
            {
                UO_stats[i] = (int)(Random.Range(1, 250)*multhrac);
            }
        }

        

        Debug.Log(KVD.dataJmenaKaret.Length);
        int randjmena = Random.Range(1, KVD.dataJmenaKaret.Length);
        
        string jmeno = KVD.dataJmenaKaret[randjmena];

        karta.NapisStaty(zivoty, UO_stats[0], UO_stats[1], UO_stats[2], UO_stats[3], lvl, 0, 0, 0, 0, 999, 999, jmeno );

        cena = 100 + (int)((zivoty + UO_stats[0] + UO_stats[1] + UO_stats[2] + UO_stats[3])/lvl)*5;
        Btn_Kt.text = "€" + cena.ToString();
        Btn_K.interactable = true;
    }

    public void KoupitKartu()
    {
        if(cena <= MesecSys.mnozstviMeny && karta.gameObject.activeSelf == true)
        {
            MesecSys.MesecPridej(-cena);
            karta.UlozMe();
            karta.gameObject.SetActive(false);
        }
        if(cena > MesecSys.mnozstviMeny)
        {
            Btn_Kt.text = "Insufficient funds";
        }
        
    }
}
