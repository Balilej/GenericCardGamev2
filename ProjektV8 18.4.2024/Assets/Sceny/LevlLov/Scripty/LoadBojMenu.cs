using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBojMenu : MonoBehaviour
{
   public SLBojSys SLS;
    void Start()
    {
        SLS = GetComponent<SLBojSys>();
        StartCoroutine(LoadBojovniky());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadBojovniky()
    {
        yield return new WaitForSeconds(1);
        SLS.KartungLoadBojMenu();
    }
}
