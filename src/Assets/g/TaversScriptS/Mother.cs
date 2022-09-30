using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 


public class Mother : MonoBehaviourPun
{
 
    public GameObject Pizduk;
    public Transform shotDir;
    public int Timer = 1;
    public int TimToSpavn = 400;
    public int PizdukColmaxs = 25;
    public int PizdukCol;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer++;
        if (TimToSpavn < Timer & PizdukCol < PizdukColmaxs & PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(Pizduk.name, shotDir.position, transform.rotation);
            Timer = 0;
            PizdukCol++;
        }

    }
}
