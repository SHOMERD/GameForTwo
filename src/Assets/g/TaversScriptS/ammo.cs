using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;



public class ammo : MonoBehaviour
{
    public float speed = 8f;
    EnemyScriptRoom enemyScriptRoom;
    public int Damedge = 50;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 4);
    }

    public void Destroy(){
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "enemy")
        {
            try
            {
                enemyScriptRoom = collision.GetComponent<EnemyScriptRoom>();
                enemyScriptRoom.GetDamedge(Damedge);
            }
            catch (System.Exception)
            {
                Debug.LogWarning("Ankilebele target");
                Destroy(collision);
            }
            Destroy(gameObject);


        }
        if (collision.tag == "AmmoDestroer")
        {
            Destroy(gameObject);
        }

        
    }


    //}
}
