using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HilingAria : MonoBehaviour
{
    float timer = 0f;
    int CanHiling = 0;
    public GameObject Mi, NotMi;
    Vector3 SC;

    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SC = transform.localScale * (timer / 265);
        NotMi.transform.localScale =SC;
        if (CanHiling > 0 )
        {
            timer++;
        }
        else
        {
            timer = 0;
        }
        if (timer > 256)
        {
            ReLive();
        }
    }

    public void ReLive()
    {
        GuyScript k = GetComponentInParent<GuyScript>();
        k.Elave = true;
        k.hp =(k.StartHp * 75 / 100);
        k.slider.value = (k.StartHp * 75 / 100);
        k.Elave = true;
        Mi.SetActive(false);
        NotMi.SetActive(false);
    }
    public void StartHill()
    {
        NotMi.SetActive(true);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            CanHiling++;
            StartHill();

        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CanHiling--;
        }
    }
}
