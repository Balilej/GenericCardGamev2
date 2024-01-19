
using UnityEngine;

[System.Serializable]
public class SaveBojSer 
{
    public string trida;
    public string zbran;
    public float zivoty;
    public float startZivoty;
    public float utok;
    public float vykriti; 
    public float obrana;  
    public float obranaPosk; 
    public float level;
    public float levelPerc;

    // Obrazky
    //Mala ruka
    public int MR_OB_Tree1;
    public int MR_OB_Tree2;
    //Velka ruka
    public int VR_OB_Tree1;
    public int VR_OB_Tree2;
    //Brneni
    public int AR_OB_Tree1;
    public int AR_OB_Tree2;
    //Helma
    public int HL_OB_Tree1;
    public int HL_OB_Tree2;

    public string JmenoKarty;

    public SaveBojSer(KartaINF kartaINF)
    {
        trida = kartaINF.trida;
        zbran = kartaINF.zbran;
        zivoty = kartaINF.zivoty;
        startZivoty = kartaINF.startZivoty;
        utok = kartaINF.utok;
        vykriti = kartaINF.vykriti;
        obrana = kartaINF.obrana;
        obranaPosk = kartaINF.obranaPosk;
        level = kartaINF.level;
        levelPerc = kartaINF.levelPerc;

        // Obrazky
        //Mala ruka
        MR_OB_Tree1 = kartaINF.MR_OB_Tree1;
        MR_OB_Tree2 = kartaINF.MR_OB_Tree2;
        //Velka ruka
        VR_OB_Tree1 = kartaINF.VR_OB_Tree1;
        VR_OB_Tree2 = kartaINF.VR_OB_Tree2;
        //Brneni
        AR_OB_Tree1 = kartaINF.AR_OB_Tree1;
        //Helma
        HL_OB_Tree1 = kartaINF.HL_OB_Tree1;

        JmenoKarty = kartaINF.jmenoKarty;
    }
}
