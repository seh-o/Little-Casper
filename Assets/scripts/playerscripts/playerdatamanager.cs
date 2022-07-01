using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerdatamanager : MonoBehaviour
{
    public static playerdatamanager instancee;
    public static playerdatamanager Instance
    {
        get
        {
            if (instancee == null)
            {
               instancee= FindObjectOfType<playerdatamanager>();
            }
            if (instancee == null)
            {
                GameObject obj = new GameObject();
                obj.name = nameof(playerdatamanager);
                obj.AddComponent<playerdatamanager>();
                DontDestroyOnLoad(obj);
            }
            
            return instancee;
        }
       private set
        {

        }
    }

    public playerdata playerData = new playerdata();
    public playerscrips currentplayer;
    public UnityAction<int> oncoindatachanged;
    public UnityAction<int> onlifedatachanged;

    private void Awake()
    {
        if (instancee= null)
        {

           instancee = this;
                DontDestroyOnLoad(gameObject);
            
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
  
   public void Start()
    {
        playerData.currenthealty = playerData.maxhealty;
     playerData.currenthearts = playerData.maxhearts;
        playerData.collectedcoinamount = 0;
        currentplayer = FindObjectOfType<playerscrips>();
       currentplayer.oncoincollected += oncoincollected;
        currentplayer.Updateheartimages += onhealthchanged;


    }
    public void oncoincollected(int coinamount)
    {
        playerData.collectedcoinamount += coinamount;
        oncoindatachanged?.Invoke(playerData.collectedcoinamount);
    }
    public void onhealthchanged(int changedamount)
    {
        onlifedatachanged?.Invoke(playerData.currenthearts);
        playerData.currenthearts += changedamount;
        if (playerData.currenthearts <= 0)
        {
            uiscripts.ýnstance.openLOSESCREEN();
        }
    }
}
