using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class BojMainScript : MonoBehaviour
    {
       public SLBojSys SaveSys;
        VytvorEnemy vytvorEnemy;

        public BojMapa bojMapa;
        //BarZivotu.cs
        BarZivotu tiskBar;
        //Mesec_System.cs
        public Mesec_System MesecSys;
        // WinLoose code
        public WLObrazScript WLControl; //true = vyhrál, false = prohrál

        public ParticleSystem PSR;

        public List<KartaINF> Enemy = new List<KartaINF>();
       public List<KartaINF> Hrac = new List<KartaINF>();

        public Animator animBoje;
        public KartaINF PolKarta;
        public int VybEnemy = 0;
        int momHrac;

        public KartaINF Bojovnik1;
        public KartaINF Bojovnik2;
        public string bojAnim;
        public string blokaceAnim;
    // Use this for initialization
        void Start()
        {
            SaveSys = GameObject.Find("SaveLoadSystem").GetComponent<SLBojSys>();
            vytvorEnemy = this.GetComponent<VytvorEnemy>();
            bojMapa = GetComponent<BojMapa>();
            animBoje = GetComponent<Animator>();
            momHrac = 4;
            //getLists();
            PSR = GameObject.Find("PSR").GetComponent<ParticleSystem>();
            MesecSys = GameObject.Find("Mesec_objekt").GetComponent<Mesec_System>();
            WLControl = GameObject.Find("ScenaCanvas").GetComponent<WLObrazScript>();
            tiskBar = GameObject.Find("Stats").GetComponent<BarZivotu>();
          //  StartCoroutine(getLists());
        }
        
        public void getLov()
        {
            StartCoroutine(getListsLov());
        }
        IEnumerator getListsLov()
        {
            yield return new WaitForSeconds(1.2f);
       
                Enemy = vytvorEnemy.GetEnemy();
                Hrac = SaveSys.GetMojeKarty();
                PolohaStart();
         
        }

        public void getLvl(List<KartaINF> karty)
        {
        Debug.Log("dostalo se to na getlvl");
            Enemy = karty;
            
            StartCoroutine(getListslvl());
        }
        public void getLvlHrac(List<KartaINF> karty)
        {
            Hrac = karty;
        }
        IEnumerator getListslvl()
        {
        Debug.Log("dostalo se to na getlvl clock");
        yield return new WaitForSeconds(1.2f);

            
            
        Debug.Log("dostalo se to na před polohastart");
        PolohaStart();

        }
    // Update is called once per frame
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                getListsLov();
            }
        }
        //Polohy 
        public void PolohaStart()
        {
            Poloha1(0);
            Poloha2(1);
            Poloha3(2);
            Poloha4(3);
            PolohaEnemy(0);
        }

        public void SetBalicek(string tag)
        {
            switch (tag)
            {
                case "Poloha1":
                    Poloha1(momHrac);
                    break;
                case "Poloha2":
                    Poloha2(momHrac);
                    break;
                case "Poloha3":
                    Poloha3(momHrac);
                    break;
                case "Poloha4":
                    Poloha4(momHrac);
                    break;
            }
        momHrac++;
        }

        void Poloha1(int Hr_index)
        {
            Hrac[Hr_index].KartaPOZ.Play("CekejJedna");
            Hrac[Hr_index].tag = "Poloha1";
        }

        void Poloha2(int Hr_index)
        {
            Hrac[Hr_index].KartaPOZ.Play("CekejDva");
            Hrac[Hr_index].tag = "Poloha2";
        }

        void Poloha3(int Hr_index)
        {
            Hrac[Hr_index].KartaPOZ.Play("CekejTri");
            Hrac[Hr_index].tag = "Poloha3";
        }

        void Poloha4(int Hr_index)
        {
            Hrac[Hr_index].KartaPOZ.Play("CekejCtyri");
            Hrac[Hr_index].tag = "Poloha4";
        }

        void PolohaEnemy(int En_index)
        {
            Enemy[En_index].KartaPOZ.Play("EnemyKartaPoloz");
            Enemy[En_index].tag = "Enemy";
        Debug.Log(En_index + " en index");
        }

    // BOJ
    public int kontrolka = 1;
    public void BojKaret(KartaINF PolozenaKarta)
    {
            if (PolozenaKarta != PolKarta)
            {
                kontrolka++;
                if (kontrolka >= Hrac.Count)
                {
                     MesecSys.MesecPridej(5);
                    WLControl.WLUka(false);   
                }

                PolKarta = PolozenaKarta;
                tiskBar.RestnDie(true);
                tiskBar.ZiskejStatHodnoty(PolKarta.startZivoty, Enemy[VybEnemy].startZivoty);
                SetBalicek(PolozenaKarta.tag);
                StartCoroutine(BojClock());

            }
            
    }

        IEnumerator BojClock()
        {
          while (PolKarta.JeNazivu() && Enemy[VybEnemy].JeNazivu())
          {
                int rozhodovac = Random.Range(1, 3);
                KdoHraje();
                float[] DataProBoj = bojMapa.BojMapaMoznosti(Bojovnik1.trida, Bojovnik1.zbran, Bojovnik2.zbran);
                Debug.Log("tohle je ten float:" + DataProBoj[0] + "    " + DataProBoj[1] + "     " + DataProBoj[2]);

            //Bojovnik1 bojuje
            switch (rozhodovac)
            {

                case 1:
                    // 1 bojuje
                    animBoje.Play(bojAnim);

                    if (DataProBoj[0] >= 0)
                    {
                        Debug.Log("verze 1 " + Bojovnik1.tag + " bojuje a " + Bojovnik2 + " se umira " + Bojovnik2.zivoty + "hp");
                        Bojovnik2.zivoty = Bojovnik2.zivoty - (Bojovnik1.utok + (Bojovnik1.utok * DataProBoj[0]));
                        Debug.Log(Bojovnik2.zivoty + "hp potom VZ1");
                    }
                    if (DataProBoj[0] < 0)
                    {
                        Debug.Log("verze 2 " + Bojovnik1.tag + " bojuje a " + Bojovnik2 + " se umira " + Bojovnik2.zivoty + "hp");
                        //vyresit
                        Bojovnik2.zivoty = Bojovnik2.zivoty - (Bojovnik1.utok + (Bojovnik1.utok * (DataProBoj[0] / 10)));
                        Debug.Log(Bojovnik2.zivoty + "hp potom VZ2");
                    }

                    //  tiskBar.NastavStaty(polozenaKarta.zivoty, bojovnik.zivoty);
                    // Debug.Log(Bojovnik2.zivoty + "pepe" + Bojovnik1.zivoty);
                    break;
                case 2:
                    // 1 bojuje a 2 se brani
                    animBoje.Play(bojAnim);
                    animBoje.Play(blokaceAnim);
                    Debug.Log(Bojovnik1.tag + " bojuje a " + Bojovnik2 + " se braní " + Bojovnik2.zivoty + "hp");
                    Bojovnik2.zivoty = Bojovnik2.zivoty - Bojovnik2.obranaPosk;
                    Debug.Log(Bojovnik2.zivoty + "hp potom");

                    //  tiskBar.NastavStaty(polozenaKarta.zivoty, bojovnik.zivoty);
                    // Debug.Log(Bojovnik2.zivoty + "pepe" + Bojovnik1.zivoty);
                    break;
            }
            tiskBar.NastavStaty(PolKarta.zivoty, Enemy[VybEnemy].zivoty);
            Zije();

            yield return new WaitForSeconds(1);
          }

            
        }

    public void Zije()
    {
        if (PolKarta.JeNazivu() == false)
        {

            PolKarta.Smrt();
            // tiskBar.NastavStaty(polozenaKartapl.zivoty, bojovnik.zivoty);
        }
        
        if (Enemy[VybEnemy].JeNazivu() == false)
        {
            Debug.Log("bms krok1");
            Enemy[VybEnemy].Smrt();
            Debug.Log("bms krok2");
            int cena = (int) Mathf.Abs(((Enemy[VybEnemy].startZivoty + Enemy[VybEnemy].utok) / 2) - Enemy[VybEnemy].obranaPosk);
            int cena2 = (int)Mathf.Abs((Enemy[VybEnemy].startZivoty + Enemy[VybEnemy].utok) / 2);
            Debug.Log("bms krok3");
            Debug.Log("cena1: " + cena + " cena2: " + cena2);
            MesecSys.MesecPridej(cena);
            Debug.Log("bms krok4");
            VybEnemy++;
            Debug.Log("bms krok4");
            if (VybEnemy < Enemy.Count)
            {
                Debug.Log("bms krok5");
                PolohaEnemy(VybEnemy);
                Debug.Log("bms krok6");
                tiskBar.RestnDie(false);
                Debug.Log("bms krok7");
                BojKaret(PolKarta);
                Debug.Log(PolKarta);
                Debug.Log("bms krok8");
                tiskBar.NastavStaty(PolKarta.zivoty, Enemy[VybEnemy].zivoty);
                Debug.Log("bms krok9");
            }
            else
            {
                MesecSys.MesecPridej(100);
                WLControl.WLUka(true);
                Debug.Log("nejsou karty"); // přidej text aj do hry
            }


        }
    }

    public void KdoHraje()
    {
        bool kdoHrajeBool = (Random.Range(0, 2) == 1);
        if (kdoHrajeBool == true)
        {
            Bojovnik1 = PolKarta;
            Bojovnik2 = Enemy[VybEnemy];
            bojAnim = "RBoj";
            blokaceAnim = "LBlokace";
        }
        else
        if (kdoHrajeBool == false)
        {
            Bojovnik1 = Enemy[VybEnemy];
            Bojovnik2 = PolKarta;
            bojAnim = "LBoj";
            blokaceAnim = "RBlokace";
        }
        else { Debug.Log("KdoHrajeError!" + kdoHrajeBool); }

    }

    public void PljPSR()
    {
        PSR.Play();
    }
}
