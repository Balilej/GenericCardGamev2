using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad : MonoBehaviour
{

    //Mesec_System.cs
    public Mesec_System MesecSys;
    public GameObject MesecObj;

    //Mistni variabli
    private string souborUlozeni;

    //Ukladane vyriabli
    public int mesecVal;

    private void Start()
    {
        MesecObj = GameObject.Find("Mesec_objekt");
        MesecSys = MesecObj.GetComponent<Mesec_System>();
        souborUlozeni = Application.persistentDataPath + "/saveData.txt";
        Nacti();
    }

    public void Uloz(int mnozstviMeny)
    {
        mesecVal = mnozstviMeny;
        using (StreamWriter writer = new StreamWriter(souborUlozeni))
        {

            writer.WriteLine("Mesec: " + mesecVal);
           
        }

    }



    private void Nacti()
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
                    if (radek.StartsWith("Mesec:"))
                    {
                        int mesecValCte = int.Parse(radek.Substring(radek.IndexOf(":") + 1).Trim());
                        // Do something with variable1Value
                        MesecSys.MesecLoad(mesecValCte);
                    }
                    // Extrakce string variablu ze radku (Nepouzito)
                    //else if (radek.StartsWith("SEMNECO:"))
                   // {
                   //     string NAZEVHodnota = radek.Substring(radek.IndexOf(":") + 1).Trim();
                   //     // SEM KOD CO DELAT
                   // }

                }
            }
        } else { Debug.Log("Soubor neexistuje"); }
    }
}
