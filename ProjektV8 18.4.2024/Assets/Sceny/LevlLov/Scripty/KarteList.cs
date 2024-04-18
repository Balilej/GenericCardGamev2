using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarteList : MonoBehaviour
{
    public static List<KartaINF> SelectKarte = new List<KartaINF>();
    public List<Button> btns = new List<Button>();

    public KartaVybavaData kartaVybavaData;
    public BojMainScript Bms;
    [SerializeField] KartaINF kartaINFPref;
    public List<KartaINF> karty = new List<KartaINF>();
    // public static List<LvlBojData> Enemy = new List<LvlBojData>();
    private void Start()
    {
        BtnsTF(false);
    }

    private void Update()
    {
        if (SelectKarte.Count == 8)
        {
            BtnsTF(true);

        }
        else { BtnsTF(false); }
    }
    public int getKarteListCount()
    {
        
        
        return SelectKarte.Count;
    }

    public void BtnsTF(bool btn)
    {
        for (int i = 0; i != btns.Count; i++)
        {
            btns[i].interactable = btn;
        }
    }

    Vector3 pozice = new Vector3(20, 30, 3);
    public void GetHraceKarte()
    {
        int max = SelectKarte.Count;
       
            

            for (int i = 0; i != max; i++)
            {
               

                Debug.Log("Krok2 " + -1);
                KartaINF kartaINF = Instantiate(kartaINFPref, pozice, Quaternion.identity);
                Debug.Log("Krok2 " + 0);
                karty.Add(kartaINF);

                KartaINF kartaInfToEdit = karty[i];
                Debug.Log("Krok2 " + 1);
                kartaInfToEdit.NapisStaty(SelectKarte[i].startZivoty, SelectKarte[i].utok, SelectKarte[i].vykriti, SelectKarte[i].obrana, SelectKarte[i].obranaPosk, SelectKarte[i].level,
                        SelectKarte[i].MR_OB_Tree1, SelectKarte[i].MR_OB_Tree2, SelectKarte[i].VR_OB_Tree1, SelectKarte[i].VR_OB_Tree2, SelectKarte[i].AR_OB_Tree1, SelectKarte[i].HL_OB_Tree1, SelectKarte[i].jmenoKarty);

                Debug.Log("Krok2 " + 2);
                Debug.Log(SelectKarte[i].MR_OB_Tree1);
                Debug.Log(SelectKarte[i].MR_OB_Tree2);
                switch (SelectKarte[i].MR_OB_Tree1)
                {
                    case 0:
                        kartaInfToEdit.trida = "Pesti";
                        kartaInfToEdit.zbran = "pest";
                        break;
                    case 1:
                        Debug.Log("Krok2 " + 2.1);
                        kartaInfToEdit.trida = "Jednorucka";
                        kartaInfToEdit.zbran = "dagger_j";
                        Debug.Log("Krok2 " + 2.2);
                        kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_dyka[SelectKarte[i].MR_OB_Tree2];
                        Debug.Log("Krok2 " + 2.3);
                        break;
                    case 2:
                        kartaInfToEdit.trida = "Jednorucka";
                        kartaInfToEdit.zbran = "mec_j";
                        kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_mec[SelectKarte[i].MR_OB_Tree2];

                        break;
                    case 3:
                        kartaInfToEdit.trida = "Jednorucka";
                        kartaInfToEdit.zbran = "sekPal_j";
                        kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_SekPal[SelectKarte[i].MR_OB_Tree2];
                        break;

                }
                Debug.Log("Krok2 " + 3);
                switch (SelectKarte[i].VR_OB_Tree1)
                {
                    case 5:
                        kartaInfToEdit.trida2 = "Luk";
                        kartaInfToEdit.zbran2 = "luk_l";
                        kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_luk[SelectKarte[i].VR_OB_Tree2];
                        break;
                    case 6:
                        kartaInfToEdit.trida2 = "Dvourucka";
                        kartaInfToEdit.zbran2 = "tyc_d";
                        kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_polearm[SelectKarte[i].VR_OB_Tree2];
                        break;
                    case 7:
                        kartaInfToEdit.trida2 = "Dvourucka";
                        kartaInfToEdit.zbran2 = "rem_d";
                        kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_remdich[SelectKarte[i].VR_OB_Tree2];
                        break;
                    case 8:
                        kartaInfToEdit.trida2 = "Dvourucka";
                        kartaInfToEdit.zbran2 = "mec_d";
                        kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_mec[SelectKarte[i].VR_OB_Tree2];
                        break;

                }
                Debug.Log("Krok2 " + 4);
                if (SelectKarte[i].HL_OB_Tree1 != 999)
                {
                    kartaInfToEdit.helma.sprite = kartaVybavaData.helma[SelectKarte[i].HL_OB_Tree1];
                }

                Debug.Log("Krok2 " + 5);
                if (SelectKarte[i].AR_OB_Tree1 != 999)
                {
                    kartaInfToEdit.brneni.sprite = kartaVybavaData.brneni[SelectKarte[i].AR_OB_Tree1];
                }
                Debug.Log("Krok2 " + 6);
            }
            Debug.Log("Pøed všim2");
        //Bms.getLvl(karty);
        Bms.getLvlHrac(karty);



    }
}
