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

    public double ReShootTime = 30;
    public int ShootTimrt = 0;
    public int AmmoDamedge = 50;
    public float AmmoSpeed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        guyScript = GetComponentInParent<GuyScript>();
    }

    private void FixedUpdate() {
        ShootTimrt++;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine & guyScript.Elave)
        {
            Vector3 differense = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float RotateZ = Mathf.Atan2(differense.y, differense.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, RotateZ + offset);

            if (Input.GetMouseButtonDown(1) || (Input.GetMouseButton(0) && ShootTimrt > ReShootTime))
            {
                ShootTimrt = 0;
                Shot();
            }
        }
    }

    public void Shot(){
        GameObject Ammo = PhotonNetwork.Instantiate(ammo.name, shotDir.position, transform.rotation);
        AmmoConstructor(Ammo);
    }

    public void AmmoConstructor(GameObject Ammo)
    {
        Ammo.transform.localScale = shotDir.localScale;
        ammo AmmoScript = Ammo.GetComponent<ammo>();
        AmmoScript.Damedge = AmmoDamedge;
        AmmoScript.speed = AmmoSpeed;
    }
}
