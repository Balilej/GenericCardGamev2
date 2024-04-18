using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadZavKarty : MonoBehaviour
{
    SaveCompSystem SaveLoad;

    private void Start()
    {
        SaveLoad = GameObject.Find("SaveSystemKarta").GetComponent<SaveCompSystem>();
    }

    public void LoadZav()
    {
        SaveLoad.KartungLoad();
    }

    
}
