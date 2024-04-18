using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LvlBarHrac : MonoBehaviour
{
    public Image Lvlbar;
    public RectTransform LvlBarRc;
    public TextMeshProUGUI LvlTxt;
    public TextMeshProUGUI MultTxt;

    public Func<int> OnZiskejLvl;
    public Func<float> OnZiskejLvlProc;
    public Func<float> OnZiskejMult;

    // Start is called before the first frame update
    void Start()
    {

       // ZiskejHodnoty();
        
    }

    // Update is called once per frame
    void Update()
    {
        ZiskejHodnoty();
    }

    public void ZiskejHodnoty()
    {
        int lvl =  OnZiskejLvl.Invoke();
        float lvlProc = OnZiskejLvlProc.Invoke();
        float mult = OnZiskejMult.Invoke();

        MultTxt.text = mult.ToString();
        LvlTxt.text = lvl.ToString();


        LvlBarRc.sizeDelta = new Vector2(lvlProc, 100);
        if (lvlProc > 100)
        {
            LvlBarRc.sizeDelta = new Vector2(100, 100);
        }
        if(lvlProc < 0)
        {
           LvlBarRc.sizeDelta = new Vector2(0, 100);
        }
    }

}
