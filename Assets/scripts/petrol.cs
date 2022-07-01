using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class petrol : MonoBehaviour

{
    public Vector2 startposition;
    public Vector2 endposition;
    public float movementtime;
    public Ease petrolmovenmentease;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
        startpetrolmovenment();
        
    }
    void startpetrolmovenment()
    {
        transform.DOMove(endposition, movementtime).From(startposition).SetLoops(-1,LoopType.Yoyo).SetEase(petrolmovenmentease);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
