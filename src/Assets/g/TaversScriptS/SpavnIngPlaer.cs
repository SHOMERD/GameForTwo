using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpavnIngPlaer : MonoBehaviour
{
    public GameObject Plaer;
    public GameObject Tawer;
    public float minX, minY, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 radomePosition = new Vector2(Random.Range(minX, minY), Random.Range(maxX, maxY));
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.Instantiate(Tawer.name, radomePosition, Quaternion.identity);
        
        PhotonNetwork.Instantiate(Plaer.name, radomePosition, Quaternion.identity);

    }

}
