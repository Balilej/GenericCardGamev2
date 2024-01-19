using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartaVybavaData : MonoBehaviour
{
    public string[] dataJmenaKaret;

    // sprity
    //LOV
    //Helma a breneni
    public Sprite[] helma;
    public Sprite[] brneni;
    // zbrane - mala ruka
    public Sprite[] mala_dyka;
    public Sprite[] mala_mec;
    public Sprite[] mala_SekPal;
    // zbrane - velka ruka
    public Sprite[] vel_luk;
    public Sprite[] vel_polearm;
    public Sprite[] vel_remdich;
    public Sprite[] vel_mec;
    
        
    // Start is called before the first frame update
    void Start()
    {
       
        dataJmenaKaret = new string[] {
         "Achilles", "Adonis", "Aegeus", "Aeneas", "Ajax", "Alastor", "Alcides", "Alexander", "Alexios", "Aristaeus",
    "Aristotle", "Atticus", "Callias", "Cassander", "Chrysippus", "Cimon", "Damian", "Demetrius", "Dionysus", "Evander",
    "Galen", "Hector", "Hippolytus", "Icarus", "Iphigenes", "Jason", "Kairos", "Leander", "Leonidas", "Lycurgus",
    "Menelaus", "Miltiades", "Nereus", "Nestor", "Odysseus", "Orion", "Pallas", "Pericles", "Phoenix", "Pollux",
    "Proteus", "Pythagoras", "Socrates", "Solon", "Stelios", "Theodore", "Theseus", "Thetis", "Xander", "Xenophon",
    "Zephyrus", "Zeno"
        };
        LoadSprite();
    }

    public void LoadSprite()
    {
        helma = Resources.LoadAll<Sprite>("Sheets/Hlava/helmet");
        brneni = Resources.LoadAll<Sprite>("Sheets/Brneni/armor");
        // zbrane - mala ruka
        mala_dyka = Resources.LoadAll<Sprite>("Sheets/Mala Ruka/dyka");
        mala_mec = Resources.LoadAll<Sprite>("Sheets/Mala Ruka/mec");
        mala_SekPal = Resources.LoadAll<Sprite>("Sheets/Mala Ruka/SekPal");
        // zbrane - velka ruka
        vel_luk = Resources.LoadAll<Sprite>("Sheets/Velka Ruka/luk");
        vel_polearm = Resources.LoadAll<Sprite>("Sheets/Velka Ruka/polearm");
        vel_remdich = Resources.LoadAll<Sprite>("Sheets/Velka Ruka/remdich");
        vel_mec = Resources.LoadAll<Sprite>("Sheets/Velka Ruka/V_mec");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
