using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Random = System.Random;


public class GameMenedgerR : MonoBehaviour
{
    public GameObject Plaer;
    public GameObject[] Plaers;
    public float minX, minY, maxX, maxY;
    public GameObject StartOfRoomThis;
    public GameObject[] Room;
    public Random rnd;

    public Text EndText;
    public Text HpText;
    public string EndTextText;
    public string HpTextText;
    public GameObject EndConvas;
    public int XP = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 radomePosition = new Vector2(0, 0);
        PhotonNetwork.Instantiate(Plaer.name, radomePosition, Quaternion.identity);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void RoomClined()
    {

    }

    public int SomoneDie()
    {
        Plaers = GameObject.FindGameObjectsWithTag("Player");
        int ElavePlaer = 0;
        for (int i = 0; i < Plaers.Length; i++)
        {
            if (Plaers[i].GetComponent<GuyScript>().Elave)
                ElavePlaer++;
        }
        if (ElavePlaer == 0)
        {
            Invoke("EndeOfGame", 2);
        }
        return ElavePlaer;
    }

    public void AddRoom(GameObject[] EndOfRoomThis)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < EndOfRoomThis.Length; i++)
            {
                try
                {
                    GameObject Ro5om = PhotonNetwork.Instantiate(Room[0].name, EndOfRoomThis[i].transform.position, EndOfRoomThis[i].transform.rotation);
                    RoomMenegerScript Roomf = Ro5om.GetComponentInChildren<RoomMenegerScript>();
                    Roomf.XP = XP;
                }
                catch (System.Exception)
                {
                }

               
            }
        }
       

       
    }
    public void RoomMuver(GameObject Ro5om) 
    {

    }
    public void Reloud()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LoadLevel("GameRoom");
    }
    public void EndeOfGame()
    {

        EndTextText = "Фенальный счет = " + XP;
        EndText.text = EndTextText;
        EndConvas.SetActive(true);
    }
    public void TheWardo() { Time.timeScale = 0f; }
    public void Exit() { Application.Quit(); }

}
