using UnityEngine;

[System.Serializable]
public class KartaSaveComp 
{

    public float zivoty;
    public float startZivoty;
    public float utok;
    public float vykriti; // �ance na uhnut� - Neubere �ivoty
    public float obrana;  // �ance na obrannu - ubereme m�n� �ivot� - ubere trochu �ivot� �to�n�kovi
    public float obranaPosk; // Po�kozen� kdy� se hr�� br�n�
    public float level;
    public float levelPerc; // Procenta do dal��ho levelu
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
