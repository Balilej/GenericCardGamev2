using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLovOrLvl : MonoBehaviour
{
    public static bool LovF_LvlT = false;
    public  BojMainScript Bms;
    [SerializeField] KartaINF kartaINFPref;
    public List<KartaINF> karty = new List<KartaINF>();
    public KartaVybavaData kartaVybavaData;

    public KarteList karteList;
    // Start is called before the first frame update
    void Start()
    {
        Bms = GetComponent<BojMainScript>();
        if(LovF_LvlT == false)
        {
            GetLov();
        }
        if(LovF_LvlT == true)
        {
            StartCoroutine(GetLvl());
        }
    }

    public void GetLov()
    {
        Bms.getLov();
    }

   
    IEnumerator GetLvl()
    {
        yield return new WaitForSeconds(1.2f);

        vytvorLvlBoj();
        karteList.GetHraceKarte();

    }

    Vector3 pozice = new Vector3(10, 20, 2);
    public void vytvorLvlBoj()
    {
        Debug.Log(Levely.EnemyLvl.Count + "   level enemy count");
        Debug.Log(Levely.EnemyLvl[1].zivoty + " zivoty blbeèka " + " verze 1");
        int max = Levely.EnemyLvl.Count;
       
        for (int i = 0; i != max; i++)
        {
            Debug.Log(Levely.EnemyLvl[i].zivoty + " zivoty blbeèka " + i + " verze 2");

            Debug.Log("Krok " + -1);
            KartaINF kartaINF = Instantiate(kartaINFPref, pozice, Quaternion.identity);
            Debug.Log("Krok " + 0);
            karty.Add(kartaINF);

            KartaINF kartaInfToEdit = karty[i];
            Debug.Log("Krok " + 1);
            kartaInfToEdit.NapisStaty(Levely.EnemyLvl[i].startZivoty, Levely.EnemyLvl[i].utok, Levely.EnemyLvl[i].vykriti, Levely.EnemyLvl[i].obrana, Levely.EnemyLvl[i].obranaPosk, Levely.EnemyLvl[i].level,
                    Levely.EnemyLvl[i].MR_OB_Tree1, Levely.EnemyLvl[i].MR_OB_Tree2, Levely.EnemyLvl[i].VR_OB_Tree1, Levely.EnemyLvl[i].VR_OB_Tree2, Levely.EnemyLvl[i].AR_OB_Tree1, Levely.EnemyLvl[i].HL_OB_Tree1, Levely.EnemyLvl[i].jmenoKarty);

            Debug.Log("Krok " + 2);
            Debug.Log(Levely.EnemyLvl[i].MR_OB_Tree1);
            Debug.Log(Levely.EnemyLvl[i].MR_OB_Tree2);
            switch (Levely.EnemyLvl[i].MR_OB_Tree1)
            {
                case 0:
                    kartaInfToEdit.trida = "Pesti";
                    kartaInfToEdit.zbran = "pest";
                    break;
                case 1:
                    Debug.Log("Krok " + 2.1);
                    kartaInfToEdit.trida = "Jednorucka";
                    kartaInfToEdit.zbran = "dagger_j";
                    Debug.Log("Krok " + 2.2);
                    kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_dyka[Levely.EnemyLvl[i].MR_OB_Tree2];
                    Debug.Log("Krok " + 2.3);
                    break;
                case 2:
                    kartaInfToEdit.trida = "Jednorucka";
                    kartaInfToEdit.zbran = "mec_j";
                    kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_mec[Levely.EnemyLvl[i].MR_OB_Tree2];

                    break;
                case 3:
                    kartaInfToEdit.trida = "Jednorucka";
                    kartaInfToEdit.zbran = "sekPal_j";
                    kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_SekPal[Levely.EnemyLvl[i].MR_OB_Tree2];
                    break;

            }
            Debug.Log("Krok " + 3);
            switch (Levely.EnemyLvl[i].VR_OB_Tree1)
            {
                case 5:
                    kartaInfToEdit.trida2 = "Luk";
                    kartaInfToEdit.zbran2 = "luk_l";
                    kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_luk[Levely.EnemyLvl[i].VR_OB_Tree2];
                    break;
                case 6:
                    kartaInfToEdit.trida2 = "Dvourucka";
                    kartaInfToEdit.zbran2 = "tyc_d";
                    kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_polearm[Levely.EnemyLvl[i].VR_OB_Tree2];
                    break;
                case 7:
                    kartaInfToEdit.trida2 = "Dvourucka";
                    kartaInfToEdit.zbran2 = "rem_d";
                    kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_remdich[Levely.EnemyLvl[i].VR_OB_Tree2];
                    break;
                case 8:
                    kartaInfToEdit.trida2 = "Dvourucka";
                    kartaInfToEdit.zbran2 = "mec_d";
                    kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_mec[Levely.EnemyLvl[i].VR_OB_Tree2];
                    break;

            }
            Debug.Log("Krok " + 4);
            if (Levely.EnemyLvl[i].HL_OB_Tree1 != 0)
            {
                kartaInfToEdit.helma.sprite = kartaVybavaData.helma[Levely.EnemyLvl[i].HL_OB_Tree1];
            }

            Debug.Log("Krok " + 5);
            if (Levely.EnemyLvl[i].AR_OB_Tree1 != 999)
            {
                kartaInfToEdit.brneni.sprite = kartaVybavaData.brneni[Levely.EnemyLvl[i].AR_OB_Tree1];
            }
            Debug.Log("Krok " + 6);
        }
        Debug.Log("Pøed všim");
        Bms.getLvl(karty);

    }
}
