using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;



public class EnemyScriptRoom : MonoBehaviourPun
{
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
    public GameObject Bafer;
    public int XP;


    void Start()
    {
        for (int i = 0; i < XP / 10; i++)
        {
            int BafTipe = Random.Range(1, 10); 
            switch (BafTipe)
            {
                case 1:
                    GetComponentInChildren<EnemyGunScript>().ReShootTime *= 0.9;
                    break;
                case 2:
                    speedN *= 1.1f;
                    break;
                case 3:
                    Vector3 SC = GetComponentInChildren<EnemyGunScript>().shotDir.localScale * 1.2f;
                    GetComponentInChildren<EnemyGunScript>().shotDir.localScale = SC;
                    break;
                case 4:
                    GetComponentInChildren<EnemyGunScript>().AmmoSpeed *= 1.2f;
                    break;
                case 5:
                    GetComponentInChildren<EnemyGunScript>().AmmoDamedge = (int)Math.Round(GetComponentInChildren<EnemyGunScript>().AmmoDamedge * 1.2f);
                    break;
                default:
                    break;
            }
        }
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
        WeyVector1 = Random.Range(1, 3);
        WeyVector2 = Random.Range(1, 3);
        WeyNamber = Random.Range(1, 4);
        RanTyme = Random.Range(40, EnemySeed%200+51);
        speedN = Random.Range(5, 16);
    }


    [PunRPC]
    public void synchronizationHP(float MasterHP)
    {
        hp = MasterHP;
        if (hp < 0){
            
            if (Random.Range(0, 100) >= 80)
            {
                Instantiate(Bafer, transform.position, transform.rotation);   
            } 
                     
            Destroy();
        }
    }






}

