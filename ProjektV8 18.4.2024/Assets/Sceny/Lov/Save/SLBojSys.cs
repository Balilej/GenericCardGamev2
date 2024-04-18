using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SLBojSys : MonoBehaviour
{
    [SerializeField] KartaINF kartaINFPref;

   public KartaVybavaData kartaVybavaData;

    

    public static List<KartaINF> kartyBoj = new List<KartaINF>();
    public List<KartaINF> AKarten = new List<KartaINF>();
    const string BOJ_KARTA_SUB = "/KartyBoj";
    const string BOJ_KARTA_COUNT_SUB = "/KartyBoj.count";

    private void Start()
    {
        kartaVybavaData = GameObject.Find("EventKamarad").GetComponent<KartaVybavaData>();
    }

  //  private void OnApplicationQuit()
   // {
  //      KartungSave();
  //  }

    public void KartungSave()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + BOJ_KARTA_SUB;
        string countPath = Application.persistentDataPath + BOJ_KARTA_COUNT_SUB;

        FileStream countStream = new FileStream(countPath, FileMode.Create);
        formatter.Serialize(countStream, kartyBoj.Count);
        countStream.Close();

        for (int i = 0; i < kartyBoj.Count; i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            SaveBojSer data = new SaveBojSer(kartyBoj[i]);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        kartyBoj.Clear(); //smaz kdyztak
    }

    public void KartungLoad()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + BOJ_KARTA_SUB;
        string countPath = Application.persistentDataPath + BOJ_KARTA_COUNT_SUB;
        int kartyPocet = 0;

        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            kartyPocet = (int)formatter.Deserialize(countStream);
            Debug.Log(kartyPocet + "  Pocet karet");
            countStream.Close();
        }
        else { Debug.LogError("Path not found in " + countPath); }

       
        for (int i = 0; i < kartyPocet; i++)
        {
            if (File.Exists(path + i))
            {
               
                FileStream stream = new FileStream(path + i, FileMode.Open);
                SaveBojSer data = formatter.Deserialize(stream) as SaveBojSer;

                stream.Close();

                Vector3 pozice = new Vector3(0,0,-80);


                KartaINF kartaINF = Instantiate(kartaINFPref, pozice, Quaternion.identity);


                 kartyBoj.Add(kartaINF);
                 AKarten.Add(kartaINF);
               // kartyBoj.Clear();

                kartaINF.NapisStaty(data.startZivoty, data.utok, data.vykriti, data.obrana, data.obranaPosk, data.level,
                    data.MR_OB_Tree1, data.MR_OB_Tree2, data.VR_OB_Tree1, data.VR_OB_Tree2, data.AR_OB_Tree1, data.HL_OB_Tree1, data.JmenoKarty);

               

                switch (data.MR_OB_Tree1)
                {
                    case 0:
                        kartaINF.trida = "Pesti";
                        kartaINF.zbran = "pest";
                        break;
                    case 1:
                        kartaINF.trida = "Jednorucka";
                        kartaINF.zbran = "dagger_j";
                        kartaINF.zbran_mala.sprite = kartaVybavaData.mala_dyka[data.MR_OB_Tree2];
                        break;
                    case 2:
                        kartaINF.trida = "Jednorucka";
                        kartaINF.zbran = "mec_j";
                        kartaINF.zbran_mala.sprite = kartaVybavaData.mala_mec[data.MR_OB_Tree2];

                        break;
                    case 3:
                        kartaINF.trida = "Jednorucka";
                        kartaINF.zbran = "sekPal_j";
                        kartaINF.zbran_mala.sprite = kartaVybavaData.mala_SekPal[data.MR_OB_Tree2];
                        break;

                }
                switch (data.VR_OB_Tree1)
                {
                    case 5:
                        kartaINF.trida2 = "Luk";
                        kartaINF.zbran2 = "luk_l";
                        kartaINF.zbran_Velka.sprite = kartaVybavaData.vel_luk[data.VR_OB_Tree2];
                        break;
                    case 6:
                        kartaINF.trida2 = "Dvourucka";
                        kartaINF.zbran2 = "tyc_d";
                        kartaINF.zbran_Velka.sprite = kartaVybavaData.vel_polearm[data.VR_OB_Tree2];
                        break;
                    case 7:
                        kartaINF.trida2 = "Dvourucka";
                        kartaINF.zbran2 = "rem_d";
                        kartaINF.zbran_Velka.sprite = kartaVybavaData.vel_remdich[data.VR_OB_Tree2];
                        break;
                    case 8:
                        kartaINF.trida2 = "Dvourucka";
                        kartaINF.zbran2 = "mec_d";
                        kartaINF.zbran_Velka.sprite = kartaVybavaData.vel_mec[data.VR_OB_Tree2];
                        break;

                }
                if(data.HL_OB_Tree1 != 999)
                {
                    kartaINF.helma.sprite = kartaVybavaData.helma[data.HL_OB_Tree1];
                }
                

                if (data.AR_OB_Tree1 != 999)
                {
                    kartaINF.brneni.sprite = kartaVybavaData.brneni[data.AR_OB_Tree1];
                }



            }
            else { Debug.LogError("Path not found in " + path + i); }
        }

        // karty.Clear();
    }

    public Transform cardDeckPoint;
    public GameObject CardDeckAnim;
    Vector3 CDA = new Vector3(0, 0, 0);
    public int PKrow = 1;

    public void KartungLoadBojMenu()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + BOJ_KARTA_SUB;
        string countPath = Application.persistentDataPath + BOJ_KARTA_COUNT_SUB;
        int kartyPocet = 0;

        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            kartyPocet = (int)formatter.Deserialize(countStream);
            countStream.Close();
        }
        else { Debug.LogError("Path not found in " + countPath); }

        int row = 0;
        int yPos = -3;
        for (int i = 0; i < kartyPocet; i++)
        {
            if (File.Exists(path + i))
            {
                if (row == 3)
                {
                    yPos = yPos - 10;
                    row = 0;
                    PKrow++;
                }
                FileStream stream = new FileStream(path + i, FileMode.Open);
                SaveBojSer data = formatter.Deserialize(stream) as SaveBojSer;

                stream.Close();

                Vector3 pozice = new Vector3(-4f + row * 7, yPos, 5.87f);
              //  Vector3 pozice = new Vector3(0, 0, 0);
                row++;

                GameObject CDA_object = Instantiate(CardDeckAnim, CDA, Quaternion.identity);
                CDA_object.transform.SetParent(cardDeckPoint);


                KartaINF kartaINF = Instantiate(kartaINFPref, pozice, Quaternion.identity);
                kartaINF.transform.SetParent(CDA_object.transform);

                kartyBoj.Add(kartaINF);
                AKarten.Add(kartaINF);
                // kartyBoj.Clear();

                kartaINF.NapisStaty(data.startZivoty, data.utok, data.vykriti, data.obrana, data.obranaPosk, data.level,
                    data.MR_OB_Tree1, data.MR_OB_Tree2, data.VR_OB_Tree1, data.VR_OB_Tree2, data.AR_OB_Tree1, data.HL_OB_Tree1, data.JmenoKarty);



                switch (data.MR_OB_Tree1)
                {
                    case 0:
                        kartaINF.trida = "Pesti";
                        kartaINF.zbran = "pest";
                        break;
                    case 1:
                        kartaINF.trida = "Jednorucka";
                        kartaINF.zbran = "dagger_j";
                        kartaINF.zbran_mala.sprite = kartaVybavaData.mala_dyka[data.MR_OB_Tree2];
                        break;
                    case 2:
                        kartaINF.trida = "Jednorucka";
                        kartaINF.zbran = "mec_j";
                        kartaINF.zbran_mala.sprite = kartaVybavaData.mala_mec[data.MR_OB_Tree2];

                        break;
                    case 3:
                        kartaINF.trida = "Jednorucka";
                        kartaINF.zbran = "sekPal_j";
                        kartaINF.zbran_mala.sprite = kartaVybavaData.mala_SekPal[data.MR_OB_Tree2];
                        break;

                }
                switch (data.VR_OB_Tree1)
                {
                    case 5:
                        kartaINF.trida2 = "Luk";
                        kartaINF.zbran2 = "luk_l";
                        kartaINF.zbran_Velka.sprite = kartaVybavaData.vel_luk[data.VR_OB_Tree2];
                        break;
                    case 6:
                        kartaINF.trida2 = "Dvourucka";
                        kartaINF.zbran2 = "tyc_d";
                        kartaINF.zbran_Velka.sprite = kartaVybavaData.vel_polearm[data.VR_OB_Tree2];
                        break;
                    case 7:
                        kartaINF.trida2 = "Dvourucka";
                        kartaINF.zbran2 = "rem_d";
                        kartaINF.zbran_Velka.sprite = kartaVybavaData.vel_remdich[data.VR_OB_Tree2];
                        break;
                    case 8:
                        kartaINF.trida2 = "Dvourucka";
                        kartaINF.zbran2 = "mec_d";
                        kartaINF.zbran_Velka.sprite = kartaVybavaData.vel_mec[data.VR_OB_Tree2];
                        break;

                }
                if (data.HL_OB_Tree1 != 999)
                {
                    kartaINF.helma.sprite = kartaVybavaData.helma[data.HL_OB_Tree1];
                }


                if (data.AR_OB_Tree1 != 999)
                {
                    kartaINF.brneni.sprite = kartaVybavaData.brneni[data.AR_OB_Tree1];
                }



            }
            else { Debug.LogError("Path not found in " + path + i); }
        }

        // karty.Clear();
    }

    public List<KartaINF> GetMojeKarty()
    {
        return AKarten;
    }
}
