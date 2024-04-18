using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class KartaVybINF : MonoBehaviour
{


    //Karta
    public GameObject karta;
    public Image front;
    public Image zbroj;
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
    public float zivoty;
    public float startZivoty;
    public float utok;
    public float vykriti; // �ance na uhnut� - Neubere �ivoty
    public float obrana;  // �ance na obrannu - ubereme m�n� �ivot� - ubere trochu �ivot� �to�n�kovi
    public float obranaPosk; // Po�kozen� kdy� se hr�� br�n�
    public float level;
    public float levelPerc; // Procenta do dal��ho levelu
    public int obrazek_Tree1;
    public int obrazek_Tree2;

    //Funk�n� variably
    public int i = 0;
   // public int MomentObrazek = 0;
    public int id;
    public bool Hover = false;
    public bool Hratelna = true;
    public bool KartaHrace = false;
    public bool saveLoadYN = true;

    // Odkazy
    //VytvorKartu.cs
    GameObject KartaTisk;
    VytvorKartuTed tiskScript;
    // KartaVybavaData
    KartaVybavaDataObchod KVD;
    //SaveComSystem
   public SaveCompSystem saveCompSystem;
    public GameObject sasobj;


    // Start is called before the first frame update
    void Start()
    {
        saveCompSystem = GameObject.Find("SaveSystemKarta").GetComponent<SaveCompSystem>();
        // Na�te array obr�zk� ilustrac� a nastav� na nult�("momentObrazek")
        //  kartaBehave = GetComponent<Animation>();
        KartaPOZ = GetComponent<Animator>();
        spriteArray = Resources.LoadAll<Sprite>("ishallah");
       // zbroj.sprite = spriteArray[MomentObrazek];
        //VytvorKartu je:
        KartaTisk = GameObject.Find("EventKamarad");
        tiskScript = KartaTisk.GetComponent<VytvorKartuTed>();
        KVD = KartaTisk.GetComponent<KartaVybavaDataObchod>();
        //SaveSys je:
        
        

    }

    // Update is called once per frame
    void Update()
    {
        // Nev�m pro� ale tohle exituje jako nastavova� obr�zku :shrugg:
       // zbroj.sprite = spriteArray[MomentObrazek];
    }

    // P�e staty karty
    public void NapisStaty(float zivotyPr, float utokPr, float vykritiPr, float obranaPr, float obranaPoskPr, float levelPr, int randAshe, int randAsheSprite)
    {
        zivoty = zivotyPr;
        startZivoty = zivotyPr;
        utok = utokPr;
        vykriti = vykritiPr;
        obrana = obranaPr;
        obranaPosk = obranaPoskPr;
        level = levelPr;
        obrazek_Tree1 = randAshe;
        obrazek_Tree2 = randAsheSprite;
        informace.text =
            "Health: " + zivoty + "\n" +
            "Damage: " + utok + "\n" +
            "Dodge chance: " + vykriti + "\n" +
            "Defense chance: " + obrana + "\n" +
            "(Damage defending:  " + obranaPosk + ")" + "\n" +
            "Card level: " + level;
    }

    public void UlozMe()
    {
        SaveCompSystem.karty.Add(this);
       // saveCompSystem.KartungSave();
        
    }
   
    public void Smrt()
    {
        
        SaveCompSystem.karty.Remove(this);
       // saveCompSystem.KartungSave();
        Destroy(karta);
        saveLoadYN = false;
    }


}
