using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG. Tweening;
public class COINBAUNCE : MonoBehaviour
{
    public Vector2  movetoposition;
    public Vector2  movefromposition;
    public  Vector2  moveoffsetposition;
    private Ease easeTYPE;
    public Tween currettwenn;
    public Ease EaseTYPE
    {
        get{
            return easeTYPE;
            }
        set{
            easeTYPE = value;
            currettwenn.Kill();
            Movetween();         
        }
    }
    public void Start(){

        movefromposition = transform.position;
        movetoposition=movefromposition+ moveoffsetposition;
        Movetween();
    }
    void Movetween()
    {
      currettwenn=  transform.DOMove  (movetoposition, 1f).From(movefromposition).SetEase(EaseTYPE). SetLoops(-1,LoopType.Yoyo);
    }
}
