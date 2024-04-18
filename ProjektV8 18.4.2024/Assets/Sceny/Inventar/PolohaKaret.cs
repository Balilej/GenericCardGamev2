using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolohaKaret : MonoBehaviour
{
    public GameObject Deck;
    public Scrollbar ScrBar;

    
    public SaveCompSystem SLS;
    // Start is called before the first frame update
    void Start()
    {
        Deck = GameObject.Find("CardDeck");
        SLS = GameObject.Find("SaveSystemKarta").GetComponent<SaveCompSystem>();
    }

    public void Zmena()
    {
        Vector3 novaPozice = new Vector3(0, ScrBar.value * SLS.PKrow*10, 0);
        Deck.transform.position = novaPozice;
        Debug.Log(SLS.PKrow);
    }
}
