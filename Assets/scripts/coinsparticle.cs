using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class coinsparticle : MonoBehaviour
{
    public GameObject coinparticle;
    public int countamount = 10;
    public AudioSource coinsource;
    public AudioClip coinclip;

    void Spawncoinparticle()
    {
        GameObject gameObject= Instantiate(coinparticle,transform.position,Quaternion.identity,null);
        ParticleSystem objparticalsystem = gameObject.GetComponent<ParticleSystem>();
        float lifetime = objparticalsystem.main.startLifetime.constant;
        Destroy(gameObject,lifetime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Spawncoinparticle();
            other.GetComponent<playerscrips>().CoinCollected(countamount);
            other.GetComponent<playerscrips>().StartCoroutine(slowmo());
            coinsource.PlayOneShot(coinclip);
            Destroy(gameObject);
        }

    }
    IEnumerator slowmo()
    {
        
        float endtimescale = 0.5f;
        float chengebytime = 0.5f;
        while(!Mathf.Approximately(Mathf.Abs(Time.timeScale - endtimescale),0))
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, endtimescale, chengebytime * 0.016f);
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
}
