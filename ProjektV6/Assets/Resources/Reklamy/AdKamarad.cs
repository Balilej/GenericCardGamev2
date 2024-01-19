using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

//pøidat že tlaèítko píše za jak dlouho lze pustit reklamu
public class AdKamarad : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
#if UNITY_IOS
 public string gameId = "5343979";
 public string adUnitINT = "Interstitial_iOS";
 public string adUnitREW = "Rewarded_iOS";
#else 
    public string gameId = "5343978";
    public string adUnitINT = "Interstitial_Android";
    public string adUnitREW = "Rewarded_Android";
#endif

    public string myAdUnitId;
    public string myAdStatus = "";
    public bool adStarted;
    public bool adCompleted;
    private bool testMode = false;

    public float cas = 30f;
    public bool RwTimerBl = false;

    // Rewarded ads menu
    public GameObject WLObraz;
    public WLObrazScript WLOS;
    //Rewarded ads mesec
    public Mesec_System MesecSys;
    public GameObject MesecObj;
    // Support menu
    public MenuPanelScript supAd;

    // Start is called before the first frame update
    void Start()
    {
        MesecSys = GameObject.Find("Mesec_objekt").GetComponent<Mesec_System>();
        WLOS = GameObject.Find("ScenaCanvas").GetComponent<WLObrazScript>();
        supAd = GameObject.Find("ScenaCanvas").GetComponent<MenuPanelScript>();

        if (gameId != "5343978" && gameId != "5343979")
        {
            Debug.Log("AdKamarad: error line 24: " + gameId);
        }
        else
        {
            Advertisement.Initialize(gameId, testMode,this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // RW Timer
        if(RwTimerBl == true)
        {
            cas = cas - Time.deltaTime;
            TimeSpan cas_t = TimeSpan.FromSeconds(cas);
            string casUka = cas_t.Minutes.ToString() + ":" + cas_t.Seconds.ToString();
            WLOS.AdTlTXT.text = casUka;
            supAd.SupButTxt.text = casUka;
            if (cas <= 0)
            {
                RwTimerBl = false;
                cas = 30f;
            }
        } else
        {
            WLOS.AdTlTXT.text = "Play Ad for money";
            supAd.SupButTxt.text = "Support me<3";
        }
    }

    public void PlayAd()
    {
        Advertisement.Load(adUnitINT, this);
        myAdUnitId = adUnitINT;
    }

    

    public void PlayRewaredAd()
    {

        Advertisement.Load(adUnitREW, this);
        myAdUnitId = adUnitREW;
    }

    // IUnityAdsInitializationListener
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        // Advertisement.Load(myAdUnitId, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        myAdStatus = message;
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    // IUnityAdsLoadListener
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + myAdUnitId);
        if (!adStarted)
        {
            Advertisement.Show(myAdUnitId, this);
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        myAdStatus = message;
        Debug.Log($"Error showing Ad Unit {myAdUnitId}: {error.ToString()} - {message}");
    }
    // IUnityAdsShowListener
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        myAdStatus = message;
        Debug.Log($"Error showing Ad Unit {myAdUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        adStarted = true;
        Debug.Log("Ad Started: " + myAdUnitId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ad Clicked: " + myAdUnitId);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        adCompleted = showCompletionState == UnityAdsShowCompletionState.COMPLETED;
        
        Debug.Log("Ad Completed: " + myAdUnitId);
        RewardedAdReward();
        StartCoroutine(NextAd());
        RwTimerBl = true;
    }

    IEnumerator NextAd()
    {
        Debug.Log("NextAd zaèal poèítat");
        yield return new WaitForSeconds(30);
        Debug.Log("NextAd zaèal dopoèítal");
        adCompleted = false;
        adStarted = false;
    }

    public void RewardedAdReward()
    {
        MesecSys.MesecPridej(100);
        WLOS.TextInfoAd.text = " Pøidáno 100 zlaákù ";
        WLOS.TextInfoAd.gameObject.SetActive(true);
    }

    
}
