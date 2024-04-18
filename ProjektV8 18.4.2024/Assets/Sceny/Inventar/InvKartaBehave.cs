using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvKartaBehave : MonoBehaviour
{
    KartaVybINF kartaVybInf;

    public Transform Karta;



    private float fraction_A = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Karta = kartaVybInf.karta.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
