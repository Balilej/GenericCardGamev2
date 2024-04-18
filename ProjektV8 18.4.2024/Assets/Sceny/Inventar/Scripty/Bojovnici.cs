using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bojovnici : MonoBehaviour
{
    public SLBojSys SaveSys;
    public KartaVybavaData KVD;

    public List<KartaINF> Hrac = new List<KartaINF>();
    public int HracIndex;
    KartaINF EqKarta;
    // Start is called before the first frame update
    void Start()
    {
        SaveSys = GameObject.Find("SaveLoadSystem").GetComponent<SLBojSys>();
        KVD = GetComponent<KartaVybavaData>();
        HracIndex = 0;
        StartCoroutine(getHrac());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator getHrac()
    {
        yield return new WaitForSeconds(1.2f);
        Hrac = SaveSys.GetMojeKarty();
        //  KdoEqip(HracIndex);

        EqKarta = Hrac[0];
        EqKarta.KartaPOZ.Play("Vyhod");
    }
    

    public void KdoEqip(KartaVybINF vyb)
    {
        EqKarta.zivoty = EqKarta.zivoty + vyb.zivoty;
        EqKarta.startZivoty = EqKarta.startZivoty + vyb.startZivoty;
        EqKarta.utok = EqKarta.utok + vyb.utok;
        EqKarta.vykriti = EqKarta.vykriti + vyb.vykriti; // Šance na uhnutí - Neubere životy
        EqKarta.obrana = EqKarta.obrana + vyb.obrana;  // Šance na obrannu - ubereme ménì životù - ubere trochu životù útoèníkovi
        EqKarta.obranaPosk = EqKarta.obranaPosk + vyb.obranaPosk;// Poškození když se hráè brání

        EqKarta.informace.text =
            "Health: " + EqKarta.zivoty + "\n" +
            "Damage: " + EqKarta.utok + "\n" +
            "Dodge chance: " + EqKarta.vykriti + "\n" +
            "Defense chance: " + EqKarta.obrana + "\n" +
            "(Damage when defending:  " + EqKarta.obranaPosk + ")" + "\n" +
            "Card level: " + EqKarta.level;

        if(vyb.trida == "Jednorucka")
        {
            EqKarta.MR_OB_Tree1 = vyb.obrazek_Tree1;
            EqKarta.MR_OB_Tree2 = vyb.obrazek_Tree2;
            switch (vyb.obrazek_Tree1)
            {
                case 2:
                    EqKarta.trida = "Jednorucka";
                    EqKarta.zbran = "dagger_j";
                    EqKarta.zbran_mala.sprite = KVD.mala_dyka[vyb.obrazek_Tree2];
                    
                    break;
                case 3:
                    EqKarta.trida = "Jednorucka";
                    EqKarta.zbran = "mec_j";
                    EqKarta.zbran_mala.sprite = KVD.mala_mec[vyb.obrazek_Tree2];

                    break;
                case 4:
                    EqKarta.trida = "Jednorucka";
                    EqKarta.zbran = "sekPal_j";
                    EqKarta.zbran_mala.sprite = KVD.mala_SekPal[vyb.obrazek_Tree2];
                    break;

            }
        }
        if (vyb.trida == "Dvourucka")
        {
            EqKarta.VR_OB_Tree1 = vyb.obrazek_Tree1;
            EqKarta.VR_OB_Tree2 = vyb.obrazek_Tree2;
            switch (vyb.obrazek_Tree1)
            {
                case 5:
                    EqKarta.trida2 = "Luk";
                    EqKarta.zbran2 = "luk_l";
                    EqKarta.zbran_Velka.sprite = KVD.vel_luk[vyb.obrazek_Tree2];
                    break;
                case 6:
                    Debug.Log("set this bitch up");
                    EqKarta.trida2 = "Dvourucka";
                    EqKarta.zbran2 = "tyc_d";
                    EqKarta.zbran_Velka.sprite = KVD.vel_polearm[vyb.obrazek_Tree2];
                    Debug.Log("kill me00");
                    break;
                case 7:
                    EqKarta.trida2 = "Dvourucka";
                    EqKarta.zbran2 = "rem_d";
                    EqKarta.zbran_Velka.sprite = KVD.vel_remdich[vyb.obrazek_Tree2];
                    
                    break;
                case 8:
                    EqKarta.trida2 = "Dvourucka";
                    EqKarta.zbran2 = "mec_d";
                    EqKarta.zbran_Velka.sprite = KVD.vel_mec[vyb.obrazek_Tree2];
                    break;

            }
        }
        if (vyb.trida == "Armor" && vyb.zbran == "brneni")
        {
            EqKarta.brneni.sprite = KVD.brneni[vyb.obrazek_Tree2];
            EqKarta.AR_OB_Tree1 = vyb.obrazek_Tree2;
        }
        if (vyb.trida == "Armor" && vyb.zbran == "helma")
        {
            EqKarta.helma.sprite = KVD.helma[vyb.obrazek_Tree2];
            EqKarta.HL_OB_Tree1 = vyb.obrazek_Tree2;
           
        }

    }

    public void UP_btn()
    {
        if(HracIndex < Hrac.Count - 1)
        {
            Vymena(1);
        }
       
    }

    public void Down_btn()
    {
        if (HracIndex != 0)
        {
            Vymena(-1);
        }
    }
    
    public void Vymena(int hr_index)
    {
        EqKarta.KartaPOZ.Play("Zmis");
        HracIndex= HracIndex + hr_index;
        EqKarta = Hrac[HracIndex];
        EqKarta.KartaPOZ.Play("Vyhod");

    }

    public bool Muzu(KartaVybINF vybaveni)
    {
        bool muzu = false;
        switch (vybaveni.trida)
        {
            case "Jednorucka":
                if(EqKarta.zbran_mala.GetComponent<Image>().sprite.name == "empty")
                {
                    muzu = true;
                } else { muzu = false; }
                break;
            case "Dvourucka":
            case "Luk":
                if (EqKarta.zbran_Velka.GetComponent<Image>().sprite.name == "empty")
                {
                    muzu = true;
                }
                else { muzu = false; }
                break;
            
        }
        if(vybaveni.trida == "Armor" && vybaveni.zbran == "helma")
        {
            if (EqKarta.helma.GetComponent<Image>().sprite.name == "helmet_0")
            {
                muzu = true;
            }
            else { muzu = false; }
        }
        if (vybaveni.trida == "Armor" && vybaveni.zbran == "brneni")
        {
            
            if (EqKarta.brneni.GetComponent<Image>().sprite.name == "empty")
            {
                
                muzu = true;
                Debug.Log(muzu + " tohle muzu");
            }
            else { muzu = false; }
        }
        Debug.Log(muzu + " muzu");
        return muzu;
    }
}
