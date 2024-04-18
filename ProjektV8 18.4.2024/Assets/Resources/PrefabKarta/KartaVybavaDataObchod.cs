using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartaVybavaDataObchod : MonoBehaviour
{
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

   
    void Start()
    {
        helma = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/helmet/helmet");
        brneni = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/armor/armor");
        // zbrane - mala ruka
        mala_dyka = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/mala ruka/dagger");
        mala_mec = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/mala ruka/sword");
        mala_SekPal = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/mala ruka/SekPal");
        // zbrane - velka ruka
        vel_luk = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/velka ruka/luk");
        vel_polearm = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/velka ruka/polearm");
        vel_remdich = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/velka ruka/remdich");
        vel_mec = Resources.LoadAll<Sprite>("Sheets/Malej Sheet/velka ruka/sword");
    }
   
}
