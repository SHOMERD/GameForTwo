using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GuyScript : MonoBehaviourPun
{
    public float StartHp = 1000;
    public float hp;
    public float speedN = 11f;

    public PhotonView view;
    TawerScript tawerScript;
    RoomMenegerScript roomScript;
    GameMenedgerR gameMenedgerR;
    private Rigidbody2D rb;
    public GameObject Camera;
    public Slider slider;
    public GameObject Convas;
    public bool Elave = true;
    private SpriteRenderer sprite;
    public GameObject HilAria;


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (!photonView.IsMine)
        {
            Camera.SetActive(false);
            Convas.SetActive(false);
        }
        hp = StartHp;
        slider.maxValue = StartHp;
        slider.value = hp;
        gameMenedgerR = GameObject.FindGameObjectWithTag("Helper").GetComponent<GameMenedgerR>();


    }
    private void RunR()
    {
        Vector3 RightAndLeft = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + RightAndLeft, speedN * Time.deltaTime);
    }
    private void RunU()
    {
        Vector3 UpAndDaun = transform.up * Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + UpAndDaun, speedN * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (Elave)
        {
            if (Input.GetButton("Horizontal") & photonView.IsMine)
                RunR();
            if (Input.GetButton("Vertical") & photonView.IsMine)
                RunU();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "tawer")
        {
            tawerScript = collision.GetComponent<TawerScript>();
            tawerScript.HanliHil(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "tawer")
        {
            tawerScript = collision.GetComponent<TawerScript>();
            tawerScript.HanliHil(false);
        }
    }
    public void GetDamedge(float damedg)
    {
        if (Elave)
        {
            photonView.RPC("synchronization", RpcTarget.AllBuffered, hp - (damedg / 2));
            if (hp < 0)
            {
                IDed();
            }
            slider.value = hp;
        }
    }
    public void EnterThisRoom(Transform TpPoint)
    {

        //photonView.RPC("synchronizationP", RpcTarget.AllBuffered, photonView.viewID); 
    }

    public void IDed()
    {
      //  sprite.color = Color.red;
        Elave = false;
        int plaercol = gameMenedgerR.SomoneDie();
        if (plaercol > 0 || true)
        {
            HilAria.SetActive(true);
            HilAria.GetComponentInChildren<HilingAria>().StartHill();
        }
        else
        {

        }
    }



    [PunRPC]
    public void synchronization(float MasterHP)
    {
        hp = MasterHP;
    }
}

