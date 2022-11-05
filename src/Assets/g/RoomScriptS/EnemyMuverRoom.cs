using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;



public class EnemyMuverRoom : MonoBehaviourPun
{
    public int WeyNamber;
    public int WeyVector1; 
    public int WeyVector2;
    public int RanTyme;
    public int EnemySeed;
    public float Speed = 5f;
    public float Damedge;
    public float speedN = 11f;


    void Start()
    {
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

    public void ChajWay()
    {
        WeyVector1 = Random.Range(1, 3);
        WeyVector2 = Random.Range(1, 3);
        WeyNamber = Random.Range(1, 4);
        RanTyme = Random.Range(40, EnemySeed%200+51);
        speedN = Random.Range(5, 16);
    }

}

