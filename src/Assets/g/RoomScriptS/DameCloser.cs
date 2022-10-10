using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameCloser : MonoBehaviour
{
    public GameObject ExitPoint;
    public bool CanIxist = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LevelObject")
        {
            CanIxist = true;
        }
    }

    public bool ChekIxist()
    {
        return CanIxist;
    }

}
