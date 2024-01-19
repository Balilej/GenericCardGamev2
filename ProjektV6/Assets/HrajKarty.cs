using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HrajKarty : MonoBehaviour
{
    GameObject karta;
    Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        karta = GameObject.Find("KartaCanv");
        animator = karta.GetComponent<Animator>();
       
        for (int x = 0; x < 4; x++)
        {
            Instantiate(karta, new Vector3(x+0.8f, x+0.1f,x+0.1f), Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MESHClick()
    {
        animator.SetBool("PolozenaKarta", true);
        
    }
}
