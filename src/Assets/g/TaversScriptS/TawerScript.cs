using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Random = System.Random;



public class TawerScript : MonoBehaviourPun
{
    public GameObject[] badBoyS;
    public  Transform[] SpavPoints;
    public float hp = 1600;
    int RIndexFBoys;
    int RIndexFSpav;
    public int Timer = 1;
    public int TimToSpavn =500;
    public int BoysCol =1;
    public Random rnd;
    public Text EndText; 
    public Text HpText;
    public string EndTextText;
    public string HpTextText;
    public int XP = 0;
    public GameObject EndConvas;
    private SpriteRenderer sprite;
    public int MaxHp = 1600;
    public int HpToHiling= 111;
    public bool CanHiling =false;

    // Start is called before the first frame update
    void Start()
    {
        CanHiling = false;
        EndConvas.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
        rnd = new Random();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        HpTextText = "Жизни Башни:" + hp;
        HpText.text = HpTextText;
        if (hp < 0)
        {
            sprite.color = Color.red;
            Invoke("EndeOfGame", 4);
            Invoke("TheWardo", 6);
        }
        if (Timer % 150 == 0)
        {
            XP++;

        }
        if (Timer % 100 == 0 & hp < MaxHp & CanHiling) 
        { 
            hp = hp + HpToHiling;
            photonView.RPC("synchronization", RpcTarget.AllBuffered, XP, hp);
        }
        
        Timer++;
        if (Timer > TimToSpavn & 10 > rnd.Next(100))
        {
            for (int i = BoysCol; i > 0; i--)
            {
                Timer = 0;
                RIndexFBoys = rnd.Next(badBoyS.Length);
                RIndexFSpav = rnd.Next(SpavPoints.Length);
                
                EnemySpawner();
            }
            TimToSpavn = TimToSpavn - 1;
            if (100 > TimToSpavn & 30 < rnd.Next(100))
            {
                TimToSpavn = 500;
                BoysCol++;
            }
        }

        
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.tag == "ammo")
    //    {
    //        CanHiling = true;
    //    }

    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "ammo")
    //    {
    //        CanHiling = false;
    //    }
    //}
    public void GetDamedge(float damedg)
    {
        hp = hp - (damedg/2);
        photonView.RPC("synchronization", RpcTarget.AllBuffered, XP, hp);
    }

    public void EnemySpawner()
    {
        //Instantiate(badBoyS[RIndexFBoys], SpavPoints[RIndexFSpav].position, transform.rotation);
        PhotonNetwork.Instantiate(badBoyS[RIndexFBoys].name, SpavPoints[RIndexFSpav].position, transform.rotation);

    }
    public void Reloud()
    {
        Time.timeScale = 1f; 
        PhotonNetwork.LoadLevel("GameRoom");
    }
    public void EndeOfGame()
    {  
        
        EndTextText = "Финальный счет = " + XP;
        EndText.text = EndTextText;
        EndConvas.SetActive(true);
    }
    public void TheWardo() { Time.timeScale = 0f; }
    public void Exit() { Application.Quit(); }
    public void HanliHil(bool o) { CanHiling = o; }
    
    [PunRPC]
    public void synchronization(int MasterXP, float MasterHP)
    {
        XP = MasterXP;
        hp = MasterHP;
    }



}
