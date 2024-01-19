using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaSwitch : MonoBehaviour
{
    public string sceneName;
    public GameObject EventKamarat;
  //  public VytvorKartu vytvorKartu;

    public void VytvorKartuZapni()
    {
        EventKamarat = GameObject.Find("EventKamarad");
       // vytvorKartu = EventKamarat.GetComponent<VytvorKartu>();
       // vytvorKartu.VytvorKartus();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

