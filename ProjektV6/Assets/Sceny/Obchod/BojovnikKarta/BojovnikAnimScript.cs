using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BojovnikAnimScript : MonoBehaviour
{
   public VytvorBojovnika VB;
    Animator animator;
    bool muzu;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VB = GameObject.Find("EventKamarad").GetComponent<VytvorBojovnika>();
        muzu = true;
    }

   

    private void OnMouseDown()
    {
        if(muzu == true)
        {
            VB.NactiKartu();
            animator.Play("UkaKartu");
            muzu = false;
        }
        
    }
}
