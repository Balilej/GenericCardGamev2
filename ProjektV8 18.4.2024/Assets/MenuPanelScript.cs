using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPanelScript : MonoBehaviour
{
    public GameObject MenuPanel;
    public Button ResumeBtn;
    public Button OpakovatBtn;
    public Button HlMenuBtn;
    public Button KonecHryBtn;
    public TextMeshProUGUI SupButTxt;

    public Image bckShadow;
    public Image menuIco;
    public Sprite MenuOK;
    public Sprite MenuX;

    // Start is called before the first frame update
    void Start()
    {
        menuIco = GameObject.Find("Ico").GetComponent<Image>();
        bckShadow = GameObject.Find("Zahlavek").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DejMenuPanel();
        }
    }

    public void DejMenuPanel()
    {
        if (MenuPanel.activeSelf)
        {
            bckShadow.enabled = false;
            menuIco.sprite = MenuOK;
            MenuPanel.SetActive(false);
        }
        else
        {
           
            bckShadow.enabled = true;
            menuIco.sprite = MenuX;
            MenuPanel.SetActive(true);
        }
    }

    public void DejResume()
    {
        bckShadow.enabled = false;
        menuIco.sprite = MenuOK;
        MenuPanel.SetActive(false);
    }

    public void DejOpakovatHru()
    {
        SceneManager.LoadScene("Lov");
    }

    public void DejHlavniMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void DejKonecHry()
    {
        Application.Quit();
    }
}
