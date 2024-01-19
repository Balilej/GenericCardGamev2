using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtnDesc : MonoBehaviour
{
    public Button FightBtn;
    public Button ShopBtn;
    public Button Deckbtn;
    public GameObject ImgBck;
    public TextMeshProUGUI BtnText;
    

   public void FightEnter()
    {
        ImgBck.SetActive(true);
        BtnText.text = "Fight!";
    }

   public void ShopEnter()
    {
        ImgBck.SetActive(true);
        BtnText.text = "Shop!";
    }

   public void DeckEnter()
    {
        ImgBck.SetActive(true);
        BtnText.text = "Deck!";
    }

   public void BtnExit()
    {
        ImgBck.SetActive(false);
    }
}
