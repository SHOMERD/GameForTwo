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

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "enemy")
        {
            try
            {
                enemyScriptRoom = collision.GetComponent<EnemyScriptRoom>();
                enemyScriptRoom.GetDamedge(1100);
            }
            catch (System.Exception)
            {
                Debug.LogWarning("Ankilebele target");
                Destroy(collision);
                throw;
            }
            enemyScriptRoom = collision.GetComponent<EnemyScriptRoom>();
            enemyScriptRoom.GetDamedge(50);
            //Destroy(collision.gameObject);
            Destroy();

        }
        if (collision.tag == "AmmoDestroer")
        {
            Destroy();

        }

        
    }


    //}
}
