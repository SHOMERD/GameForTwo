using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviourPun
{
    public float offset;
    public float speedN=10F;
    public GameObject ammo;
    public Transform shotDir;
    public PhotonView view;
    GuyScript guyScript;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        guyScript = GetComponentInParent<GuyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine & guyScript.Elave)
        {
            Vector3 differense = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float RotateZ = Mathf.Atan2(differense.y, differense.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, RotateZ + offset);
        }
        if (Input.GetMouseButtonDown(0) & photonView.IsMine & guyScript.Elave)
        {
            PhotonNetwork.Instantiate(ammo.name, shotDir.position, transform.rotation);

        }
        
    }
}
