using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllTakeIt : MonoBehaviour
{
    public Animator anim;
    public GameObject ZnicMe;
    
    // Start is called before the first frame update
    void Start()
    {
        bool UkaTutBol = PlayerPrefs.GetInt("UkaTutBol", 0) == 1;
        anim = GetComponent<Animator>();
        ZnicMe = GameObject.Find("TutorialBase");

        if (!UkaTutBol)
        {
            // If the tutorial hasn't been shown, display it
            ZnicMe.SetActive(true);

            // Set the PlayerPrefs flag to indicate that the tutorial has been shown
            
        }
        else
        {
            // If the tutorial has been shown before, hide it
            
            Destroy(ZnicMe);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IWTI()
    {
        anim.Play("Click");
    }

    public void NIWTI()
    {
        PlayerPrefs.SetInt("UkaTutBol", 1);
        Destroy(ZnicMe);
    }
}
