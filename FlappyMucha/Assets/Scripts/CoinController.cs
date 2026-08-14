using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : ObstacleController
{
    public ParticleSystem collectedParticle;
    public float dieTime = 2f;
    public AudioClip collectedSound;

    protected AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collectedSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FlyController>() != null)
        {
            GameController.instance.AddPoint();
            ShopController.instance.AddCoin();
            collectedParticle.Play();
            
            if (SoundController.instance.effectsActive) 
                audioSource.Play();
            
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(DieAfterTime(dieTime));
        }
    }

}
