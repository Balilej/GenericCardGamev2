using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public class SaveCompSystem : MonoBehaviour
{
    [SerializeField] KartaVybINF kartaVybPrefab;

    KartaVybavaDataObchod kartaVybavaData;
    public Transform cardDeckPoint;

    public static List<KartaVybINF> karty = new List<KartaVybINF>();
    const string OBCHOD_KARTA_SUB = "/KartyObchod";
    const string OBCHOD_KARTA_COUNT_SUB = "/KartyObchod.count";

    public int PKrow = 1;

    private void Start()
    {
        kartaVybavaData = GameObject.Find("EventKamarat").GetComponent<KartaVybavaDataObchod>();
    }
    private void OnApplicationQuit()
    {
        KartungSave();
    }
    
    public void KartungSave()
   {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + OBCHOD_KARTA_SUB;
        string countPath = Application.persistentDataPath + OBCHOD_KARTA_COUNT_SUB;

        FileStream countStream = new FileStream(countPath, FileMode.Create);
        formatter.Serialize(countStream, karty.Count);
        countStream.Close();

        for (int i = 0; i < karty.Count; i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            KartaSaveComp data = new KartaSaveComp(karty[i]);
            formatter.Serialize(stream, data);
            stream.Close();
        }
       
        karty.Clear(); //smaz kdyztak
      
   }

    public GameObject CardDeckAnim;
    Vector3 CDA = new Vector3(0, 0, 0);

    public void KartungLoad()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + OBCHOD_KARTA_SUB;
        string countPath = Application.persistentDataPath + OBCHOD_KARTA_COUNT_SUB;
        int kartyPocet = 0;

        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            kartyPocet = (int)formatter.Deserialize(countStream);
            countStream.Close(); 
        }
        else { Debug.LogError("Path not found in " + countPath); }

        int row = 0;
        int yPos = 3;
        for (int i = 0; i < kartyPocet; i++)
        {
            if(File.Exists(path + i))
            {
                if(row == 6)
                {
                    yPos = yPos - 10;
                    row = 0;
                    PKrow++;
                }
                 FileStream stream = new FileStream(path + i, FileMode.Open);
                KartaSaveComp data = formatter.Deserialize(stream) as KartaSaveComp;

                stream.Close();

                Vector3 pozice = new Vector3(-5.8f+row*4, yPos, 20);
                row++;

                // CARD_DECK_ANIM
                
               GameObject CDA_object = Instantiate(CardDeckAnim, CDA, Quaternion.identity);
                CDA_object.transform.SetParent(cardDeckPoint);


                KartaVybINF kartavyb = Instantiate(kartaVybPrefab, pozice, Quaternion.identity);

                kartavyb.transform.SetParent(CDA_object.transform);


                Canvas canv = kartavyb.GetComponent<Canvas>();
                canv.sortingOrder = i+1;
               karty.Add(kartavyb);
               // karty.Clear();

                kartavyb.NapisStaty(data.zivoty, data.utok, data.vykriti, data.obrana, data.obranaPosk, data.level, data.obrazek_Tree1, data.obrazek_Tree2);
                       
                switch (data.obrazek_Tree1)
                {
                            case 0:
                                kartavyb.zbroj.sprite = kartaVybavaData.helma[data.obrazek_Tree2];
                                kartavyb.trida = "Armor";
                                kartavyb.zbran = "helma";
                                break;
                            case 1:
                                kartavyb.zbroj.sprite = kartaVybavaData.brneni[data.obrazek_Tree2];
                                kartavyb.trida = "Armor";
                                kartavyb.zbran = "brneni";
                                break;

                            case 2:
                        kartavyb.zbroj.sprite = kartaVybavaData.mala_dyka[data.obrazek_Tree2];
                        kartavyb.trida = "Jednorucka";
                        kartavyb.zbran = "dagger_j";
                                break;
                            case 3:
                        kartavyb.zbroj.sprite = kartaVybavaData.mala_mec[data.obrazek_Tree2];
                        kartavyb.trida = "Jednorucka";
                        kartavyb.zbran = "mec_j";
                                break;
                            case 4:
                        kartavyb.zbroj.sprite = kartaVybavaData.mala_SekPal[data.obrazek_Tree2];
                        kartavyb.trida = "Jednorucka";
                        kartavyb.zbran = "sekPal_j";
                                break;
                            case 5:
                        kartavyb.zbroj.sprite = kartaVybavaData.vel_luk[data.obrazek_Tree2];
                        kartavyb.trida = "Luk";
                        kartavyb.zbran = "luk_l";
                                break;
                            case 6:
                        kartavyb.zbroj.sprite = kartaVybavaData.vel_polearm[data.obrazek_Tree2];
                        kartavyb.trida = "Dvourucka";
                        kartavyb.zbran = "tyc_d";
                                break;
                            case 7:
                        kartavyb.zbroj.sprite = kartaVybavaData.vel_remdich[data.obrazek_Tree2];
                        kartavyb.trida = "Dvourucka";
                        kartavyb.zbran = "rem_d";
                                break;
                            case 8:
                        kartavyb.zbroj.sprite = kartaVybavaData.vel_mec[data.obrazek_Tree2];
                        kartavyb.trida = "Dvourucka";
                        kartavyb.zbran = "mec_d";
                                break;
                }
                       

               
            }
            else { Debug.LogError("Path not found in " + path + i); }
        }
        
        // karty.Clear();

    }

    public void KartungLoadObchod()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + OBCHOD_KARTA_SUB;
        string countPath = Application.persistentDataPath + OBCHOD_KARTA_COUNT_SUB;
        int kartyPocet = 0;

        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            kartyPocet = (int)formatter.Deserialize(countStream);
            countStream.Close();
        }
        else { Debug.LogError("Path not found in " + countPath); }

        
        for (int i = 0; i < kartyPocet; i++)
        {
            if (File.Exists(path + i))
            {
                
                FileStream stream = new FileStream(path + i, FileMode.Open);
                KartaSaveComp data = formatter.Deserialize(stream) as KartaSaveComp;

                stream.Close();

                Vector3 pozice = new Vector3(-30, 0, 0);


                KartaVybINF kartavyb = Instantiate(kartaVybPrefab, pozice, Quaternion.identity);


              
                karty.Add(kartavyb);
                // karty.Clear();

                kartavyb.NapisStaty(data.zivoty, data.utok, data.vykriti, data.obrana, data.obranaPosk, data.level, data.obrazek_Tree1, data.obrazek_Tree2);



            }
            else { Debug.LogError("Path not found in " + path + i); }
        }

        // karty.Clear();

    }

}
