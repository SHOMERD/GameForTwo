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

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 differense = player.position - transform.position;
        float RotateZ = Mathf.Atan2(differense.y, differense.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotateZ + offset);
        
        if (Input.GetMouseButtonDown(0))
        {
            PhotonNetwork.Instantiate(ammo.name, shotDir.position, transform.rotation);

        }

    }
}