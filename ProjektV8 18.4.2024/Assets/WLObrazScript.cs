using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WLObrazScript : MonoBehaviour
{
    public GameObject WLObraz;
    public TextMeshProUGUI TextInfo;
    public Button HratZnovu;
    public Button HlavniMenu;
    public Animator ZavesyAnimator;
    public bool WINLOOSE; //true = vyhrál, false = prohrál

    public Button AdsTlacitko; // Reward Button
    public TextMeshProUGUI TextInfoAd;
    public TextMeshProUGUI AdTlTXT;
#if Unity_IOS || UNITY_ANDROID
    public bool ADSON = true;
#else
    public bool ADSON = false;
#endif

    public Action<float> OnPridMult;

    void Start()
    {
       
            AdsTlacitko.gameObject.SetActive(ADSON);

       
    }

    public void WLUka(bool winloose)
    {
        WINLOOSE = winloose;
        if(WINLOOSE == true)
        {
            OnPridMult.Invoke(0.01f);
            TextInfo.text = "You won!" + "\n" 
                + "+100€";
        } else 
        if(WINLOOSE == false)
        {
            TextInfo.text = "You lost!" + "\n"
                + "+5€";
        } 
        else
        {
            Debug.Log("Chyba v WLObrazScript >>> WINLOOSE bool error");
        }

        ZavesyAnimator.Play("WLAnim");
    }

    public void ChciHratZnovu()
    {
        SceneManager.LoadScene("Lov");
    }

    public void ChciHlavniMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
