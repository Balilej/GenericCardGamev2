using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownINV : MonoBehaviour
{
    
    public void Btn_Up()
    {
        SLBojSys sys;
        sys = GameObject.Find("SaveLoadSystem").GetComponent<SLBojSys>();
        this.transform.position = new Vector3(0, this.transform.position.y + 10, 0);
        if (this.transform.position.y > sys.PKrow * 10)
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
    public void Btn_Down()
    {
        
        this.transform.position = new Vector3(0, this.transform.position.y - 10, 0);
        if(this.transform.position.y < 0)
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
