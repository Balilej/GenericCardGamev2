using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckAnimHelp : MonoBehaviour
{
    public Transform Karta;
   public  KartaVybINF KartaVybInf;
    Vector3 nul_pozice;
    // Start is called before the first frame update
    void Start()
    {
        Karta = transform.GetChild(0);
        KartaVybInf = Karta.gameObject.GetComponent<KartaVybINF>();
        nul_pozice = new Vector3(0, -19, 20);
    }

    public void ZmenaNaNulu()
    {
        Karta.transform.position = nul_pozice;
    }

    public void ZabijKartu()
    {
        KartaVybInf.Smrt();
    }
}
