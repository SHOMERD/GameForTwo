using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameConect : MonoBehaviourPunCallbacks
{
    public InputField Create;
    public InputField Joing;

    public void CreateRoom()
    {
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = 16;
        PhotonNetwork.CreateRoom("1234", roomOption);
    }


    public void JoinRoon()
    {       
        PhotonNetwork.JoinRoom("1234");
    }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.LoadLevel("GameRoom");
        PhotonNetwork.LoadLevel("ManyRooms");
    }


    void Start()
    {
        
    }


}
