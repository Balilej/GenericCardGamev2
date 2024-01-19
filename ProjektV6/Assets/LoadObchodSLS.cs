using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObchodSLS : MonoBehaviour
{
   public SLBojSys SLS;
    // Start is called before the first frame update
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
        SLS.KartungLoad();
    }
}
