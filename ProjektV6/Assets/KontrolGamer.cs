using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolGamer : MonoBehaviour
{
    [SerializeField] PlayerGamer HracJedna;
    [SerializeField] PlayerGamer HracDva;
    public GameObject figureJedna;
    public GameObject figureDva;
    private void Start()
    {
        
    }
    private void Update()
    {
        
            if (HracDva.zivoty > 0 && HracJedna.zivoty > 0)
            {
                HracDva.zivoty = HracDva.zivoty - HracJedna.utok;
                HracJedna.zivoty = HracJedna.zivoty - HracDva.utok;
                Debug.Log(HracJedna.zivoty);
                Debug.Log(HracDva.zivoty);
            }
            else if (HracDva.utok > 0 && HracJedna.zivoty <= 0)
            {
                Destroy(figureJedna);
            }
            else if (HracDva.utok <= 0 && HracJedna.zivoty > 0)
            {
                Destroy(figureDva);
            }
            else
            {
                Destroy(figureDva);
                Destroy(figureJedna);
            }
        
    }
}
