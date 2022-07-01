using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class uiscripts : MonoBehaviour
{
    public static uiscripts ınstance;
    public Image healthımage;
    public TextMeshProUGUI cointext;
    public GameObject winscreen;
    public GameObject losescreen;
    public Image[] heartimage;
    public void Awake()
    {
       ınstance = this;
    }
    public void Start()
    {
        playerdatamanager.Instance.oncoindatachanged += Updatecoıntext;
        playerdatamanager.Instance.onlifedatachanged += Updateheartimages;
       // playerscrips currentplayer = FindObjectOfType<playerscrips>();
       // currentplayer.oncoincollected += Updatecoıntext;
        //currentplayer.Updateheartimages += Updateheartimages;

        setgamespeed(1f);
    }
    public void setgamespeed(float gamespeed)
    {
        Time.timeScale = gamespeed;
    }
    public void Undatehealtyımage(float FILLAMOUNT)
    {
        healthımage.fillAmount = FILLAMOUNT;

    }
    public void Updateheartimages(int index)
    {
       
        for (int i = 0; i < heartimage.Length; i++)
        {
            if (i < index)
            {
                heartimage[i].enabled = true;
            }
            else
            {
                heartimage[i].enabled = false;
            }

        }
        for (int i = 0; i < index; i++)
        {
            heartimage[i].enabled = true;
        }
        
    }
    public void Updatecoıntext(int coınttamouuunt)
    {
        cointext.text = playerdatamanager.Instance.playerData.collectedcoinamount.ToString();
    }
   public void openWiNSCREEN()
    {
        winscreen.SetActive(true);
        setgamespeed(0);
    }
    public void openLOSESCREEN()
    {
        losescreen.SetActive(true);
        setgamespeed(0);
    }
  
}
