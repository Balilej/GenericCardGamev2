using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KartaAnim : MonoBehaviour
{
    public Animator animator;
    public Animator kartaAnimator;
    public Canvas cnv;
    public int cnv_order;
    public bool jePouzita;
    public Bojovnici bojovnici;
    public KartaVybINF kartaVybINF;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        kartaAnimator = this.GetComponent<Animator>();
        cnv = this.GetComponent<Canvas>();
        cnv_order = cnv.sortingOrder;
        jePouzita = false;
        bojovnici = GameObject.Find("EventKamarat").GetComponent<Bojovnici>();
        kartaVybINF = GetComponent<KartaVybINF>();
    }

    private void OnMouseEnter()
    {
      if(jePouzita == false)
        {
          animator.Play("KartaHover");
          cnv.sortingOrder = 100;
          animator.SetBool("JeVKarte", true);
        }
        
    }

    private void OnMouseExit()
    {
        if (jePouzita == false)
        {
            animator.SetBool("JeVKarte", false);
            cnv.sortingOrder = cnv_order;
        }
    }

    private void OnMouseDown()
    {
        if (jePouzita == false && bojovnici.Muzu(kartaVybINF))
        {
  
            jePouzita = true;
            kartaAnimator.Play("jePouzita");
            bojovnici.KdoEqip(kartaVybINF);
        }
        else
        {
            animator.Play("NePouzita");
            cnv.sortingOrder = cnv_order;
        }
    }

}
