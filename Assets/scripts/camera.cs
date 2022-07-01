using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
   private Transform player;
    [SerializeField]
    private float playerx;
    [SerializeField]
    private float playery;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float pozx = Mathf.MoveTowards(transform.position.x, player.position.x, playerx);
        float pozy = Mathf.MoveTowards(transform.position.y, player.position.y, playery);
        transform.position = new Vector3(pozx, pozy, transform.position.z);
    }
}
