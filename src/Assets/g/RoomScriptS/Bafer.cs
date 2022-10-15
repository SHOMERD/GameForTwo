using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bafer : MonoBehaviour
{
    public int BafTipe = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MaceBaf(collision);

            // collision.GetComponentInChildren<Gun>().ReShootTime = 5;
            // GuyScript guyScript = collision.GetComponent<GuyScript>();
            //Destroy(collision.gameObject);
        }  
    }

    public void MaceBaf(Collider2D BafedObject) 
    {
        switch (BafTipe)
        {
            case 1:
                BafedObject.GetComponentInChildren<Gun>().ReShootTime *= 0.9;
                break;
            case 2:
                BafedObject.GetComponent<GuyScript>().GetDamedge(-200);
                break;
            case 3:
                BafedObject.GetComponent<GuyScript>().speedN *= 1.1f;
                break;
            case 4:
                
                break;
            case 5:
                
                break;
            default:
                break;
        }
                

    }
}
