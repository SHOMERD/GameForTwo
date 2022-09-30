using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EnemyScript : MonoBehaviour
{
    //public double  
    //public Transform positionOfTawer;
    public float Speed = 5f;
    public Transform ttawer;
    //public Transform position4;
    //public Transform position5;
    //public Transform position6;
    Vector3 GoTo;
    TawerScript tawerScript;
    public float Damedge;

    void Start()
    {
        //GoTo = positionOfTawer.position;
        ttawer = GameObject.FindGameObjectWithTag("tawer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ttawer.position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "tawer")
        {
            tawerScript = collision.GetComponent<TawerScript>();
            if (PhotonNetwork.IsMasterClient)
                Invoke("Damedging", 1);
            Invoke("ChanWay", 2);
            Invoke("ChanWay", 3);
            Invoke("Destroy", 10);

        }

    }

    public void ChanWay()
    {
        Speed = - Speed;
    }
    public void Damedging() 
    {
        tawerScript.GetDamedge(Damedge);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
