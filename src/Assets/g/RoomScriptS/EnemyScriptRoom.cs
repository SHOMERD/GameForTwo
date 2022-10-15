using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = System.Random;



public class EnemyScriptRoom : MonoBehaviourPun
{

    public Random rnd;
    public int WeyNamber;
    public int WeyVector1; 
    public int WeyVector2;
    public int RanTyme;
    public float Speed = 5f;
    RoomMenegerScript roomMenegerScript;
    public float Damedge;
    public float speedN = 11f;
    public int EnemySeed;
    public float hp = 100;

    void Start()
    {
       
        rnd = new Random();

        ChajWay();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            RanTyme--;
            if (RanTyme <= 0)
            {
                ChajWay();
            }
            if (WeyNamber == 1)
            {
                RunR();
                RunU();
            }
            if (WeyNamber == 2)
            {
                RunR();

            }
            if (WeyNamber == 3)
            {
                RunU();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "LevelObject" || collision.tag == "enemy")
        {
            ChajWay();
        }
        if (collision.tag == "RoomMeneger")
        {
            roomMenegerScript = collision.GetComponent<RoomMenegerScript>();
        }

    }

    public void Destroy()
    {
        Destroy(gameObject);
        roomMenegerScript.KiledEnemy();
        
    }
    private void RunR( )
    {
        
        if (WeyVector1 == 1)
        {
            Vector3 RightAndLeft = transform.right * 1;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + RightAndLeft, speedN * Time.deltaTime);
        }
        if (WeyVector1 == 2)
        {
            Vector3 RightAndLeft = transform.right * -1;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + RightAndLeft, speedN * Time.deltaTime);
        }

    }
    private void RunU()
    {
        if (WeyVector2 == 1)
        {
            Vector3 UpAndDaun = transform.up * 1;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + UpAndDaun, speedN * Time.deltaTime);
        }
        if (WeyVector2 == 2 )
        {
            Vector3 UpAndDaun = transform.up * -1;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + UpAndDaun, speedN * Time.deltaTime);
        }
    }
    public void GetDamedge(int damedg)
    {
        photonView.RPC("synchronizationHP", RpcTarget.AllBuffered, hp - damedg);
    }
    public void ChajWay()
    {
        WeyVector1 = rnd.Next(1, 3);
        WeyVector2 = rnd.Next(1, 3);
        WeyNamber = rnd.Next(1, 4);
        RanTyme = rnd.Next(40, EnemySeed%150+50);
        speedN = rnd.Next(5, 15);
    }


    [PunRPC]
    public void synchronizationHP(float MasterHP)
    {
        hp = MasterHP;
        if (hp < 0)
            Destroy();
    }






}

