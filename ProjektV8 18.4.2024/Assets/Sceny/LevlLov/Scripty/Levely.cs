using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levely : MonoBehaviour
{
    public static List<LvlBojData> EnemyLvl = new List<LvlBojData>();



    public class LvlBojData
    {
        // Statistiky karty
        public string trida;
        public string zbran;
        public string trida2;
        public string zbran2;
        public float zivoty;
        public float startZivoty;
        public float utok;
        public float vykriti; // Šance na uhnutí - Neubere životy
        public float obrana;  // Šance na obrannu - ubereme ménì životù - ubere trochu životù útoèníkovi
        public float obranaPosk; // Poškození když se hráè brání
        public float level;
        public float levelPerc; // Procenta do dalšího levelu

        // Obrazky
        //Mala ruka
        public int MR_OB_Tree1;
        public int MR_OB_Tree2;
        //Velka ruka
        public int VR_OB_Tree1;
        public int VR_OB_Tree2;
        //Brneni
        public int AR_OB_Tree1;

        //Helma
        public int HL_OB_Tree1;

        //SaveLoad promeny
        public string jmenoKarty;

    }

    //  LvlBojData Lvl1Boj2 = new LvlBojData
    //  {
    //    trida = "neco",
    //    zbran = "neco",
    //    trida2 = "neco",
    //    zbran2 = "neco",
    //    zivoty = 0,
    //    startZivoty = 0,
    //    utok = 0,
    //    vykriti = 0,
    //    obrana = 0,
    //    obranaPosk = 0,
    //    level = 0,
    //    levelPerc = 0,
    //    MR_OB_Tree1 = 0,
    //    MR_OB_Tree2 = 0,
    //    VR_OB_Tree1 = 0,
    //    VR_OB_Tree2 = 0,
    //    AR_OB_Tree1 = 999,
    //    HL_OB_Tree1 = 0,
    //    jmenoKarty = "neco"
    // };


    public void Btn_Lvl1()
    {
        
        EnemyLvl.Clear();

        //LEVEL 1 -  HOTOVY
        LvlBojData Lvl1Boj1 = new LvlBojData
        {
            trida = "Pesti",
            zbran = "pest",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 10,
            startZivoty = 10,
            utok = 3.2f,
            vykriti = 0,
            obrana = 4,
            obranaPosk = 4,
            level = 1,
            levelPerc = 0.1f,
            MR_OB_Tree1 = 0,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Bion"
        };
        LvlBojData Lvl1Boj2 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "dagger_j",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 10,
            startZivoty = 10,
            utok = 6,
            vykriti = 0,
            obrana = 3,
            obranaPosk = 3,
            level = 1,
            levelPerc = 0.15f,
            MR_OB_Tree1 = 1,
            MR_OB_Tree2 = 1,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Damon"
        };
        LvlBojData Lvl1Boj3 = new LvlBojData
        {
            trida = "Pesti",
            zbran = "pest",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 25,
            startZivoty = 25,
            utok = 3,
            vykriti = 0,
            obrana = 2,
            obranaPosk = 2,
            level = 1,
            levelPerc = 0.15f,
            MR_OB_Tree1 = 0,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 1,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Cleon"
        };
        LvlBojData Lvl1Boj4 = new LvlBojData
        {
            trida = "Pesti",
            zbran = "pest",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 10,
            startZivoty = 10,
            utok = 2,
            vykriti = 0,
            obrana = 3,
            obranaPosk = 3,
            level = 1,
            levelPerc = 0.1f,
            MR_OB_Tree1 = 0,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Ariston"
        };

        EnemyLvl.Add(Lvl1Boj1);
        EnemyLvl.Add(Lvl1Boj2);
        EnemyLvl.Add(Lvl1Boj3);
        EnemyLvl.Add(Lvl1Boj4);
        
    }

    public void Btn_Lvl2()
    {

        EnemyLvl.Clear();

        //LEVEL 2 - NENI  HOTOVY

        LvlBojData Lvl2Boj1 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "sekPal_j",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 50,
            startZivoty = 50,
            utok = 7.5f,
            vykriti = 0,
            obrana = 12,
            obranaPosk = 12,
            level = 1,
            levelPerc = 0.75f,
            MR_OB_Tree1 = 3,
            MR_OB_Tree2 = 1,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 3,
            jmenoKarty = "Cassander"
        };
        LvlBojData Lvl2Boj2 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "mec_j",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 67,
            startZivoty = 67,
            utok = 12,
            vykriti = 0,
            obrana = 12,
            obranaPosk = 12,
            level = 1,
            levelPerc = 0.8f,
            MR_OB_Tree1 = 2,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 1,
            HL_OB_Tree1 = 1,
            jmenoKarty = "Pythagoras"
        };
        LvlBojData Lvl2Boj3 = new LvlBojData
        {
            trida = "Pesti",
            zbran = "pest",
            trida2 = "Dvourucka",
            zbran2 = "tyc_d",
            zivoty = 25,
            startZivoty = 25,
            utok = 20,
            vykriti = 0,
            obrana = 1,
            obranaPosk = 1,
            level = 1,
            levelPerc = 0.15f,
            MR_OB_Tree1 = 0,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 6,
            VR_OB_Tree2 = 1,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Solon"
        };
        LvlBojData Lvl2Boj4 = new LvlBojData
        {
            trida = "Pesti",
            zbran = "pest",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 150,
            startZivoty = 150,
            utok = 5,
            vykriti = 0,
            obrana = 15,
            obranaPosk = 15,
            level = 2,
            levelPerc = 0.45f,
            MR_OB_Tree1 = 0,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 1,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Leonidas"
        };
        LvlBojData Lvl2Boj5 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "dagger_j",
            trida2 = "Luk",
            zbran2 = "luk_l",
            zivoty = 12,
            startZivoty = 12,
            utok = 67,
            vykriti = 0,
            obrana = 12,
            obranaPosk = 12,
            level = 1,
            levelPerc = 0.25f,
            MR_OB_Tree1 = 1,
            MR_OB_Tree2 = 3,
            VR_OB_Tree1 = 5,
            VR_OB_Tree2 = 1,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Aeneas"
        };
        // odsad nemam
        LvlBojData Lvl2Boj6 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "sekPal_j",
            trida2 = "Dvourucka",
            zbran2 = "tyc_d",
            zivoty = 120,
            startZivoty = 120,
            utok = 17,
            vykriti = 0,
            obrana = 30,
            obranaPosk = 30,
            level = 2,
            levelPerc = 0.35f,
            MR_OB_Tree1 = 3,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 6,
            VR_OB_Tree2 = 2,
            AR_OB_Tree1 = 0,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Luca"
        };
        LvlBojData Lvl2Boj7 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "dagger_j",
            trida2 = "Dvourucka",
            zbran2 = "tyc_d",
            zivoty = 150,
            startZivoty = 150,
            utok = 25,
            vykriti = 0,
            obrana = 45,
            obranaPosk = 45,
            level = 2,
            levelPerc = 0.57f,
            MR_OB_Tree1 = 1,
            MR_OB_Tree2 = 3,
            VR_OB_Tree1 = 6,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 0,
            HL_OB_Tree1 = 2,
            jmenoKarty = "Dante"
        };
        LvlBojData Lvl2Boj8 = new LvlBojData
        {
            trida = "Pesti",
            zbran = "pest",
            trida2 = "Luk",
            zbran2 = "luk_l",
            zivoty = 30,
            startZivoty = 30,
            utok = 70,
            vykriti = 0,
            obrana = 30,
            obranaPosk = 30,
            level = 2,
            levelPerc = 0.25f,
            MR_OB_Tree1 = 0,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 5,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 0,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Leonardo"
        };

        EnemyLvl.Add(Lvl2Boj1);
        EnemyLvl.Add(Lvl2Boj2);
        EnemyLvl.Add(Lvl2Boj3);
        EnemyLvl.Add(Lvl2Boj4);
        EnemyLvl.Add(Lvl2Boj5);
        EnemyLvl.Add(Lvl2Boj6);
        EnemyLvl.Add(Lvl2Boj7);
        EnemyLvl.Add(Lvl2Boj8);

    }

    public void Btn_LvlBoss1()
    {

        EnemyLvl.Clear();

        

        LvlBojData Lvl2Boj1 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "sekPal_j",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 50,
            startZivoty = 50,
            utok = 7.5f,
            vykriti = 0,
            obrana = 12,
            obranaPosk = 12,
            level = 1,
            levelPerc = 0.75f,
            MR_OB_Tree1 = 3,
            MR_OB_Tree2 = 1,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 3,
            jmenoKarty = "Cassander"
        };
        LvlBojData Lvl2Boj2 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "mec_j",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 67,
            startZivoty = 67,
            utok = 12,
            vykriti = 0,
            obrana = 12,
            obranaPosk = 12,
            level = 1,
            levelPerc = 0.8f,
            MR_OB_Tree1 = 2,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 1,
            HL_OB_Tree1 = 1,
            jmenoKarty = "Pythagoras"
        };
        LvlBojData Lvl2Boj3 = new LvlBojData
        {
            trida = "Pesti",
            zbran = "pest",
            trida2 = "Dvourucka",
            zbran2 = "tyc_d",
            zivoty = 25,
            startZivoty = 25,
            utok = 20,
            vykriti = 0,
            obrana = 1,
            obranaPosk = 1,
            level = 1,
            levelPerc = 0.15f,
            MR_OB_Tree1 = 0,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 6,
            VR_OB_Tree2 = 1,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Solon"
        };
        LvlBojData Lvl2Boj4 = new LvlBojData
        {
            trida = "Pesti",
            zbran = "pest",
            trida2 = "Pesti",
            zbran2 = "pest",
            zivoty = 150,
            startZivoty = 150,
            utok = 5,
            vykriti = 0,
            obrana = 15,
            obranaPosk = 15,
            level = 2,
            levelPerc = 0.45f,
            MR_OB_Tree1 = 0,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 0,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 1,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Leonidas"
        };
        LvlBojData Lvl2Boj5 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "dagger_j",
            trida2 = "Luk",
            zbran2 = "luk_l",
            zivoty = 12,
            startZivoty = 12,
            utok = 67,
            vykriti = 0,
            obrana = 12,
            obranaPosk = 12,
            level = 1,
            levelPerc = 0.25f,
            MR_OB_Tree1 = 1,
            MR_OB_Tree2 = 3,
            VR_OB_Tree1 = 5,
            VR_OB_Tree2 = 1,
            AR_OB_Tree1 = 999,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Aeneas"
        };
        // odsad nemam
        LvlBojData Lvl2Boj6 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "sekPal_j",
            trida2 = "Dvourucka",
            zbran2 = "tyc_d",
            zivoty = 120,
            startZivoty = 120,
            utok = 17,
            vykriti = 0,
            obrana = 30,
            obranaPosk = 30,
            level = 2,
            levelPerc = 0.35f,
            MR_OB_Tree1 = 3,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 6,
            VR_OB_Tree2 = 2,
            AR_OB_Tree1 = 0,
            HL_OB_Tree1 = 0,
            jmenoKarty = "Luca"
        };
        LvlBojData Lvl2Boj7 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "dagger_j",
            trida2 = "Dvourucka",
            zbran2 = "tyc_d",
            zivoty = 150,
            startZivoty = 150,
            utok = 25,
            vykriti = 0,
            obrana = 45,
            obranaPosk = 45,
            level = 2,
            levelPerc = 0.57f,
            MR_OB_Tree1 = 1,
            MR_OB_Tree2 = 3,
            VR_OB_Tree1 = 6,
            VR_OB_Tree2 = 0,
            AR_OB_Tree1 = 0,
            HL_OB_Tree1 = 2,
            jmenoKarty = "Dante"
        };
        LvlBojData Lvl2Boj8 = new LvlBojData
        {
            trida = "Jednorucka",
            zbran = "mec_j",
            trida2 = "Dvourucka",
            zbran2 = "tyc_d",
            zivoty = 1500,
            startZivoty = 1500,
            utok = 250,
            vykriti = 0,
            obrana = 50,
            obranaPosk = 60,
            level = 10,
            levelPerc = 0.75f,
            MR_OB_Tree1 = 2,
            MR_OB_Tree2 = 0,
            VR_OB_Tree1 = 6,
            VR_OB_Tree2 = 1,
            AR_OB_Tree1 = 1,
            HL_OB_Tree1 = 3,
            jmenoKarty = "Agathos Kryos"
        };

        EnemyLvl.Add(Lvl2Boj1);
        EnemyLvl.Add(Lvl2Boj2);
        EnemyLvl.Add(Lvl2Boj3);
        EnemyLvl.Add(Lvl2Boj4);
        EnemyLvl.Add(Lvl2Boj5);
        EnemyLvl.Add(Lvl2Boj6);
        EnemyLvl.Add(Lvl2Boj7);
        EnemyLvl.Add(Lvl2Boj8);

    }

}

