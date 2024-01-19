using UnityEngine;

[System.Serializable]
public class KartaSaveComp 
{

    public float zivoty;
    public float startZivoty;
    public float utok;
    public float vykriti; // Šance na uhnutí - Neubere životy
    public float obrana;  // Šance na obrannu - ubereme ménì životù - ubere trochu životù útoèníkovi
    public float obranaPosk; // Poškození když se hráè brání
    public float level;
    public float levelPerc; // Procenta do dalšího levelu
    public int obrazek_Tree1;
    public int obrazek_Tree2;

    public KartaSaveComp(KartaVybINF kartaVybINF)
    {
        zivoty = kartaVybINF.zivoty;
        startZivoty = kartaVybINF.startZivoty;
        utok = kartaVybINF.utok;
        vykriti = kartaVybINF.vykriti;
        obrana = kartaVybINF.obrana;
        obranaPosk = kartaVybINF.obranaPosk;
        level = kartaVybINF.level;
        levelPerc = kartaVybINF.levelPerc;
        obrazek_Tree1 = kartaVybINF.obrazek_Tree1;
        obrazek_Tree2 = kartaVybINF.obrazek_Tree2;
    }
}
