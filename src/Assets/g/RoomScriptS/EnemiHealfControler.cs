using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;



public class EnemiHealfControler : MonoBehaviourPun
{
    RoomMenegerScript roomMenegerScript;
    public float hp = 100;
    public GameObject Bafer;
    public int XP;
    public int EnemySeed;


    void Start()
    {
        if(PhotonNetwork.IsMasterClient) {
            GetComponent<EnemyMuverRoom>().EnemySeed = EnemySeed;
            for (int i = 0; i < XP / 10; i++)
            {
                photonView.RPC("BafEnemi", RpcTarget.AllBuffered, Random.Range(1, 10));
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RoomMeneger")
        {
            roomMenegerScript = collision.GetComponent<RoomMenegerScript>();
        }

    }

    public void Destroy()
    {
        Destroy(gameObject);
        roomMenegerScript.KiledEnemy();
    }

    public void GetDamedge(int damedg)
    {
        photonView.RPC("synchronizationHP", RpcTarget.AllBuffered, hp - damedg);
    }


    [PunRPC]
    public void synchronizationHP(float MasterHP)
    {
        hp = MasterHP;
        if (hp < 0){
            
            if ((Random.Range(0, 100) >= 80) && PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(Bafer.name, transform.position, transform.rotation);   
            } 
                     
            Destroy();
        }
    }

    [PunRPC]
    public void BafEnemi(int BafTipeOnline){
        try{
            switch (BafTipeOnline)
            {
                case 1:
                    GetComponentInChildren<EnemyGunScript>().ReShootTime *= 0.9;
                    break;
                case 2:
                    GetComponent<EnemyMuverRoom>().speedN *= 1.1f;
                    break;
                case 3:
                    Vector3 SC = GetComponentInChildren<EnemyGunScript>().shotDir.localScale * 1.2f;
                    GetComponentInChildren<EnemyGunScript>().shotDir.localScale = SC;            
                    break;
                case 4:    
                    GetComponentInChildren<EnemyGunScript>().AmmoSpeed *= 1.2f;
                    break;
                case 5: 
                    GetComponentInChildren<EnemyGunScript>().AmmoDamedge = (int)Math.Round(GetComponentInChildren<EnemyGunScript>().AmmoDamedge * 1.2f);       
                    break;
                default:
                    break;
            }
            
        }
        catch (System.Exception)
        {}
    }



}


