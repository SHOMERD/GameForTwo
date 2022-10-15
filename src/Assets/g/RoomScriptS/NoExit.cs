using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class NoExit : MonoBehaviour
{
    public GameObject ExitCloser;
    public GameObject ExitPoint;
    public GameObject DameCloser;

    

    void Start()
    {
        int e = Random.Range(0, 100);   
        if ( e >= 60)
        {
            CloceDoor();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Room")
        {
            DameCloser.SetActive(true);
            Invoke("Chek", 2);
        }
    }
    public void CloceDoor()
    {
        ExitCloser.SetActive(true);
        Destroy(ExitPoint);
    }

    public void Chek()
    {
        if (!DameCloser.GetComponent<DameCloser>().ChekIxist())
        {
            Debug.Log("Удолено");
            CloceDoor();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
