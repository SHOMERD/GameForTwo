using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Random = System.Random;

public class NoExit : MonoBehaviour
{
    public GameObject ExitCloser;
    public GameObject ExitPoint;
    public Random rnd;


    void Start()
    {
        rnd = new Random();
        if (rnd.Next(100) >= 50)
        {
            CloceDoor();
        } 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Room")
        {
            CloceDoor();
        }
    }
    public void CloceDoor()
    {
        RoomMenegerScript RoomMenegerScripT = GetComponentInParent<RoomMenegerScript>();
        ExitCloser.SetActive(true);
        Destroy(ExitPoint);
    }
}
