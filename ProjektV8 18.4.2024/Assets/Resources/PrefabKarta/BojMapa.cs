using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BojMapa : MonoBehaviour
{
    public string trida;
    public string druhZbrane_PK; // PK - polozena karta
    public string druhZbrane_EK; // EK - karta protivnika
    public float utokPlus;
    public float rychlostPLus;
    public float obranaPlus;
    public float[] DataBojMapa;
    //Nepoužívanej list se všemi daty
    readonly List<(string, float, float, float)> BojData = new List<(string, float, float, float)>
        {

        // pest
            //Jednoruèka "_j"
            ("pest-pest", 0f, 0f, 0f),
            ("pest-mec_j", -0.25f, 0.5f, -1f),
            ("pest-dagger_j", -0.25f, 0f, 3f),
            ("pest-sekPal_j", -1.75f, 1f, -0.25f),
            ("pest-rem_j", -1.5f, 1f, -1f),
            //Dvouruèka "_d"
            ("pest-mec_d", -0.5f, 0.75f, -2f),
            ("pest-sekPal_d", -2.5f, 0.5f, -0.5f),
            ("pest-tyc_d",-3f, 1.45f, -5f),
            ("pest-rem_d", -1.25f, 1.2f, -2f),
            //Luk "_l"
            ("pest-luk_l", -3f, 0, -5f),
            ("pest-kus_l", -5f, 0.5f, -5f),
            //Jezdectvo "_c"
            ("pest-mec_c", -0.25f, 2.5f, -5f),
            ("pest-sekPal_c", -1.75f, 1.5f, -5f),
            ("pest-tyc_c", -3f, 2f, -5f),
            ("pest-rem_c", -2f, 1.3f, -5f),

          //footman - Jednoruèka
          // mec
            //Jednoruèka "_j"
            ("mec_j-pest", 0.25f, -0.5f, 1f),
            ("mec_j-mec_j", 0, 0, 0),
            ("mec_j-dagger_j", 1.5f, -2f, -2.5f),
            ("mec_j-sekPal_j", -1.25f, 0.5f, 1f),
            ("mec_j-rem_j", -1.75f, 0.75f, -3f),
            //Dvouruèka "_d"
            ("mec_j-mec_d", -0.5f, 0.25f, -2f),
            ("mec_j-sekPal_d", -2.5f, 0.25f, 0.5f),
            ("mec_j-tyc_d", -3f, 1.25f, -2f),
            ("mec_j-rem_d", -2.75f, 1.5f, -1f),
            //Luk "_l"
            ("mec_j-luk_l", -2f, 0, 2f),
            ("mec_j-kus_l", -3f, 0.75f, 3f),
            //Jezdectvo "_c"
            ("mec_j-mec_c", 2f, 1f, 2f),
            ("mec_j-sekPal_c", 3f, 1.5f, 1f),
            ("mec_j-tyc_c", -4.5f, 3f, 1f),
            ("mec_j-rem_c", -0.25f, 1.5f, 3f),

         //dagger
             //Jednoruèka "_j"
            ("dagger_j-pest", 0.25f, 0f, -3f),
            ("dagger_j-mec_j", -1.5f, 2f, 2.5f),
            ("dagger_j-dagger_j", 0, 0, 0),
            ("dagger_j-sekPal_j", -2f, 1.5f, 2f),
            ("dagger_j-rem_j", -2.75f, 0.5f, 3f),
            //Dvouruèka "_d"
            ("dagger_j-mec_d", -1.5f, 1.5f, 1.5f),
            ("dagger_j-sekPal_d", -2.5f, 3f, 1.5f),
            ("dagger_j-tyc_d", -2.75f, 0.25f, -5f),
            ("dagger_j-rem_d", -3f, 1f, 3f),
            //Luk "_l"
            ("dagger_j-luk_l", -3f, -1f, 1f),
            ("dagger_j-kus_l", -5f, 2f, 1f),
            //Jezdectvo "_c"
            ("dagger_j-mec_c", 0.5f, 3f, -2f),
            ("dagger_j-sekPal_c", -2f, 3f, -2f),
            ("dagger_j-tyc_c", -3f, 1f, -2f),
            ("dagger_j-rem_c", -0.25f, 1.2f, -2f),

         //sekPal
            //Jednoruèka "_j"
            ("sekPal_j-pest", 1.75f, -1f, 0.25f),
            ("sekPal_j-mec_j", 1.25f, -0.5f, -1f),
            ("sekPal_j-dagger_j", 2f, -1.5f, -2f),
            ("sekPal_j-sekPal_j", 0, 0, 0),
            ("sekPal_j-rem_j", 2f, -2f, 1f),
            //Dvouruèka "_d"
            ("sekPal_j-mec_d", 0.75f, -0.5f, -1f),
            ("sekPal_j-sekPal_d", -1f, 1f, -1.5f),
            ("sekPal_j-tyc_d", -2f, 1.5f, -3f),
            ("sekPal_j-rem_d", -1.25f, -0.5f, 2f),
            //Luk "_l"
            ("sekPal_j-luk_l", 0.25f, -1.5f, 2f),
            ("sekPal_j-kus_l", -1f, 0.5f, 1.5f),
            //Jezdectvo "_c"
            ("sekPal_j-mec_c", 3f, 0.5f, 2f),
            ("sekPal_j-sekPal_c", 0, 3f, 2f),
            ("sekPal_j-tyc_c", -0.25f, 2.5f, -1f),
            ("sekPal_j-rem_c", 2f, -0.5f, 0.5f),

        //rem
            //Jednoruèka "_j"
            ("rem_j-pest", 1.5f, -1f, 1f),
            ("rem_j-mec_j", 1.75f, -0.75f, 3f),
            ("rem_j-dagger_j", 2.75f, -0.5f, -3f),
            ("rem_j-sekPal_j", -2f, 2f, -1f),
            ("rem_j-rem_j", 0, 0, 0),
            //Dvouruèka "_d"
            ("rem_j-mec_d", -1f, 0.5f, -2f),
            ("rem_j-sekPal_d", -2f, 0.5f, -3f),
            ("rem_j-tyc_d", 0, 0, 0),
            ("rem_j-rem_d", -3f, -3f, 1f),
            //Luk "_l"
            ("rem_j-luk_l", -1.5f, 2f, 3f),
            ("rem_j-kus_l", -5f, 3f, 3f),
            //Jezdectvo "_c"
            ("rem_j-mec_c", 1.25f, 1.25f, 1f),
            ("rem_j-sekPal_c", 1.25f, 1.5f, 1f),
            ("rem_j-tyc_c", -1f, 3f, -1f),
            ("rem_j-rem_c", 5f, 5f, 2f),


        //footman - Dvouruèka
        // mec
            //Jednoruèka "_j"
            ("mec_d-pest", 0.5f, -0.75f, 2f),
            ("mec_d-mec_j", 0.5f, -0.25f, 2f),
            ("mec_d-dagger_j", 1.5f, -1.5f, -1.5f),
            ("mec_d-sekPal_j", -0.75f, 0.5f, 1f),
            ("mec_d-rem_j", 1f, -0.5f, 2f),
            //Dvouruèka "_d"
            ("mec_d-mec_d", 0, 0, 0),
            ("mec_d-sekPal_d", -1.25f, 0, -1f),
            ("mec_d-tyc_d", -2f, -2.5f, -1.5f),
            ("mec_d-rem_d", 1.5f, -3f, 1f),
            //Luk "_l"
            ("mec_d-luk_l", -2.25f, -3f, 2f),
            ("mec_d-kus_l", -3.5f, 2f, 2f),
            //Jezdectvo "_c"
            ("mec_d-mec_c", 2f, 2f, 2f),
            ("mec_d-sekPal_c", 4f, 1.5f, 2.5f),
            ("mec_d-tyc_c", -4.5f, 3f, -1f),
            ("mec_d-rem_c", 1.5f, 3f, -1f),

        // sekPal
            //Jednoruèka "_j"
            ("sekPal_d-pest", 2.5f, -0.5f, 0.5f),
            ("sekPal_d-mec_j", 2.5f, -0.25f, -0.5f),
            ("sekPal_d-dagger_j", 2.5f, -3f, -1.5f),
            ("sekPal_d-sekPal_j", 1f, -1f, 1.5f),
            ("sekPal_d-rem_j", 2f, -0.5f, 3f),
            //Dvouruèka "_d"
            ("sekPal_d-mec_d", 1.25f, 0, 1f),
            ("sekPal_d-sekPal_d", 0, 0, 0),
            ("sekPal_d-tyc_d", -3f, -1f, 0),
            ("sekPal_d-rem_d", 2f, -1f, 1f),
            //Luk "_l"
            ("sekPal_d-luk_l", 1.5f, -3f, 2f),
            ("sekPal_d-kus_l", -3f, 1.5f, 2f),
            //Jezdectvo "_c"
            ("sekPal_d-mec_c", 4f, 2f, 1f),
            ("sekPal_d-sekPal_c", 3f, 1.5f, 2f),
            ("sekPal_d-tyc_c", -2f, 1.5f, -1f),
            ("sekPal_d-rem_c", 4f, -0.5f, -1f),

        // tyc
            //Jednoruèka "_j"
            ("tyc_d-pest", 3f, -1.45f, 5f),
            ("tyc_d-mec_j", 3f, -1.25f, 2f),
            ("tyc_d-dagger_j", 2.75f, -0.25f, 5f),
            ("tyc_d-sekPal_j", 2f, -1.5f, 3f),
            ("tyc_d-rem_j", 0, 0, 0),
            //Dvouruèka "_d"
            ("tyc_d-mec_d", 2f, 2.5f, 1.5f),
            ("tyc_d-sekPal_d", 3f, 1f, 0),
            ("tyc_d-tyc_d", 0, 0, 0),
            ("tyc_d-rem_d", 2f,2f,3f),
            //Luk "_l"
            ("tyc_d-luk_l", 1.5f,-3f,0.5f),
            ("tyc_d-kus_l", -2.5f,1.5f,1f),
            //Jezdectvo "_c"
            ("tyc_d-mec_c", 5f,3f,3f),
            ("tyc_d-sekPal_c", 3f,4f,3f),
            ("tyc_d-tyc_c", -5f,-2f,1f),
            ("tyc_d-rem_c", -5f,0f,-1f),

        // rem
            //Jednoruèka "_j"
            ("rem_d-pest",  1.25f, -1.2f, 2f),
            ("rem_d-mec_j", 2.75f, -1.5f, 1f),
            ("rem_d-dagger_j", 3f,-1f, -3f),
            ("rem_d-sekPal_j", 1.25f, 0.5f, -2f),
            ("rem_d-rem_j", 3f, 3f, -1f),
            //Dvouruèka "_d"
            ("rem_d-mec_d", -1.5f, 3f, -1f),
            ("rem_d-sekPal_d", -2f, 1f, -1f),
            ("rem_d-tyc_d", -2f,-2f,-3f),
            ("rem_d-rem_d", 0, 0, 0),
            //Luk "_l"
            ("rem_d-luk_l", -2.5f,-2.5f,-1f),
            ("rem_d-kus_l", -4f,3f,-1f),
            //Jezdectvo "_c"
            ("rem_d-mec_c", 3f,-1.75f,1f),
            ("rem_d-sekPal_c", -2.5f,0f,1f),
            ("rem_d-tyc_c", -3f,-1.5f,-1f),
            ("rem_d-rem_c", 5f,2f,3f),


        //Luk
        // luk
            //Jednoruèka "_j"
            ("luk_l-pest", 3f, 0, 5f),
            ("luk_l-mec_j", 2f, 0, -2f),
            ("luk_l-dagger_j", 3f, 1f, -1f),
            ("luk_l-sekPal_j", -0.25f, 1.5f, -2f),
            ("luk_l-rem_j", 1.5f, -2f, -3f),
            //Dvouruèka "_d"
            ("luk_l-mec_d", 2.25f, 3f, -2f),
            ("luk_l-sekPal_d", -1.5f, 3f, -2f),
            ("luk_l-tyc_d", -1.5f, 3f, -0.5f),
            ("luk_l-rem_d", 2.5f,2.5f,1f),
            //Luk "_l"
            ("luk_l-luk_l", 0, 0, 0),
            ("luk_l-kus_l", -2.5f,5f,-5f),
            //Jezdectvo "_c"
            ("luk_l-mec_c", -2.75f,0.5f,-1f),
            ("luk_l-sekPal_c", -3f,0.5f,-2f),
            ("luk_l-tyc_c", -5f,0f,1f),
            ("luk_l-rem_c", -1.5f,-1f,3f),

        // kus
            //Jednoruèka "_j"
            ("kus_l-pest", 5f, -0.5f, 5f),
            ("kus_l-mec_j", 3f, -0.75f, -3f),
            ("kus_l-dagger_j", 5f, -2f, -1f),
            ("kus_l-sekPal_j", 1f, -0.5f, -1.5f),
            ("kus_l-rem_j", 5f, -3f, -3f),
            //Dvouruèka "_d"
            ("kus_l-mec_d", 3.5f, -2f, -2f),
            ("kus_l-sekPal_d", 3f, -1.5f, -2f),
            ("kus_l-tyc_d", 2.5f,-1.5f,-1f),
            ("kus_l-rem_d", 4f,-3f,1f),
            //Luk "_l"
            ("kus_l-luk_l", 2.5f,-5f,5f),
            ("kus_l-kus_l", 0, 0, 0),
            //Jezdectvo "_c"
            ("kus_l-mec_c", -1.75f,1.5f,-1f),
            ("kus_l-sekPal_c", -1f,1.5f,-1f),
            ("kus_l-tyc_c", -3f,-5f,1f),
            ("kus_l-rem_c", -0.5f,-2f,3f),

        //Jezdectvo
        // mec
            //Jednoruèka "_j"
            ("mec_c-pest", 0.25f, -2.5f, 5f),
            ("mec_c-mec_j", -2f, -1f, -2f),
            ("mec_c-dagger_j", -0.5f, -3f, 2f),
            ("mec_c-sekPal_j", -3f, -0.5f, -2f),
            ("mec_c-rem_j", -1.25f, -1.25f, -1f),
            //Dvouruèka "_d"
            ("mec_c-mec_d", -2f, -2f, -2f),
            ("mec_c-sekPal_d", -4f, -2f, -1f),
            ("mec_c-tyc_d", -5f,-3f,-3f),
            ("mec_c-rem_d", -3f,1.75f,-1f),
            //Luk "_l"
            ("mec_c-luk_l", 2.75f,-0.5f,1f),
            ("mec_c-kus_l", 1.75f,-1.5f,1f),
            //Jezdectvo "_c"
            ("mec_c-mec_c", 0, 0, 0),
            ("mec_c-sekPal_c", -2f,0f,1f),
            ("mec_c-tyc_c", -5f,-2f,-3f),
            ("mec_c-rem_c", 5f,-5f,-3f),

        // sekPal
            //Jednoruèka "_j"
            ("sekPal_c-pest", 1.75f, -1.5f, 5f),
            ("sekPal_c-mec_j", -3f, -1.5f, -1f),
            ("sekPal_c-dagger_j", 2f, -3f, 2f),
            ("sekPal_c-sekPal_j", 0, -3f, -2f),
            ("sekPal_c-rem_j", -1.25f, -1.5f, -1f),
            //Dvouruèka "_d"
            ("sekPal_c-mec_d", -4f, -1.5f, -2.5f),
            ("sekPal_c-sekPal_d", -3f, -1.5f, -2f),
            ("sekPal_c-tyc_d", -3f,-4f,-3f),
            ("sekPal_c-rem_d", 2.5f,0f,-1f),
            //Luk "_l"
            ("sekPal_c-luk_l", 3f,-0.5f,2f),
            ("sekPal_c-kus_l", 1f,-1.5f,1f),
            //Jezdectvo "_c"
            ("sekPal_c-mec_c", 2f,0f,-1f),
            ("sekPal_c-sekPal_c", 0, 0, 0),
            ("sekPal_c-tyc_c", 2f,-1f,3f),
            ("sekPal_c-rem_c", 1.5f,-2f,-2f),

        // tyc
            //Jednoruèka "_j"
            ("tyc_c-pest", 3f, -2f, 5f),
            ("tyc_c-mec_j", 4.5f, -3f, -1f),
            ("tyc_c-dagger_j", 3f, -1f, 2f),
            ("tyc_c-sekPal_j", 0.25f, -2.5f, 1f),
            ("tyc_c-rem_j", 1f, -3f, 1f),
            //Dvouruèka "_d"
            ("tyc_c-mec_d", 4.5f, -3f, 1f),
            ("tyc_c-sekPal_d", 2f, -1.5f, 1f),
            ("tyc_c-tyc_d", -5f,2f,-1f),
            ("tyc_c-rem_d", 3f,1.5f,1f),
            //Luk "_l"
            ("tyc_c-luk_l", 5f,0f,-1f),
            ("tyc_c-kus_l", 3f,5f,-1f),
            //Jezdectvo "_c"
            ("tyc_c-mec_c", 5f,2f,3f),
            ("tyc_c-sekPal_c", -2f,1f,-3f),
            ("tyc_c-tyc_c", 0, 0, 0),
            ("tyc_c-rem_c", 2.5f,2f,3f),

        // rem
            //Jednoruèka "_j"
            ("rem_c-pest", 2f, -1.3f, 5f),
            ("rem_c-mec_j", 0.25f, -1.5f, -3f),
            ("rem_c-dagger_j", 0.25f, -1.2f, 2f),
            ("rem_c-sekPal_j", -2f, 0.5f, -0.5f),
            ("rem_c-rem_j", -5f, -5f, -2f),
            //Dvouruèka "_d"
            ("rem_c-mec_d", -1.5f, -3f, 1f),
            ("rem_c-sekPal_d", -4f, 0.5f, 1f),
            ("rem_c-tyc_d", 5f,0f,1f),
            ("rem_c-rem_d", -5f, -2f,-3f),
            //Luk "_l"
            ("rem_c-luk_l", 1.5f,1f,-3f),
            ("rem_c-kus_l", 0.5f,2f,-3f),
            //Jezdectvo "_c"
            ("rem_c-mec_c", -5f,5f,3f),
            ("rem_c-sekPal_c", -1.5f,2f,2f),
            ("rem_c-tyc_c", -2.5f,-2f,-3f),
            ("rem_c-rem_c", 0, 0, 0)
    };
    //POužívané listy
    readonly List<(string, float, float, float)> pest_List = new List<(string, float, float, float)>
        {

        // pest
            //Jednoruèka "_j"
            ("pest-pest", 0f, 0f, 0f),
            ("pest-mec_j", -0.25f, 0.5f, -1f),
            ("pest-dagger_j", -0.25f, 0f, 3f),
            ("pest-sekPal_j", -1.75f, 1f, -0.25f),
            ("pest-rem_j", -1.5f, 1f, -1f),
            //Dvouruèka "_d"
            ("pest-mec_d", -0.5f, 0.75f, -2f),
            ("pest-sekPal_d", -2.5f, 0.5f, -0.5f),
            ("pest-tyc_d",-3f, 1.45f, -5f),
            ("pest-rem_d", -1.25f, 1.2f, -2f),
            //Luk "_l"
            ("pest-luk_l", -3f, 0, -5f),
            ("pest-kus_l", -5f, 0.5f, -5f),
            //Jezdectvo "_c"
            ("pest-mec_c", -0.25f, 2.5f, -5f),
            ("pest-sekPal_c", -1.75f, 1.5f, -5f),
            ("pest-tyc_c", -3f, 2f, -5f),
            ("pest-rem_c", -2f, 1.3f, -5f),

          
    };
    readonly List<(string, float, float, float)> mec_j_List = new List<(string, float, float, float)>
        {
          // mec
            //Jednoruèka "_j"
            ("mec_j-pest", 0.25f, -0.5f, 1f),
            ("mec_j-mec_j", 0, 0, 0),
            ("mec_j-dagger_j", 1.5f, -2f, -2.5f),
            ("mec_j-sekPal_j", -1.25f, 0.5f, 1f),
            ("mec_j-rem_j", -1.75f, 0.75f, -3f),
            //Dvouruèka "_d"
            ("mec_j-mec_d", -0.5f, 0.25f, -2f),
            ("mec_j-sekPal_d", -2.5f, 0.25f, 0.5f),
            ("mec_j-tyc_d", -3f, 1.25f, -2f),
            ("mec_j-rem_d", -2.75f, 1.5f, -1f),
            //Luk "_l"
            ("mec_j-luk_l", -2f, 0, 2f),
            ("mec_j-kus_l", -3f, 0.75f, 3f),
            //Jezdectvo "_c"
            ("mec_j-mec_c", 2f, 1f, 2f),
            ("mec_j-sekPal_c", 3f, 1.5f, 1f),
            ("mec_j-tyc_c", -4.5f, 3f, 1f),
            ("mec_j-rem_c", -0.25f, 1.5f, 3f),

        
    };
    readonly List<(string, float, float, float)> dagger_j_List = new List<(string, float, float, float)>
        {

         //dagger
             //Jednoruèka "_j"
            ("dagger_j-pest", 0.25f, 0f, -3f),
            ("dagger_j-mec_j", -1.5f, 2f, 2.5f),
            ("dagger_j-dagger_j", 0, 0, 0),
            ("dagger_j-sekPal_j", -2f, 1.5f, 2f),
            ("dagger_j-rem_j", -2.75f, 0.5f, 3f),
            //Dvouruèka "_d"
            ("dagger_j-mec_d", -1.5f, 1.5f, 1.5f),
            ("dagger_j-sekPal_d", -2.5f, 3f, 1.5f),
            ("dagger_j-tyc_d", -2.75f, 0.25f, -5f),
            ("dagger_j-rem_d", -3f, 1f, 3f),
            //Luk "_l"
            ("dagger_j-luk_l", -3f, -1f, 1f),
            ("dagger_j-kus_l", -5f, 2f, 1f),
            //Jezdectvo "_c"
            ("dagger_j-mec_c", 0.5f, 3f, -2f),
            ("dagger_j-sekPal_c", -2f, 3f, -2f),
            ("dagger_j-tyc_c", -3f, 1f, -2f),
            ("dagger_j-rem_c", -0.25f, 1.2f, -2f),

        
    };
    readonly List<(string, float, float, float)> sekPal_j_List = new List<(string, float, float, float)>
        {

         //sekPal
            //Jednoruèka "_j"
            ("sekPal_j-pest", 1.75f, -1f, 0.25f),
            ("sekPal_j-mec_j", 1.25f, -0.5f, -1f),
            ("sekPal_j-dagger_j", 2f, -1.5f, -2f),
            ("sekPal_j-sekPal_j", 0, 0, 0),
            ("sekPal_j-rem_j", 2f, -2f, 1f),
            //Dvouruèka "_d"
            ("sekPal_j-mec_d", 0.75f, -0.5f, -1f),
            ("sekPal_j-sekPal_d", -1f, 1f, -1.5f),
            ("sekPal_j-tyc_d", -2f, 1.5f, -3f),
            ("sekPal_j-rem_d", -1.25f, -0.5f, 2f),
            //Luk "_l"
            ("sekPal_j-luk_l", 0.25f, -1.5f, 2f),
            ("sekPal_j-kus_l", -1f, 0.5f, 1.5f),
            //Jezdectvo "_c"
            ("sekPal_j-mec_c", 3f, 0.5f, 2f),
            ("sekPal_j-sekPal_c", 0, 3f, 2f),
            ("sekPal_j-tyc_c", -0.25f, 2.5f, -1f),
            ("sekPal_j-rem_c", 2f, -0.5f, 0.5f),

    };
    readonly List<(string, float, float, float)> rem_j_List = new List<(string, float, float, float)>
        {

        //rem
            //Jednoruèka "_j"
            ("rem_j-pest", 1.5f, -1f, 1f),
            ("rem_j-mec_j", 1.75f, -0.75f, 3f),
            ("rem_j-dagger_j", 2.75f, -0.5f, -3f),
            ("rem_j-sekPal_j", -2f, 2f, -1f),
            ("rem_j-rem_j", 0, 0, 0),
            //Dvouruèka "_d"
            ("rem_j-mec_d", -1f, 0.5f, -2f),
            ("rem_j-sekPal_d", -2f, 0.5f, -3f),
            ("rem_j-tyc_d", 0, 0, 0),
            ("rem_j-rem_d", -3f, -3f, 1f),
            //Luk "_l"
            ("rem_j-luk_l", -1.5f, 2f, 3f),
            ("rem_j-kus_l", -5f, 3f, 3f),
            //Jezdectvo "_c"
            ("rem_j-mec_c", 1.25f, 1.25f, 1f),
            ("rem_j-sekPal_c", 1.25f, 1.5f, 1f),
            ("rem_j-tyc_c", -1f, 3f, -1f),
            ("rem_j-rem_c", 5f, 5f, 2f),

    };
    readonly List<(string, float, float, float)> mec_d_List = new List<(string, float, float, float)>
        {

        // mec
            //Jednoruèka "_j"
            ("mec_d-pest", 0.5f, -0.75f, 2f),
            ("mec_d-mec_j", 0.5f, -0.25f, 2f),
            ("mec_d-dagger_j", 1.5f, -1.5f, -1.5f),
            ("mec_d-sekPal_j", -0.75f, 0.5f, 1f),
            ("mec_d-rem_j", 1f, -0.5f, 2f),
            //Dvouruèka "_d"
            ("mec_d-mec_d", 0, 0, 0),
            ("mec_d-sekPal_d", -1.25f, 0, -1f),
            ("mec_d-tyc_d", -2f, -2.5f, -1.5f),
            ("mec_d-rem_d", 1.5f, -3f, 1f),
            //Luk "_l"
            ("mec_d-luk_l", -2.25f, -3f, 2f),
            ("mec_d-kus_l", -3.5f, 2f, 2f),
            //Jezdectvo "_c"
            ("mec_d-mec_c", 2f, 2f, 2f),
            ("mec_d-sekPal_c", 4f, 1.5f, 2.5f),
            ("mec_d-tyc_c", -4.5f, 3f, -1f),
            ("mec_d-rem_c", 1.5f, 3f, -1f),

    };
    readonly List<(string, float, float, float)> sekPal_d_List = new List<(string, float, float, float)>
        {

        // sekPal
            //Jednoruèka "_j"
            ("sekPal_d-pest", 2.5f, -0.5f, 0.5f),
            ("sekPal_d-mec_j", 2.5f, -0.25f, -0.5f),
            ("sekPal_d-dagger_j", 2.5f, -3f, -1.5f),
            ("sekPal_d-sekPal_j", 1f, -1f, 1.5f),
            ("sekPal_d-rem_j", 2f, -0.5f, 3f),
            //Dvouruèka "_d"
            ("sekPal_d-mec_d", 1.25f, 0, 1f),
            ("sekPal_d-sekPal_d", 0, 0, 0),
            ("sekPal_d-tyc_d", -3f, -1f, 0),
            ("sekPal_d-rem_d", 2f, -1f, 1f),
            //Luk "_l"
            ("sekPal_d-luk_l", 1.5f, -3f, 2f),
            ("sekPal_d-kus_l", -3f, 1.5f, 2f),
            //Jezdectvo "_c"
            ("sekPal_d-mec_c", 4f, 2f, 1f),
            ("sekPal_d-sekPal_c", 3f, 1.5f, 2f),
            ("sekPal_d-tyc_c", -2f, 1.5f, -1f),
            ("sekPal_d-rem_c", 4f, -0.5f, -1f),

    };
    readonly List<(string, float, float, float)> tyc_d_List = new List<(string, float, float, float)>
        {
        // tyc
            //Jednoruèka "_j"
            ("tyc_d-pest", 3f, -1.45f, 5f),
            ("tyc_d-mec_j", 3f, -1.25f, 2f),
            ("tyc_d-dagger_j", 2.75f, -0.25f, 5f),
            ("tyc_d-sekPal_j", 2f, -1.5f, 3f),
            ("tyc_d-rem_j", 0, 0, 0),
            //Dvouruèka "_d"
            ("tyc_d-mec_d", 2f, 2.5f, 1.5f),
            ("tyc_d-sekPal_d", 3f, 1f, 0),
            ("tyc_d-tyc_d", 0, 0, 0),
            ("tyc_d-rem_d", 2f,2f,3f),
            //Luk "_l"
            ("tyc_d-luk_l", 1.5f,-3f,0.5f),
            ("tyc_d-kus_l", -2.5f,1.5f,1f),
            //Jezdectvo "_c"
            ("tyc_d-mec_c", 5f,3f,3f),
            ("tyc_d-sekPal_c", 3f,4f,3f),
            ("tyc_d-tyc_c", -5f,-2f,1f),
            ("tyc_d-rem_c", -5f,0f,-1f),

    };
    readonly List<(string, float, float, float)> rem_d_List = new List<(string, float, float, float)>
        {

        // rem
            //Jednoruèka "_j"
            ("rem_d-pest",  1.25f, -1.2f, 2f),
            ("rem_d-mec_j", 2.75f, -1.5f, 1f),
            ("rem_d-dagger_j", 3f,-1f, -3f),
            ("rem_d-sekPal_j", 1.25f, 0.5f, -2f),
            ("rem_d-rem_j", 3f, 3f, -1f),
            //Dvouruèka "_d"
            ("rem_d-mec_d", -1.5f, 3f, -1f),
            ("rem_d-sekPal_d", -2f, 1f, -1f),
            ("rem_d-tyc_d", -2f,-2f,-3f),
            ("rem_d-rem_d", 0, 0, 0),
            //Luk "_l"
            ("rem_d-luk_l", -2.5f,-2.5f,-1f),
            ("rem_d-kus_l", -4f,3f,-1f),
            //Jezdectvo "_c"
            ("rem_d-mec_c", 3f,-1.75f,1f),
            ("rem_d-sekPal_c", -2.5f,0f,1f),
            ("rem_d-tyc_c", -3f,-1.5f,-1f),
            ("rem_d-rem_c", 5f,2f,3f),

    };
    readonly List<(string, float, float, float)> luk_l_List = new List<(string, float, float, float)>
        {

        // luk
            //Jednoruèka "_j"
            ("luk_l-pest", 3f, 0, 5f),
            ("luk_l-mec_j", 2f, 0, -2f),
            ("luk_l-dagger_j", 3f, 1f, -1f),
            ("luk_l-sekPal_j", -0.25f, 1.5f, -2f),
            ("luk_l-rem_j", 1.5f, -2f, -3f),
            //Dvouruèka "_d"
            ("luk_l-mec_d", 2.25f, 3f, -2f),
            ("luk_l-sekPal_d", -1.5f, 3f, -2f),
            ("luk_l-tyc_d", -1.5f, 3f, -0.5f),
            ("luk_l-rem_d", 2.5f,2.5f,1f),
            //Luk "_l"
            ("luk_l-luk_l", 0, 0, 0),
            ("luk_l-kus_l", -2.5f,5f,-5f),
            //Jezdectvo "_c"
            ("luk_l-mec_c", -2.75f,0.5f,-1f),
            ("luk_l-sekPal_c", -3f,0.5f,-2f),
            ("luk_l-tyc_c", -5f,0f,1f),
            ("luk_l-rem_c", -1.5f,-1f,3f),

    };
    readonly List<(string, float, float, float)> kus_l_List = new List<(string, float, float, float)>
        {

        // kus
            //Jednoruèka "_j"
            ("kus_l-pest", 5f, -0.5f, 5f),
            ("kus_l-mec_j", 3f, -0.75f, -3f),
            ("kus_l-dagger_j", 5f, -2f, -1f),
            ("kus_l-sekPal_j", 1f, -0.5f, -1.5f),
            ("kus_l-rem_j", 5f, -3f, -3f),
            //Dvouruèka "_d"
            ("kus_l-mec_d", 3.5f, -2f, -2f),
            ("kus_l-sekPal_d", 3f, -1.5f, -2f),
            ("kus_l-tyc_d", 2.5f,-1.5f,-1f),
            ("kus_l-rem_d", 4f,-3f,1f),
            //Luk "_l"
            ("kus_l-luk_l", 2.5f,-5f,5f),
            ("kus_l-kus_l", 0, 0, 0),
            //Jezdectvo "_c"
            ("kus_l-mec_c", -1.75f,1.5f,-1f),
            ("kus_l-sekPal_c", -1f,1.5f,-1f),
            ("kus_l-tyc_c", -3f,-5f,1f),
            ("kus_l-rem_c", -0.5f,-2f,3f),

    };
    readonly List<(string, float, float, float)> mec_c_List = new List<(string, float, float, float)>
        {

        // mec
            //Jednoruèka "_j"
            ("mec_c-pest", 0.25f, -2.5f, 5f),
            ("mec_c-mec_j", -2f, -1f, -2f),
            ("mec_c-dagger_j", -0.5f, -3f, 2f),
            ("mec_c-sekPal_j", -3f, -0.5f, -2f),
            ("mec_c-rem_j", -1.25f, -1.25f, -1f),
            //Dvouruèka "_d"
            ("mec_c-mec_d", -2f, -2f, -2f),
            ("mec_c-sekPal_d", -4f, -2f, -1f),
            ("mec_c-tyc_d", -5f,-3f,-3f),
            ("mec_c-rem_d", -3f,1.75f,-1f),
            //Luk "_l"
            ("mec_c-luk_l", 2.75f,-0.5f,1f),
            ("mec_c-kus_l", 1.75f,-1.5f,1f),
            //Jezdectvo "_c"
            ("mec_c-mec_c", 0, 0, 0),
            ("mec_c-sekPal_c", -2f,0f,1f),
            ("mec_c-tyc_c", -5f,-2f,-3f),
            ("mec_c-rem_c", 5f,-5f,-3f),

    };
    readonly List<(string, float, float, float)> sekPal_c_List = new List<(string, float, float, float)>
        {

        // sekPal
            //Jednoruèka "_j"
            ("sekPal_c-pest", 1.75f, -1.5f, 5f),
            ("sekPal_c-mec_j", -3f, -1.5f, -1f),
            ("sekPal_c-dagger_j", 2f, -3f, 2f),
            ("sekPal_c-sekPal_j", 0, -3f, -2f),
            ("sekPal_c-rem_j", -1.25f, -1.5f, -1f),
            //Dvouruèka "_d"
            ("sekPal_c-mec_d", -4f, -1.5f, -2.5f),
            ("sekPal_c-sekPal_d", -3f, -1.5f, -2f),
            ("sekPal_c-tyc_d", -3f,-4f,-3f),
            ("sekPal_c-rem_d", 2.5f,0f,-1f),
            //Luk "_l"
            ("sekPal_c-luk_l", 3f,-0.5f,2f),
            ("sekPal_c-kus_l", 1f,-1.5f,1f),
            //Jezdectvo "_c"
            ("sekPal_c-mec_c", 2f,0f,-1f),
            ("sekPal_c-sekPal_c", 0, 0, 0),
            ("sekPal_c-tyc_c", 2f,-1f,3f),
            ("sekPal_c-rem_c", 1.5f,-2f,-2f),

    };
    readonly List<(string, float, float, float)> tyc_c_List = new List<(string, float, float, float)>
        {

        // tyc
            //Jednoruèka "_j"
            ("tyc_c-pest", 3f, -2f, 5f),
            ("tyc_c-mec_j", 4.5f, -3f, -1f),
            ("tyc_c-dagger_j", 3f, -1f, 2f),
            ("tyc_c-sekPal_j", 0.25f, -2.5f, 1f),
            ("tyc_c-rem_j", 1f, -3f, 1f),
            //Dvouruèka "_d"
            ("tyc_c-mec_d", 4.5f, -3f, 1f),
            ("tyc_c-sekPal_d", 2f, -1.5f, 1f),
            ("tyc_c-tyc_d", -5f,2f,-1f),
            ("tyc_c-rem_d", 3f,1.5f,1f),
            //Luk "_l"
            ("tyc_c-luk_l", 5f,0f,-1f),
            ("tyc_c-kus_l", 3f,5f,-1f),
            //Jezdectvo "_c"
            ("tyc_c-mec_c", 5f,2f,3f),
            ("tyc_c-sekPal_c", -2f,1f,-3f),
            ("tyc_c-tyc_c", 0, 0, 0),
            ("tyc_c-rem_c", 2.5f,2f,3f),

    };
    readonly List<(string, float, float, float)> rem_c_List = new List<(string, float, float, float)>
        {

        // rem
            //Jednoruèka "_j"
            ("rem_c-pest", 2f, -1.3f, 5f),
            ("rem_c-mec_j", 0.25f, -1.5f, -3f),
            ("rem_c-dagger_j", 0.25f, -1.2f, 2f),
            ("rem_c-sekPal_j", -2f, 0.5f, -0.5f),
            ("rem_c-rem_j", -5f, -5f, -2f),
            //Dvouruèka "_d"
            ("rem_c-mec_d", -1.5f, -3f, 1f),
            ("rem_c-sekPal_d", -4f, 0.5f, 1f),
            ("rem_c-tyc_d", 5f,0f,1f),
            ("rem_c-rem_d", -5f, -2f,-3f),
            //Luk "_l"
            ("rem_c-luk_l", 1.5f,1f,-3f),
            ("rem_c-kus_l", 0.5f,2f,-3f),
            //Jezdectvo "_c"
            ("rem_c-mec_c", -5f,5f,3f),
            ("rem_c-sekPal_c", -1.5f,2f,2f),
            ("rem_c-tyc_c", -2.5f,-2f,-3f),
            ("rem_c-rem_c", 0, 0, 0)
    };

    

    public float[] BojMapaMoznosti(string tribaBoj1, string zbranBoj1, string zbranBoj2)
    {
        trida = tribaBoj1;
        druhZbrane_PK = zbranBoj1;
        druhZbrane_EK = zbranBoj2;
        List<(string, float, float, float)> PorovnavaciList = new List<(string, float, float, float)>();
        switch (trida)
        {
            case "Pesti":
                PorovnavaciList = pest_List;
                break;
            case "Jednorucka":
                switch (druhZbrane_PK)
                {
                    case "mec_j":
                        PorovnavaciList = mec_j_List;
                        break;
                    case "dagger_j":
                        PorovnavaciList =  dagger_j_List;
                        break;
                    case "sekPal_j":
                         PorovnavaciList = sekPal_j_List;
                        break;
                    case "rem_j":
                        PorovnavaciList =  rem_j_List;
                        break;
                    default:
                        Debug.Log("ErrorBojMapa-switch (druhZbrane_PK) - Jednorucka");
                        break;
                }
                break;
            case "Dvourucka":
                switch (druhZbrane_PK)
                {
                    case "mec_d":
                        PorovnavaciList = mec_d_List;
                        break;
                    case "sekPal_d":
                        PorovnavaciList = sekPal_d_List;
                        break;
                    case "tyc_d":
                        PorovnavaciList = tyc_d_List;
                        break;
                    case "rem_d":
                        PorovnavaciList = rem_d_List;
                        break;
                    default:
                        Debug.Log("ErrorBojMapa-switch (druhZbrane_PK) - Dvourucka");
                        break;
                }
                break;
            case "Luk":
                switch (druhZbrane_PK)
                {
                    case "luk_l":
                        PorovnavaciList = luk_l_List;
                        break;
                    case "kus_l":
                        PorovnavaciList = kus_l_List;
                        break;
                    default:
                        Debug.Log("ErrorBojMapa-switch (druhZbrane_PK) - Luk");
                        break;
                }
                break;
            case "Jezdectvo":
                switch (druhZbrane_PK)
                {
                    case "mec_c":
                        PorovnavaciList = mec_d_List;
                        break;
                    case "sekPal_d":
                        PorovnavaciList = sekPal_d_List;
                        break;
                    case "tyc_d":
                        PorovnavaciList = tyc_d_List;
                        break;
                    case "rem_d":
                        PorovnavaciList = rem_d_List;
                        break;
                    default:
                        Debug.Log("ErrorBojMapa-switch (druhZbrane_PK) - Jezdectvo");
                        break;
                }
                break;
            default:
                Debug.Log("ErrorBojMapa-switch (trida)");
                break;
        }


        // Najde položku v seznamu na základì stringu
        var entry = PorovnavaciList.FirstOrDefault(item => item.Item1 == druhZbrane_PK + "-" + druhZbrane_EK);

        if (entry != default)
        {
            // Extrahujte floaty do promìnných
            string zkratkaList = entry.Item1;
             utokPlus = entry.Item2;
             rychlostPLus = entry.Item3;
             obranaPlus = entry.Item4;
            float[] DataBojMapa = { utokPlus, rychlostPLus, obranaPlus};
            return DataBojMapa;
        }
        else
        {
            Debug.Log("ErrorBojMapa-switch (trida)");
            float[] DataBojMapa = { 0, 0, 0 };
            return DataBojMapa;  
        }

    }

}
