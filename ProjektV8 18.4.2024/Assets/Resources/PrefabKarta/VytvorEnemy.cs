using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VytvorEnemy : MonoBehaviour
{
    public KartaINF kartaINF;
    public GameObject KartaPref;
    KartaVybavaData kartaVybavaData;

    public List<KartaINF> Enemaci = new List<KartaINF>();

    KartaINF kartaInfToEdit;

    public int pocetEnemy;
    public System.Func<float> OnZiskejMult;
    // Start is called before the first frame update
    void Start()
    {
        kartaVybavaData = GetComponent<KartaVybavaData>();

        StartCoroutine(WaitBojovniky());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitBojovniky()
    {
        yield return new WaitForSeconds(1);
        VytvorKartu();
    }
    public void VytvorKartu()
    {
        for (int i = 0; i < pocetEnemy; i++)
        {
            GameObject VytvorenaKarta = Instantiate(KartaPref);
            kartaINF = VytvorenaKarta.GetComponent<KartaINF>();
            Enemaci.Add(kartaINF);
        }
        NapisStats();
    }

    public int zivoty;
    public int lvl;
     int[] UO_stats = new int[4];

    public void NapisStats()
    {
        float mult = OnZiskejMult.Invoke();
        for(int i = 0; i < Enemaci.Count; i++)
        {
            string jmeno = kartaVybavaData.dataJmenaKaret[Random.Range(1, kartaVybavaData.dataJmenaKaret.Length)];
            Debug.Log("kartaVybavaData.dataJmenaKaret.Length: " + jmeno);
            
            lvl = (int)(Random.Range(1, 5)* mult);
            zivoty = (int)(lvl * Random.Range(10, 100) * mult * mult);
           // zivoty = (int)(Mathf.Pow(lvl * Random.Range(10, 100), mult));
            for (int y = 0; y < UO_stats.Length - 1; y++)
            {
                UO_stats[i] = (int)(lvl * Random.Range(5, 25) * mult * mult);
            }
           
            int indexToEdit = i;
            kartaInfToEdit = Enemaci[indexToEdit].GetComponent<KartaINF>();
            
            // obrazky
            int randMalaRuka = Random.Range(0, 4);
            int randMRSprite = 0;
            switch (randMalaRuka)
            {
                case 0:
                    kartaINF.trida = "Pesti";
                    kartaINF.zbran = "pest";
                    break;
                case 1:
                    kartaInfToEdit.trida = "Jednorucka";
                    kartaInfToEdit.zbran = "dagger_j";
                    randMRSprite = Random.Range(0, kartaVybavaData.mala_dyka.Length);
                    kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_dyka[randMRSprite];
                    break;
                case 2:
                    kartaInfToEdit.trida = "Jednorucka";
                    kartaInfToEdit.zbran = "mec_j";
                    randMRSprite = Random.Range(0, kartaVybavaData.mala_mec.Length);
                    kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_mec[randMRSprite];

                    break;
                case 3:
                    kartaInfToEdit.trida = "Jednorucka";
                    kartaInfToEdit.zbran = "sekPal_j";
                    randMRSprite = Random.Range(0, kartaVybavaData.mala_SekPal.Length);
                    kartaInfToEdit.zbran_mala.sprite = kartaVybavaData.mala_SekPal[randMRSprite];
                    break;

            }
            int randVelkaRuka = Random.Range(0, 5);
            int randVRSSprite = 0;
            switch (randVelkaRuka)
            {
                case 0:
                    kartaINF.trida = "Pesti";
                    kartaINF.zbran = "pest";
                    break;
                case 1:
                    kartaInfToEdit.trida = "Luk";
                    kartaInfToEdit.zbran = "luk_l";
                    randVRSSprite = Random.Range(0, kartaVybavaData.vel_luk.Length);
                    kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_luk[randVRSSprite];
                    break;
                case 2:
                    kartaInfToEdit.trida = "Dvourucka";
                    kartaInfToEdit.zbran = "mec_d";
                    randVRSSprite = Random.Range(0, kartaVybavaData.vel_mec.Length);
                    kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_mec[randVRSSprite];

                    break;
                case 3:
                    kartaInfToEdit.trida = "Dvourucka";
                    kartaInfToEdit.zbran = "tyc_d";
                    randVRSSprite = Random.Range(0, kartaVybavaData.vel_polearm.Length);
                    kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_polearm[randVRSSprite];
                    break;
                case 4:
                    kartaInfToEdit.trida = "Dvourucka";
                    kartaInfToEdit.zbran = "rem_d";
                    randVRSSprite = Random.Range(0, kartaVybavaData.vel_remdich.Length);
                    kartaInfToEdit.zbran_Velka.sprite = kartaVybavaData.vel_remdich[randVRSSprite];
                    break;

            }
            int randHelma = Random.Range(0, kartaVybavaData.helma.Length);
            kartaInfToEdit.helma.sprite = kartaVybavaData.helma[randHelma];
            int randbrneni = Random.Range(0, kartaVybavaData.brneni.Length);
            kartaInfToEdit.brneni.sprite = kartaVybavaData.brneni[randbrneni];
   
            kartaInfToEdit.jmeno.text = jmeno;
            kartaInfToEdit.NapisStaty(zivoty, UO_stats[0], UO_stats[1], UO_stats[2], UO_stats[3], lvl, randMalaRuka, randMRSprite, randVelkaRuka, randVRSSprite, randbrneni, randHelma, jmeno);

        }
    }

    public List<KartaINF> GetEnemy()
    {
        return Enemaci;
    }
}
