using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckAnim : MonoBehaviour
{
    public GameObject Karta;
    public Canvas cnv;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        Karta = transform.GetChild(0).gameObject;
        cnv = Karta.GetComponent<Canvas>();
        
    }

    
      //  animator.Play("KartaHover");
      //  cnv.sortingOrder = 100;
  
}
