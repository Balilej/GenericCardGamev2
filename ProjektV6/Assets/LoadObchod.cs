using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObchod : MonoBehaviour
{
    SaveCompSystem SaveLoad;

    private void Start()
    {
        SaveLoad = GameObject.Find("SaveSystemKarta").GetComponent<SaveCompSystem>();
        SaveLoad.KartungLoadObchod();
    }

  
}
