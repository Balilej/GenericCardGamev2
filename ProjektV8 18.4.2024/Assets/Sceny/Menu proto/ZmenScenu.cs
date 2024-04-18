using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ZmenScenu : MonoBehaviour
{
    public Animator animator;
    string scena;
    

    public void TlPrepniScenuLov()
    {
       // animator.SetBool("ZaclonaZavrenaJe", true);
        animator.Play("ZavesyZavrit");
        StartLovOrLvl.LovF_LvlT = false;
        scena = "Lov";
    }
    public void TlPrepniScenuMesec()
    {
        animator.Play("ZavesyZavrit");
        scena = "Obchod";

    }

    public void TlPrepniScenuDeck()
    {
        animator.Play("ZavesyZavrit");
        scena = "Inventar";

    }

    public void TlPrepniScenuCampaign()
    {
        animator.Play("ZavesyZavrit");
        scena = "LvlMenu";

    }
    // Sem víc scen

    public void naKonecAnimace()
    {
        SceneManager.LoadScene(scena);
    }

    
    
    
   
}
