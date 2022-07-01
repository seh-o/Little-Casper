using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class playerdata 
{
    public float currenthealty;
    public float maxhealty = 100f;
    public int currenthearts = 0;
    public int maxhearts = 3;
    public int collectedcoinamount = 0;


}
public class EntityData
{
    public int heartamount;
    public int speed;
    public int attack;
    
}
public class entitycontroller
{
 protected EntityData data;
    public virtual void healhearts(int amount)
    {
        data.heartamount +=Mathf.Abs( amount);
    }
}
public class enemycontroller: entitycontroller
{
    public UnityAction<int> onheartchanged;
    public override void healhearts(int amount)
    {
        data.heartamount += Mathf.Abs(amount);
        onheartchanged?.Invoke(data.heartamount);
    }
}
public class enemyview:MonoBehaviour
{
    public enemycontroller encontr;
    public Animator enemyanimatör;
    public AudioClip attacksound;
}
