using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyGunScript : MonoBehaviourPun
{
    public float offset;
    public float speedN = 10F;
    public GameObject ammo;
    public Transform shotDir;
    public PhotonView view;
    public Transform player;

    public double ReShootTime = 50;
    public int ShootTimrt = 0;
    public int AmmoDamedge = 50;
    public float AmmoSpeed = 8f;

    void Awake()
    {
        ReShootTime = 70;
    }
    // Start is called before the first frame update
    private void FixedUpdate() {
        ShootTimrt++;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 differense = player.position - transform.position;
        float RotateZ = Mathf.Atan2(differense.y, differense.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotateZ + offset);
        
        if (ShootTimrt > ReShootTime)
        {
            ShootTimrt = 0;
            Shot();
        }
            
    }

    public void Shot(){
        GameObject Ammo = PhotonNetwork.Instantiate(ammo.name, shotDir.position, transform.rotation);
        AmmoConstructor(Ammo);
    }

    public void AmmoConstructor(GameObject Ammo)
    {
        Ammo.transform.localScale = shotDir.localScale;
        EnemyAmmoScript AmmoScript = Ammo.GetComponent<EnemyAmmoScript>();
        AmmoScript.Damedge = AmmoDamedge;
        AmmoScript.speed = AmmoSpeed;
    }

    // // Start is called before the first frame update
    // 

    // // Update is called once per frame
    // 

    // }
    // Shot(){
    //     PhotonNetwork.Instantiate(ammo.name, shotDir.position, transform.rotation);
    // }
}