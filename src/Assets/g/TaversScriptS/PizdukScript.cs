using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizdukScript : MonoBehaviour
{
    public float Speed = 16f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("412").GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);

    }

}