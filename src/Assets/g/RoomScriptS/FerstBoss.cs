using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;



public class FerstBoss : MonoBehaviourPun
{
    public float Speed = 5f;
    public float Damedge;
    public float speedN = 11f;
    public int EnemySeed;
    public GameObject Bafer;
    Vector3 UpAndDaun;
    int timer = 0;

    void Start()
    {
        UpAndDaun = transform.up * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Run();
        }
        timer++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "LevelObject" || collision.tag == "enemy")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, timer % 360);
        }
        if (collision.tag == "Player")
        {
            GuyScript guyScript = collision.GetComponent<GuyScript>();
            guyScript.GetDamedge(100);

        }

    }

    private void Run()
    {
        transform.Translate(Vector2.right * speedN * Time.deltaTime);
    }

}
