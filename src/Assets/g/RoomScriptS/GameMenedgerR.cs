using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameMenedgerR : MonoBehaviour
{
    public GameObject Plaer;
    public GameObject[] Plaers;
    //public GameObject Tawer;
    public float minX, minY, maxX, maxY;
    public GameObject StartOfRoomThis;
    public GameObject[] EndOfRoomThis;
    public GameObject[] Room;

    public Text EndText;
    public Text HpText;
    public string EndTextText;
    public string HpTextText;
    public GameObject EndConvas;
    public int XP = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 radomePosition = new Vector2(Random.Range(minX, minY), Random.Range(maxX, maxY));
        //if (PhotonNetwork.IsMasterClient)
        //    PhotonNetwork.Instantiate(Tawer.name, radomePosition, Quaternion.identity);

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

    public void AddRoom(int k)
    { 
        EndOfRoomThis = GameObject.FindGameObjectsWithTag("EndOfRoom");
        for (int i = 0; i < k; i++)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                GameObject Ro5om = PhotonNetwork.Instantiate(Room[1].name, EndOfRoomThis[i].transform.position, Quaternion.identity);
                //RoomMenegerScript Roomf  = Ro5om.GetComponentInChildren<RoomMenegerScript>();
                // Ro5om.transform.position = EndOfRoomThis.transform.position + Roomf.StartOfRoom.transform.position;

            }
            Destroy(StartOfRoomThis);
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

        EndTextText = "Финальный счет = " + XP;
        EndText.text = EndTextText;
        EndConvas.SetActive(true);
    }
    public void TheWardo() { Time.timeScale = 0f; }
    public void Exit() { Application.Quit(); }

}
