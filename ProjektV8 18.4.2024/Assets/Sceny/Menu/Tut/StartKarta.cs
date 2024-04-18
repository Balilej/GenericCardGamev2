using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKarta : MonoBehaviour
{
    public KartaINF kartaINF;
    public GameObject KartaPref;
    public KartaVybavaData kartaVybavaData;
    public SLBojSys slBojSys;
    KartaINF kartaInfToEdit;

    public List<KartaINF> StartTut = new List<KartaINF>();

    public System.Action<float> OnPridLvl;
    public System.Action<float> OnPridMult;
    // Start is called before the first frame update
    void Start()
    {
        slBojSys = GetComponent<SLBojSys>();
        kartaVybavaData = GetComponent<KartaVybavaData>();
        Debug.Log("peipi");
    }

    public void Vytvor()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject VytvorenaKarta = Instantiate(KartaPref);
            kartaINF = VytvorenaKarta.GetComponent<KartaINF>();
            StartTut.Add(kartaINF);
        }
        NapisStats();
    }

    public void NapisStats()
    {

        for (int i = 0; i < StartTut.Count; i++)
        {
            string jmeno = kartaVybavaData.dataJmenaKaret[Random.Range(1, kartaVybavaData.dataJmenaKaret.Length)];
            Debug.Log("kartaVybavaData.dataJmenaKaret.Length: " + jmeno);

            

            int indexToEdit = i;
            kartaInfToEdit = StartTut[indexToEdit].GetComponent<KartaINF>();

            kartaInfToEdit.trida = "Pesti";
            kartaInfToEdit.zbran = "pest";
                
           
            kartaInfToEdit.jmeno.text = jmeno;
            kartaInfToEdit.NapisStaty(50, 10, 5, 2, 2, 1, 0, 0, 0, 0, 0, 0, jmeno);
            SLBojSys.kartyBoj.Add(kartaInfToEdit);
        }
        OnPridLvl.Invoke(100f);
        OnPridMult.Invoke(0.5f);
        slBojSys.KartungSave();
    }
}
