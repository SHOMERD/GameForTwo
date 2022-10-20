using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class NoExit : MonoBehaviourPun
{
    public GameObject ExitCloser;
    public GameObject ExitPoint;
    public GameObject DameCloser;

    

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            int e = Random.Range(0, 100);   
            if ( e >= 60)
            {
                ClosForAll();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Room" && PhotonNetwork.IsMasterClient)
        {
            DameCloser.SetActive(true);
            Invoke("Chek", 2);
        }
    }
    

    public void Chek()
    {
        if (!DameCloser.GetComponent<DameCloser>().ChekIxist())
        {
            Debug.Log("�������");
            ClosForAll();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    public void ClosForAll()
    {
        photonView.RPC("CloceDoor", RpcTarget.AllBuffered);
    }


    [PunRPC]
    public void CloceDoor()
    {
        ExitCloser.SetActive(true);
        Destroy(ExitPoint);
    }

}
