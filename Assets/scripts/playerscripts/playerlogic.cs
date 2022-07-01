using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


public class playerlogic : MonoBehaviour
{
    public playerscrips currentpplayer;
    public float movementspeedmultiplier;
    public Rigidbody2D objrigidbody2D;
    public bool jumping = false;
    public bool ismevenmentjumping = false;

    public Animator playanimat�r;
    public AudioSource playeraudiosource;
    public AudioClip screemaudioclip;
    public AudioClip jumpaudioclip;

    public ParticleSystem particalsys;
    public ParticleSystem.MainModule playermoduleparticlesystem;
    public ParticleSystem.EmissionModule playeremisson;
    public GameObject playerhurt;
    private void Start()

    {
        objrigidbody2D = GetComponent<Rigidbody2D>();
        playanimat�r = GetComponent<Animator>();
        playermoduleparticlesystem = particalsys.main;
        playeremisson = particalsys.emission;


        if (currentpplayer == null)
        {
            currentpplayer = FindObjectOfType<playerscrips>();
        }
        if (currentpplayer != null)
        {
            currentpplayer.Onkeypressed += Onkeypressed;
        }
    }
    public void Onkeypressed(KeyCode pressed)
    {
        if (pressed== KeyCode.UpArrow)
        {         
            jumping = true;
            ismevenmentjumping = true;     
            playeremisson.rateOverDistance = 25f;
            playanimat�r.SetTrigger("jumptri");
            playeraudiosource.PlayOneShot(jumpaudioclip);
        }
        if (pressed == KeyCode.RightArrow)
        { 
            playanimat�r.SetBool("ismovinright", true);  
        }
        else if (pressed == KeyCode.LeftArrow)
        {
                      playanimat�r.SetBool("ismovingleft", true);
        }

        if (pressed == KeyCode.LeftArrow || pressed == KeyCode.RightArrow || pressed == KeyCode.UpArrow)
        {
            ismevenmentjumping = true;
        }
        else
        {
            playanimat�r.SetBool("ismovingleft", false);
            playanimat�r.SetBool("ismovinright", false);
            ismevenmentjumping = false;
        }

    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("train"))
        {
            particalsys.Play(withChildren: true);
            playeremisson.rateOverDistance = 5f;
            playanimat�r.SetTrigger("returnto�dl");

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject gameObject = Instantiate(playerhurt, transform.position, Quaternion.identity, null);
            playeraudiosource.PlayOneShot(screemaudioclip);

           currentpplayer. Updatehealty(-1);
        }
    }
   
   
  

    private void FixedUpdate()
    {
        float horizontalmovement = Input.GetAxis("Horizontal");
        Vector3 movenmentvektor = new Vector3(horizontalmovement, 0, 0);
        if (jumping)
        {
            Vector3 jumpvektor = new Vector3(0, movementspeedmultiplier, 0);
            objrigidbody2D.AddForce(jumpvektor, ForceMode2D.Impulse);
            jumping = false;

        }
        if (ismevenmentjumping)
        {
            objrigidbody2D.drag = 0f;
            objrigidbody2D.AddForce(movenmentvektor * movementspeedmultiplier, ForceMode2D.Force);

        }
        else
        {
            objrigidbody2D.drag = 1f;
        }
        if (objrigidbody2D.velocity.y < -3f)
        {
            playanimat�r.SetTrigger("failtri");

        }
        playanimat�r.SetFloat("Speed", objrigidbody2D.velocity.magnitude);



    }
}
