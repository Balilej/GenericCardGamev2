using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VytvorKartuTed : MonoBehaviour
{

    //Odkazy
    //KartaINF.cs nebo VytvorKartu.cs
    KartaVybINF kartaInf;
    KartaVybavaDataObchod kartaVybavaData;
    public GameObject KartaPref;
    public Animator animBoje;
    
    //BojMapa.cs
    public BojMapa bojMapa;
   

    // Vytvoøené variably
    public int pocetKaret = 12;
    public GameObject[] VKartaArray;
    public KartaVybINF[] InfKartaArray;
    KartaVybINF kartaInfToEdit; // "class-level variable"     (AJ)
    public int indexToEdit;  // Nevím jak èesky -> pak ale zmìnit     (AJ)
    public int y = 0; // použivám v VytvorKartus() atd.

    // Kup tlacitka (jsem linej to delat jinak)
    public Button[] Btn_koupit;
    public TextMeshProUGUI[] Txt_koupit;
    public int[] cenaKarty_koupit;
    // Popis kategorie
    public TextMeshProUGUI txt_kat;
    public string tag_kat = "Weapons";
    // Rand obrazky tree
    public int randMRSprite;
    public int randARHE;

    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
    //                     TADY I II II I
    //                          V VV VV V
    //                       UŽ JE BORDEL
    //                           POZOR !!!
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    public int zivoty;
    public int lvl;
    public int[] UO_stats;

    public System.Func<float> OnZiskejHracMult;
    float multhrac;

    public List<KartaVybINF> Hratelne = new List<KartaVybINF>();
    public int vybranejBojovnik = 0;
    public int hraciVBalicku = 4;
    public string TypVObchodu;

    // Scrollbar
    public Scrollbar SCRbar;
    void Start()
    {
        TypVObchodu = "Weapons";
        //Nacti veci
        kartaVybavaData = GetComponent<KartaVybavaDataObchod>();

        VKartaArray = new GameObject[pocetKaret]; // Vytvorøí array s délkou pocetKaret
        InfKartaArray = new KartaVybINF[pocetKaret];
      



        //Dìlej nìco

        for (int i = 0; i < pocetKaret; i++)
        {
            GameObject VytvorenaKarta = Instantiate(KartaPref);
            kartaInf = VytvorenaKarta.GetComponent<KartaVybINF>();

            VKartaArray[i] = VytvorenaKarta;
            InfKartaArray[i] = kartaInf;
            Hratelne.Add(kartaInf);
        }




    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            VytvorKartus();

        }
    }



    public void VytvorKartus()
    {

        for (y = 0; y < pocetKaret; y++)
        {
           // int randJmena = Random.Range(1, kartaVybavaData.dataJmenaKaret.Length);
            float randStats = Random.Range(1, 35);
            
            int indexToEdit = y;
            kartaInfToEdit = VKartaArray[indexToEdit].GetComponent<KartaVybINF>();
           
           

            if(y < 6) 
            {
                    randARHE = Random.Range(2, 9);
                    switch (randARHE)
                    {
                        case 2:
                            randMRSprite = Random.Range(0, kartaVybavaData.mala_dyka.Length);
                            kartaInfToEdit.zbroj.sprite = kartaVybavaData.mala_dyka[randMRSprite];
                            kartaInfToEdit.trida = "Jednorucka";
                            kartaInfToEdit.zbran = "dagger_j";
                            break;
                        case 3:
                            randMRSprite = Random.Range(0, kartaVybavaData.mala_mec.Length);
                            kartaInfToEdit.zbroj.sprite = kartaVybavaData.mala_mec[randMRSprite];
                            kartaInfToEdit.trida = "Jednorucka";
                            kartaInfToEdit.zbran = "mec_j";
                            break;
                        case 4:
                            randMRSprite = Random.Range(0, kartaVybavaData.mala_SekPal.Length);
                            kartaInfToEdit.zbroj.sprite = kartaVybavaData.mala_SekPal[randMRSprite];
                            kartaInfToEdit.trida = "Jednorucka";
                            kartaInfToEdit.zbran = "sekPal_j";
                            break;
                        case 5:
                            randMRSprite = Random.Range(0, kartaVybavaData.vel_luk.Length);
                            kartaInfToEdit.zbroj.sprite = kartaVybavaData.vel_luk[randMRSprite];
                            kartaInfToEdit.trida = "Luk";
                            kartaInfToEdit.zbran = "luk_l";
                            break;
                        case 6:
                            randMRSprite = Random.Range(0, kartaVybavaData.vel_polearm.Length);
                            kartaInfToEdit.zbroj.sprite = kartaVybavaData.vel_polearm[randMRSprite];
                            kartaInfToEdit.trida = "Dvourucka";
                            kartaInfToEdit.zbran = "tyc_d";
                            break;
                        case 7:
                            randMRSprite = Random.Range(0, kartaVybavaData.vel_remdich.Length);
                            kartaInfToEdit.zbroj.sprite = kartaVybavaData.vel_remdich[randMRSprite];
                            kartaInfToEdit.trida = "Dvourucka";
                            kartaInfToEdit.zbran = "rem_d";
                            break;
                        case 8:
                            randMRSprite = Random.Range(0, kartaVybavaData.vel_mec.Length);
                            kartaInfToEdit.zbroj.sprite = kartaVybavaData.vel_mec[randMRSprite];
                            kartaInfToEdit.trida = "Dvourucka";
                            kartaInfToEdit.zbran = "mec_d";
                            break;
                    }

                    
            }
            else
            {
                randARHE = Random.Range(0, 2);
                if (randARHE == 0)
                {
                    randMRSprite = Random.Range(1, kartaVybavaData.helma.Length);
                    kartaInfToEdit.zbroj.sprite = kartaVybavaData.helma[randMRSprite];
                    kartaInfToEdit.trida = "Armor";
                    kartaInfToEdit.zbran = "helma";
                }
                else
                {
                    randMRSprite = Random.Range(0, kartaVybavaData.brneni.Length);
                    kartaInfToEdit.zbroj.sprite = kartaVybavaData.brneni[randMRSprite];
                    kartaInfToEdit.trida = "Armor";
                    kartaInfToEdit.zbran = "brneni";
                }
            }
               
          
            kartaInfToEdit.id = 1 + y;
            //  kartaInfToEdit.jmeno.text = kartaVybavaData.dataJmenaKaret[randJmena];

            multhrac = OnZiskejHracMult.Invoke();
            // Sem pridat randhodnoty maker
            int stesti = Random.Range(1, 1100);

            if (stesti != 1000)
            {
                zivoty = (int)(Random.Range(10, 50) * multhrac);
                lvl = (int)(1 + multhrac);
                UO_stats = new int[4];

                for (int i = 0; i < UO_stats.Length - 1; i++)
                {
                    UO_stats[i] = (int)(Random.Range(5, 25) * multhrac);
                }

            }
            else if (stesti == 1000)
            {
                zivoty = (int)(Random.Range(2, 500) * multhrac);
                lvl = (int)(Random.Range(1, 5) + multhrac);
                UO_stats = new int[4];

                for (int i = 0; i < UO_stats.Length - 1; i++)
                {
                    UO_stats[i] = (int)(Random.Range(1, 1000) * multhrac);
                }
            }

            kartaInfToEdit.NapisStaty(zivoty, UO_stats[0], UO_stats[1], UO_stats[2], UO_stats[3], lvl, randARHE, randMRSprite);

            //  bojKarta.Add(kartaInfToEdit);
            kartaInfToEdit.transform.localScale = new Vector3(0.149f, 0.149f, 0.149f);
            Btn_Weapons();
            // KartaCena();
        }
        
    }

    public void Btn_Weapons()
    {
        KartaCena();

                Hratelne[0].transform.position = new Vector3(0.81f, 2.5f, 14.04f);

                Hratelne[1].transform.position = new Vector3(5.18f, 2.5f, 14.04f);            

                Hratelne[2].transform.position = new Vector3(9.62f, 2.5f, 14.04f);

                Hratelne[3].transform.position = new Vector3(0.81f, -4.21f, 14.04f);

                Hratelne[4].transform.position = new Vector3(5.18f, -4.21f, 14.04f);

                Hratelne[5].transform.position = new Vector3(9.62f, -4.21f, 14.04f);
       
        for (int i = 0; i != 6; i++)
        {
            Txt_koupit[i].text = "€" + cenaKarty_koupit[i].ToString();
            Btn_koupit[i].tag = i.ToString();
            if (Hratelne[i].karta.activeSelf == false)
            {
                Btn_koupit[i].gameObject.SetActive(false);
            }
            else { Btn_koupit[i].gameObject.SetActive(true); }
        }
        for (int y = 6; y != 12; y++)
        {
            Hratelne[y].transform.position = new Vector3(6f, 9f, -88f);
        }

       
    }

    public void Btn_Armor()
    {

        
        Hratelne[6].transform.position = new Vector3(0.81f, 2.5f, 14.04f);

        Hratelne[7].transform.position = new Vector3(5.18f, 2.5f, 14.04f);

        Hratelne[8].transform.position = new Vector3(9.62f, 2.5f, 14.04f);

        Hratelne[9].transform.position = new Vector3(0.81f, -4.21f, 14.04f);

        Hratelne[10].transform.position = new Vector3(5.18f, -4.21f, 14.04f);

        Hratelne[11].transform.position = new Vector3(9.62f, -4.21f, 14.04f);

        int x = 0;
        for (int i = 6; i != 12; i++)
        {

            Txt_koupit[x].text = "€" + cenaKarty_koupit[i].ToString();
            Btn_koupit[x].tag = i.ToString();
            
            if(Hratelne[i].karta.activeSelf == false)
            {
                Btn_koupit[x].gameObject.SetActive(false);
            } else { Btn_koupit[x].gameObject.SetActive(true); }
            x++;
        }

        for (int y = 0; y != 6; y++)
        {
            Hratelne[y].transform.position = new Vector3(6f, 9f, -88f);
        }
    }

    public void KartaCena()
    {
        for (int i = 0; i != pocetKaret; i++)
        {
            cenaKarty_koupit[i] = (int)((Hratelne[i].zivoty + Hratelne[i].utok) / 2);
            // Txt_koupit[i].text = cenaKarty_koupit[i].ToString();
        }
    }

    public void KategorieZmen(GameObject button)
    {
        TypVObchodu = button.tag;
        txt_kat.text = TypVObchodu;
        if (TypVObchodu == "Weapons")
        {
            Btn_Weapons();
        }
        if(TypVObchodu == "Armor")
        {
            Btn_Armor();
        }
    }

  

    
    
}
