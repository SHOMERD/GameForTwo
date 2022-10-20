using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bafer : MonoBehaviour
{
    public int BafTipe = 1;
    // Start is called before the first frame update
    void Start()
    {
        BafTipe = Random.Range(1, 6); 
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            MaceBaf(collision);
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
                Vector3 SC = BafedObject.GetComponentInChildren<Gun>().shotDir.localScale * 1.2f;
                BafedObject.GetComponentInChildren<Gun>().shotDir.localScale = SC;
                break;
            case 5:
                BafedObject.GetComponentInChildren<Gun>().AmmoSpeed *= 1.2f;
                break;
            case 6:
                BafedObject.GetComponentInChildren<Gun>().AmmoDamedge = (int)Math.Round(BafedObject.GetComponentInChildren<Gun>().AmmoDamedge * 1.3f );
                break;
            default:
                break;
        }
        //BafedObject.GetComponent<GuyScript>().UpdatedGuy();
        Destroy(gameObject);

    }
}
