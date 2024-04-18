using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UlozBtn : MonoBehaviour
{
    SaveCompSystem SCS;
    // Start is called before the first frame update
    void Start()
    {
        SCS = GameObject.Find("EventKamarad").GetComponent<SaveCompSystem>();
    }

  public void UlozNakup()
    {
        SCS.KartungSave();
    }
}
