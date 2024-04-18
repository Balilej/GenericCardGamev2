using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LvlHrac : MonoBehaviour
{

    public static float mult;
    public static float lvlProc;
    public static int lvl;

   // public Action<float> OnPridLvl;
   // public Action<float> OnPridMult;
   // public Func<int> OnZiskejLvl;
   // public Func<float> OnZiskejLvlProc;
   // public Func<float> OnZiskejMult;
    public Func<float> OnZiskejHracMult;

    private string souborUlozeni;
    
    // Start is called before the first frame update
    void Start()
    {
       

        souborUlozeni = Application.persistentDataPath + "/HracData.txt";
        Nacti();
        //  OnPridLvl = PridLevel;
        //  OnPridMult = PridMult;
        // OnZiskejLvl = ZiskejLevel;
        // OnZiskejLvlProc = ZiskejLevelProc;
        //  OnZiskejMult = ZiskejMult;

        // LvlBarHrac.cs
        LvlBarHrac lvlBarHrac = FindObjectOfType<LvlBarHrac>();
        if(lvlBarHrac != null)
        {
            lvlBarHrac.OnZiskejLvl += ZiskejLevel;
            lvlBarHrac.OnZiskejLvlProc += ZiskejLevelProc;
            lvlBarHrac.OnZiskejMult += ZiskejMult;
            Debug.Log("funguje");
        }
        else { Debug.Log("LvlBarHrac: neni"); }
        //WLObrazScript.cs
        WLObrazScript wLObrazScript = FindObjectOfType<WLObrazScript>();
        if(wLObrazScript != null)
        {
            wLObrazScript.OnPridMult += PridMult;
        }
        //VytvorEnemy.cs
        VytvorEnemy vytvorEnemy = FindObjectOfType<VytvorEnemy>();
        if(vytvorEnemy != null)
        {
            vytvorEnemy.OnZiskejMult += ZiskejMult;
        }
        //VytvorBojovnika.cs
        GameObject EventKamarad = GameObject.Find("EventKamarad");
        VytvorBojovnika vytvorBojovnika = EventKamarad.GetComponent<VytvorBojovnika>();
        if(vytvorBojovnika != null)
        {
            vytvorBojovnika.OnZiskejHracMult += ZiskejHracMult;

            Debug.Log("Jestli to nebude fungovat...");
        }
        VytvorKartuTed vytvorKartuTed = FindObjectOfType<VytvorKartuTed>();
        if(vytvorKartuTed != null)
        {
            vytvorKartuTed.OnZiskejHracMult += ZiskejHracMult;
        }
        StartKarta startKarta = FindObjectOfType<StartKarta>();
        if(startKarta != null)
        {
            startKarta.OnPridLvl += PridLevel;
            startKarta.OnPridMult += PridMult;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PridLevel(float kolik)
    {
        lvlProc += kolik;
        if (lvlProc >= 100)
        {
            lvlProc -= 100;
            lvl++;
            NovejLevel();
        }
        Uloz();
    }

    public void NovejLevel()
    {
        //animace atd
    }

    public int ZiskejLevel()
    {
        return lvl;
    }

    public float ZiskejLevelProc()
    {
        return lvlProc;
    }

    public float ZiskejHracMult()
    {
        Debug.Log("...tak se zabiju");
        float hracMutl = (float)(lvl + (lvlProc / 100));

        return hracMutl;
    }



    public void PridMult(float kolik)
    {
        mult += kolik;
        Debug.Log("Mult nastaven na: " + mult);
        Uloz();
    }

    public float ZiskejMult()
    {
        return mult;
    }

    public void Uloz()
    {
       

        using (StreamWriter writer = new StreamWriter(souborUlozeni))
        {

            writer.WriteLine("Mult: " + mult);
            writer.WriteLine("LvlProc: " + lvlProc);
            writer.WriteLine("Lvl: " + lvl);

        }
       
    }

    public void Nacti()
    {
        if (File.Exists(souborUlozeni))
        {
            using (StreamReader reader = new StreamReader(souborUlozeni))
            {
                // Precti radek po radku
                string radek;
                while ((radek = reader.ReadLine()) != null)
                {
                    // Extrakce int variablu ze radku
                    if (radek.StartsWith("Mult:"))
                    {
                        float multValue = float.Parse(radek.Substring(radek.IndexOf(":") + 1).Trim());
                        // Do something with variable1Value
                        mult = multValue;
                        Debug.Log("multValue " + multValue);
                    }
                    else if (radek.StartsWith("LvlProc:"))
                    {
                        float lvlProcValue = float.Parse(radek.Substring(radek.IndexOf(":") + 1).Trim());
                        // Do something with variable1Value
                        lvlProc = lvlProcValue;
                        Debug.Log("lvlProcValue " + lvlProcValue);
                    }
                     else if (radek.StartsWith("Lvl:"))
                    {
                        int lvlValue = int.Parse(radek.Substring(radek.IndexOf(":") + 1).Trim());
                        // Do something with variable1Value
                        lvl = lvlValue;
                        Debug.Log("lvlValue " + lvlValue);
                    }
                    // Extrakce string variablu ze radku (Nepouzito)
                    //else if (radek.StartsWith("SEMNECO:"))
                    // {
                    //     string NAZEVHodnota = radek.Substring(radek.IndexOf(":") + 1).Trim();
                    //     // SEM KOD CO DELAT
                    // }

                }
            }
        }
        else { Debug.Log("Soubor neexistuje"); }
    }
}
