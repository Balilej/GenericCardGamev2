using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karta : MonoBehaviour
{
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {        



    }

    public void MESHClick()
    {
        animator.SetBool("PolozenaKarta", true);
    }
    
    
    public class Bojovnik
    {

    }
}
