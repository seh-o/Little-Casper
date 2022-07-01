using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class finish : MonoBehaviour
{

    
    public AudioSource fireworkaudiosourch;


    void Start()
    {
        
        fireworkaudiosourch.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiscripts.ýnstance.openWiNSCREEN();
            fireworkaudiosourch.Play();
        }

    }
}