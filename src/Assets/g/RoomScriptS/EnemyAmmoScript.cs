using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class EnemyAmmoScript : MonoBehaviour
{
    EnemyScriptRoom enemyScriptRoom;
    
    public int Damedge = 50;
    public float speed = 8f;

    GuyScript guyScript;

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

        if (collision.tag == "Player")
        {
            guyScript = collision.GetComponent<GuyScript>();
            guyScript.GetDamedge(100);
            //Destroy(collision.gameObject);
            Destroy();

        }
        if (collision.tag == "AmmoDestroer")
        {
            Destroy();

        }
        if (collision.tag == "LevelObject")
        {
            Destroy();
        }

        
    }




    // // Start is called before the first frame update
    // void Start()
    // {
    //     Invoke("Destroy", 4);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     transform.Translate(Vector2.right * speed * Time.deltaTime);
    // }

    // void Destroy()
    // {
    //     Destroy(gameObject);
    // }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {

    //     if (collision.tag == "Player")
    //     {
    //         guyScript = collision.GetComponent<GuyScript>();
    //         guyScript.GetDamedge(100);
    //         //Destroy(collision.gameObject);
    //         Destroy();

    //     }
    //     if (collision.tag == "AmmoDestroer")
    //     {
    //         Destroy();

    //     }


    // }
    // //public void GetDamedge(int damedg) {
    // //    hp = hp - damedg;


    // //}
}
