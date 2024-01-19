using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAnim : MonoBehaviour
{
    private ParticleSystem star;
    private ParticleSystem show;
    // Start is called before the first frame update
    void Start()
    {
        star = GameObject.Find("star").GetComponent<ParticleSystem>();
        show = GameObject.Find("show").GetComponent<ParticleSystem>();
        
    }
    
    public void StarON()
    {
        star.Play();
    }
    public void StarOFF()
    {
        star.Stop();
    }

    public void ShowON()
    {
        show.Play();
    }
    public void ShowOFF()
    {
        show.Stop();
    }
}
