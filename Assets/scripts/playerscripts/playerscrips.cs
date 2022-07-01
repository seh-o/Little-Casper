using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;
[System.Serializable]

public class playerscrips : MonoBehaviour
{
    public UnityAction<int> oncoincollected;
    public UnityAction<int> Updateheartimages;
    public UnityAction<KeyCode> Onkeypressed;
   
    
    
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Onkeypressed?.Invoke(KeyCode.UpArrow);         
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Onkeypressed?.Invoke(KeyCode.RightArrow);           
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            Onkeypressed?.Invoke(KeyCode.LeftArrow);          
       }
    }
    public void Updatehealty(int Updateamount)
    {
        Updateheartimages?.Invoke(Updateamount);
    }
    public void CoinCollected(int Coinamount)
    {
        oncoincollected?.Invoke(Coinamount);
    }
   

}

   

   

