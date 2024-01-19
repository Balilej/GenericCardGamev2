using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarZivotu : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Hrac;
    public GameObject EnemyBar;
    public GameObject HracBar;
    public RectTransform EnemyBarWH;
    public RectTransform HracBarWH;
    public TextMeshProUGUI EnemyTxt;
    public TextMeshProUGUI HracTxt;
    public float stoProcEnemy;
    public float stoProcHrac;
    public float momProcEnemy;
    public float momProcHrac;
    public float UkaProcEnemy;
    public float UkaProcHrac;
    public bool _an = false;


    // Start is called before the first frame update
    void Start()
    {
        // Enemy.SetActive(false);
        // Hrac.SetActive(false);
        EnemyBarWH = EnemyBar.GetComponent<RectTransform>();
        HracBarWH = HracBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetActive(_an);
        Hrac.SetActive(_an);

    }

    //Získa životy karet z VytvorKartu.cs
    public void ZiskejStatHodnoty(float hrac_zivoty, float enemy_zivoty)
    {
        stoProcEnemy = enemy_zivoty;
        stoProcHrac = hrac_zivoty;
        _an = true;
    }

   
    //Pøepisuje Stats->Zivoty_Hrac/Zivoty_Enemy=>Procenta
            //Pøidám úpravu velikost baru
    public void NastavStaty(float hrac_zivoty, float enemy_zivoty)
    {
        momProcEnemy = enemy_zivoty;
        momProcHrac = hrac_zivoty;
      // if(enemy_zivoty > 0 && hrac_zivoty > 0) 
      // { 
        if(momProcEnemy != stoProcEnemy)
        {
            UkaProcEnemy = (int)(((float)momProcEnemy / (float)stoProcEnemy) * 100f);
            if(UkaProcEnemy < 0)
            {
                UkaProcEnemy = 0;
            }
            EnemyTxt.text = UkaProcEnemy + "%";
            EnemyBarWH.sizeDelta = new Vector2(UkaProcEnemy*2, 100);
        }

        if (momProcHrac != stoProcHrac)
        {
            UkaProcHrac = (int)(((float)momProcHrac / (float)stoProcHrac) * 100f);
            if(UkaProcHrac < 0)
            {
                UkaProcHrac = 0;
            } 
            HracTxt.text = UkaProcHrac + "%";
            HracBarWH.sizeDelta = new Vector2(UkaProcHrac * 2, 100);
        }
      // }
        
    }

    public void RestnDie(bool H_E_Bool)
    {
        bool HEBool = H_E_Bool;

        if(HEBool == true)
        {
            HracTxt.text = "100%";
            HracBarWH.sizeDelta = new Vector2(200, 100);
        }
        if(HEBool == false)
        {
            EnemyTxt.text = "100%";
            EnemyBarWH.sizeDelta = new Vector2(200, 100);
        }
    }
    
}
