using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Random = System.Random;


public class RoomMenegerScript : MonoBehaviourPun
{
    public GameObject Room;
    public GameObject[] players;
    public GameObject[] ObjectToOf;
    public GameObject[] DesActive;
    public Transform StartOfRoom;
    public Transform EndOfRoom;
    public int EnemyS;
    public int BoysCol;
    public Transform shotDir;
    public int EnemyColmaxs = 25;
    public int ExitsCol = 1;
    public int EnemyCol;
    public GameObject[] badBoyS;
    public Transform[] SpavPoints;
    public GameObject[] EnemyMass;

    public Transform Tp;
    int RIndexFBoys;
    int RIndexFSpav;
    public Random rnd;
    public int XP = 0;
    public int Timer = 1;
    public int Allredy = 0;

    public GameMenedgerR GameMenedger;
    //public Text EndText;
    //public Text HpText;
    //public string EndTextText;
    //public string HpTextText;
    //public GameObject EndConvas;
    //private SpriteRenderer sprite;
    //public int MaxHp = 1600;
    //public int HpToHiling = 111;
    //public bool CanHiling = false;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < DesActive.Length; i++)
        {
            DesActive[i].SetActive(false);
        }

        EnemyS = 0;

        //CanHiling = false;
        //sprite = GetComponent<SpriteRenderer>();
        //EndConvas.SetActive(false);
        rnd = new Random();
        //if (/*Timer > TimToSpavn &*/ /*PhotonNetwork.IsMasterClient*/ true)
        //{

        //    //TimToSpavn = TimToSpavn - 1;
        //    //if (100 > TimToSpavn & 30 < rnd.Next(100))
        //    //{
        //    //    TimToSpavn = 500;
        //    //    BoysCol++;
        //    //}
        //}

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //HpTextText = "Жизни Башни:" + hp;
        //HpText.text = HpTextText;
        //if (hp < 0)
        //{
        //    sprite.color = Color.red;
        //    Invoke("EndeOfGame", 4);
        //    Invoke("TheWardo", 6);
        //}
        //if (Timer % 150 == 0)
        //{
        //    XP++;

        //}
        //if (Timer % 100 == 0 & hp < MaxHp & CanHiling)
        //{
        //    hp = hp + HpToHiling;
        //    photonView.RPC("synchronization", RpcTarget.AllBuffered, XP, hp);
        //}

        //Timer++;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "EndOfRoom")
        {

            Room.transform.position = collision.transform.position - StartOfRoom.localPosition;
            //Room.transform.rotation = collision.transform.rotation;
            Debug.LogWarning("gjldbyenj");
        }

        if (collision.tag == "Player")
        {
            //GuyScript guyScript = collision.GetComponent<GuyScript>();
            //guyScript.EnterThisRoom(Tp);

            players = GameObject.FindGameObjectsWithTag("Player");
            EnterThisRoom();
        }

    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "ammo")
    //    {
    //        CanHiling = false;
    //    }
    //}
    //public void GetDamedge(float damedg)
    //{
    //    hp = hp - (damedg / 2);
    //    photonView.RPC("synchronization", RpcTarget.AllBuffered, XP, hp);
    //}

    public void EnemySpawner()
    {
        //Instantiate(badBoyS[RIndexFBoys], SpavPoints[RIndexFSpav].position, transform.rotation);
        GameObject gameL = PhotonNetwork.Instantiate(badBoyS[RIndexFBoys].name, SpavPoints[RIndexFSpav].position, transform.rotation);
        try
        {
            EnemyScriptRoom gameLd = gameL.GetComponent<EnemyScriptRoom>();
            gameLd.EnemySeed = rnd.Next(1, 123541533);
        }
        catch (System.Exception)
        {
        }


    }

    public void ExitThisRoom() {
        for (int i = 0; i < ObjectToOf.Length; i++)
        {
            Destroy(ObjectToOf[i]);
        }
    }

    public void EnterThisRoom()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].transform.position = Tp.position;
        }
        
        for (int i = 0; i < DesActive.Length; i++)
        {
            DesActive[i].SetActive(true);
        }
        if (Allredy == 0 & PhotonNetwork.IsMasterClient)
        {
            for (int i = EnemyColmaxs; i > 0; i--)
            {
                RIndexFBoys = rnd.Next(badBoyS.Length);
                RIndexFSpav = rnd.Next(SpavPoints.Length);
                EnemySpawner();
            }
        }
        Allredy = 1;

    }
    public void CleanRoom()
    {
        try
        {
            EnemyMass = GameObject.FindGameObjectsWithTag("enemy");
            if (EnemyMass.Length == 1)
            {
                for (int i = 0; i < EnemyMass.Length; i++)
                {
                    EnemyScriptRoom guyScript = EnemyMass[i].GetComponent<EnemyScriptRoom>();
                    guyScript.GetDamedge(100000);
                }
            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void RoomClined()
    {
        
        Invoke("ExitThisRoom", 1);
        //ObjectToOf[i].SetActive(false);

        if (PhotonNetwork.IsMasterClient & ExitsCol > 0)
        {
            GameMenedger = GameObject.FindGameObjectWithTag("Helper").GetComponent<GameMenedgerR>();
            GameMenedger.XP++; 
            GameMenedger.AddRoom(ExitsCol);
            ExitsCol--;
        }
       

    }
    public void KiledEnemy()
    {

        Invoke("FindEnemy", 1);
        Invoke("CheckE", 2);

    }

    public void CheckE()
    {
        if (EnemyMass.Length == 0 & PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("synchronization", RpcTarget.AllBuffered);
        }
    }

    public void FindEnemy()
    {
        EnemyMass = GameObject.FindGameObjectsWithTag("enemy");

    }
    [PunRPC]
    public void synchronization()
    {
        RoomClined();
       //CleanRoom();
    }


    
    //public void HanliHil(bool o) { CanHiling = o; }

    //[PunRPC]
    //public void synchronization(int MasterXP, float MasterHP)
    //{
    //    XP = MasterXP;
    //    hp = MasterHP;
    //}

}


