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
        

        int stesti = Random.Range(1, 26);
        if (stesti < 25)
        {
            zivoty = Random.Range(50, 200);
            lvl = 1;
            UO_stats = new int[4];

            for (int i = 0; i < UO_stats.Length - 1; i++)
            {
                UO_stats[i] = Random.Range(10, 50);
            }

        }
        else if (stesti == 25)
        {
            zivoty = Random.Range(10, 1000);
            lvl = Random.Range(1, 5);
            UO_stats = new int[4];

            for (int i = 0; i < UO_stats.Length -1; i++)
            {
                UO_stats[i] = Random.Range(1, 250);
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
        MesecSys.MesecPridej(-cena);
        karta.UlozMe();
        karta.gameObject.SetActive(false);
    }
}
