using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mesec_System : MonoBehaviour
{
    // Odkazy
    public Image MesecPozazi;
    public Image MesecImg;
    public TextMeshProUGUI MesecMnozstvi;
    public Animator MesecAnim;

    //Variably
    public bool mesecAktivni = false;
    public bool mesecMuzeByt = true;
    public int mnozstviMeny;
    public float mnMenyUkaz;
    public string mesecTxT;
    //MesecHodnota()
    public int pridanaMena;
    // SaveLoad.cs
    public SaveLoad SL_sys;
    public GameObject EventKamarad;


    void Start()
    {
        EventKamarad = GameObject.Find("EventKamarad");
        SL_sys = EventKamarad.GetComponent<SaveLoad>();
        // MesecAnim.Play("UkazMesec");
    }

    // Update is called once per frame
    void Update()
    {
        mnMenyUkaz = mnozstviMeny;
        if(mnozstviMeny > 1000)
        {
            mnMenyUkaz = mnMenyUkaz / 1000;
            mesecTxT = "€" + mnMenyUkaz.ToString("F1") + "k";
        }
        else { mesecTxT = "€" + mnMenyUkaz; }
        MesecMnozstvi.text = mesecTxT;
    }
   public void MesecLoad(int mn)
    {
        pridanaMena = mn;
        mnozstviMeny = mnozstviMeny + pridanaMena;
    }
    public void MesecPridej(int mn)
    {
        pridanaMena = mn;

            if (mesecAktivni == false && mesecMuzeByt == true)
            {
                MesecAnim.Play("UkazMesec");
                mesecAktivni = true;
            }
            else if(mesecAktivni == true) { MesecAnim.Play("KlepejMesec"); }

        
        mnozstviMeny = mnozstviMeny + pridanaMena;
        SL_sys.Uloz(mnozstviMeny);
    }

    public void MesecButton()
    {
        mesecMuzeByt = false;
        if (mesecAktivni == true)
        {
            MesecAnim.Play("UkazMesecReverse");
            mesecAktivni = false;

        } else if(mesecAktivni == false)
        {
            MesecAnim.Play("UkazMesec");
            mesecAktivni = true;

        }
        
    }

}
