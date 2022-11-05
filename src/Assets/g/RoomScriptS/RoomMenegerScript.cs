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
    public GameObject StartOfRoom;
    public GameObject[] EndOfRoom;
    public int EnemyS;
    public int BoysCol;
    public Transform shotDir;
    public int EnemyColmaxs = 25;
    public int EnemyCol;
    public GameObject[] badBoyS;
    public Transform[] SpavPoints;
    public GameObject[] EnemyMass;

    public bool x=false;


    public Transform Tp;
    int RIndexFBoys;
    int RIndexFSpav;
    public Random rnd;
    public int XP = 0;
    public int Timer = 1;
    public int AllredyDune = 0;

    public GameMenedgerR GameMenedger;



    void Start()
    {
        
        for (int i = 0; i < DesActive.Length; i++)
        {
            DesActive[i].SetActive(false);
        }
        EnemyS = 0;
        rnd = new Random();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            //GuyScript guyScript = collision.GetComponent<GuyScript>();
            //guyScript.EnterThisRoom(Tp);

            players = GameObject.FindGameObjectsWithTag("Player");
            EnterThisRoom();
        }

    }

    public void EnemySpawner()
    {
        //Instantiate(badBoyS[RIndexFBoys], SpavPoints[RIndexFSpav].position, transform.rotation);
        GameObject gameL = PhotonNetwork.Instantiate(badBoyS[RIndexFBoys].name, SpavPoints[RIndexFSpav].position, transform.rotation);
        try
        {
            EnemiHealfControler gameLd = gameL.GetComponent<EnemiHealfControler>();
            gameLd.EnemySeed = rnd.Next(1, 123541533);
            gameLd.XP = XP;
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
            try
            {
                DesActive[i].SetActive(true);
            }catch (System.Exception)
            {

            }

        }
        if (AllredyDune == 0 & PhotonNetwork.IsMasterClient)
        {
            for (int i = EnemyColmaxs; i > 0; i--)
            {
                RIndexFBoys = rnd.Next(badBoyS.Length);
                RIndexFSpav = rnd.Next(SpavPoints.Length);
                EnemySpawner();
            }
        }
        AllredyDune = 1;

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
                    EnemiHealfControler guyScript = EnemyMass[i].GetComponent<EnemiHealfControler>();
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
        
        if (PhotonNetwork.IsMasterClient & !x)
        {
            x = true;
            GameMenedger = GameObject.FindGameObjectWithTag("Helper").GetComponent<GameMenedgerR>();
            GameMenedger.XP++;
            GameMenedger.AddRoom(EndOfRoom);
        }
        Invoke("ExitThisRoom", 1);
        

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

   
}


