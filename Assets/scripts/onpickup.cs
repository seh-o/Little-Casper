using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class onpickup : MonoBehaviour
{  
    public AudioSource  coinbauntsource;
    public AudioClip cointsound ;
     void OnDisable()
    {
        coinbauntsource.PlayOneShot(cointsound);

    }
  
}
