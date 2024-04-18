using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvAdd : MonoBehaviour
{
    
   public KartaINF kartaINF;
   public GameObject CardSort;
    public KarteList kartelist;
    public Transform posPar;

    bool vybrana = false;
    Vector3 mala = new Vector3(0.125f, 0.125f, 0.5f);
    Vector3 velka = new Vector3(0.25f, 0.25f, 0.5f);
    private void Start()
    {
        kartelist = GameObject.Find("EventKamarad").GetComponent<KarteList>();
        CardSort = GameObject.Find("CardSort");
        kartaINF = this.GetComponent<KartaINF>();
    }
    private void OnMouseDown()
    {
        if(vybrana == false)
        {
            int z = kartelist.getKarteListCount();
            if (z != 8)
            {
                posPar = kartaINF.transform.parent;
                Debug.Log("Transform");
                kartaINF.transform.localScale = mala;
                kartaINF.transform.SetParent(CardSort.transform);
                KarteList.SelectKarte.Add(kartaINF);
                vybrana = true;
            }
        } 
        else
        {
            kartaINF.transform.localScale = velka;
            kartaINF.transform.SetParent(posPar);
            KarteList.SelectKarte.Remove(kartaINF);
            Debug.Log("Transform2");
            vybrana = false;
        }
        
        
    }
}
