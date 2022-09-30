using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;




public class CameraControler : MonoBehaviour
{

    public Transform position1;
    public float Speed = 1000f;
    Vector3 GoTo;
    public Vector3 offset = new Vector3(0, 0, -10);
    PhotonView view;


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        GoTo = position1.position;
        transform.position = Vector3.MoveTowards(transform.position, GoTo + offset, Speed * Time.deltaTime);
    }
}
