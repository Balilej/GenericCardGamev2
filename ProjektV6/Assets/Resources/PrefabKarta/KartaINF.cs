using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class KartaINF : MonoBehaviour
{


    //Karta
    public GameObject karta;
    public Image front;
    public Image helma;
    public Image brneni;
    public Image zbran_mala;
    public Image zbran_Velka;
    public Image strany;
    public GameObject zadaSprite;
    public TextMeshProUGUI jmeno;
    public TextMeshProUGUI informace;
    public Button tlacitkoTrigger;
    public string spriteId;
    public Sprite[] spriteArray;
    public Sprite sprite;
    public Animator KartaPOZ;
    //  public Animation kartaBehave;


    // Statistiky karty
    public string trida;
    public string zbran;
    public string trida2;
    public string zbran2;
    public float zivoty;
    public float startZivoty;
    public float utok;
    public float vykriti; // Šance na uhnutí - Neubere životy
    public float obrana;  // Šance na obrannu - ubereme ménì životù - ubere trochu životù útoèníkovi
    public float obranaPosk; // Poškození když se hráè brání
    public float level;
    public float levelPerc; // Procenta do dalšího levelu

    // Obrazky
    //Mala ruka
    public int MR_OB_Tree1;
    public int MR_OB_Tree2;
    //Velka ruka
    public int VR_OB_Tree1;
    public int VR_OB_Tree2;
    //Brneni
    public int AR_OB_Tree1;

    //Helma
    public int HL_OB_Tree1;

    //SaveLoad promeny
    public string jmenoKarty;

    //Funkèní variably
    public int i = 0;
    public int MomentObrazek = 0;
    public int id;
    public bool Hover = false;
    public bool Hratelna = true;
    public bool KartaHrace = false;

    // Odkazy
    //VytvorKartu.cs
    GameObject KartaTisk;
   public BojMainScript bojMainScript;

    // KartaVybavaData
    KartaVybavaData KVD;

   

    // Start is called before the first frame update
    void Start()
    {
        
        // Naète array obrázkù ilustrací a nastaví na nultý("momentObrazek")
        //  kartaBehave = GetComponent<Animation>();
        KartaPOZ = GetComponent<Animator>();
        spriteArray = Resources.LoadAll<Sprite>("ishallahTRY");
        //zbran_mala.sprite = spriteArray[MomentObrazek];
        //VytvorKartu je:
        KartaTisk = GameObject.Find("EventKamarad");
      //  tiskScript = KartaTisk.GetComponent<VytvorKartu>();
        KVD = KartaTisk.GetComponent<KartaVybavaData>();
        bojMainScript = KartaTisk.GetComponent<BojMainScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Nevím proè ale tohle exituje jako nastavovaè obrázku :shrugg:
      //  zbran_mala.sprite = spriteArray[MomentObrazek];
    }

    

    // Píše staty karty
    public void NapisStaty(float zivotyPr, float utokPr, float vykritiPr, float obranaPr, float obranaPoskPr, float levelPr, int mr_t1, int mr_t2, int vr_t1, int vr_t2, int ar_t1, int hl_t1, string jmeno)
    {
        zivoty = zivotyPr;
        startZivoty = zivotyPr;
        utok = utokPr;
        vykriti = vykritiPr;
        obrana = obranaPr;
        obranaPosk = obranaPoskPr;
        level = levelPr;
        informace.text =
            "Health: " + zivoty + "\n" +
            "Damage: " + utok + "\n" +
            "Dodge chance: " + vykriti + "\n" +
            "Defense chance: " + obrana + "\n" +
            "(Damage when defending:  " + obranaPosk + ")" + "\n" +
            "Card level: " + level;

        // Obrazky
        //Mala ruka
        MR_OB_Tree1 = mr_t1;
        MR_OB_Tree2 = mr_t2;
        //Velka ruka
        VR_OB_Tree1 = vr_t1;
        VR_OB_Tree2 = vr_t2;
        //Brneni
        AR_OB_Tree1 = ar_t1;
        //Helma
        HL_OB_Tree1 = hl_t1;


        jmenoKarty = jmeno;
        this.jmeno.text = jmeno;


    }

    // Karta Ovladání
    void OnMouseDown() { LClick(); }
    private void OnMouseEnter() { RClick(); }
    void OnMouseExit() { RClick_Ex(); }
    
    public void LClick()
    {
        if (Hratelna == true && karta.tag != "Enemy")
        {
            //  kartaBehave.Play("PolozKartu");
            KartaPOZ.Play("PolozKartu");
            KartaHrace = true;
            Hratelna = false;
            KartaINF polozenaKarta = this;
            //tiskScript.BojKaret(polozenaKarta);
            bojMainScript.BojKaret(polozenaKarta);
        }
    }

    public void RClick()
    {
        if ( Hratelna == true)
        {
            KartaPOZ.SetBool("Hover", true);
            switch (karta.tag)
            {

                case "Poloha1":
                    //  kartaBehave.Play("HoverKartaJedna");
                    KartaPOZ.Play("HoverK1");
                    
                    break;
                case "Poloha2":
                    // kartaBehave.Play("HoverKartaDva");
                    KartaPOZ.Play("HoverK2");
                    break;
                case "Poloha3":
                    //  kartaBehave.Play("HoverKartaTri");
                    KartaPOZ.Play("HoverK3");
                    break;
                case "Poloha4":
                    //  kartaBehave.Play("HoverKartaCtyri");
                    KartaPOZ.Play("HoverK4");
                    break;
                case "Enemy":
                    KartaPOZ.Play("EnemyKartaHover1");
                    break;
            }
        }
    }

    public void RClick_Ex()
    {
        if (Hratelna == true)
        {
            KartaPOZ.SetBool("Hover", false);
        }
    }

   public bool JeNazivu()
    {
        if (zivoty >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UlozMe()
    {
        SLBojSys.kartyBoj.Add(this);
        // saveCompSystem.KartungSave();

    }

    public void Smrt()
    {
        Destroy(karta);
    }
}
