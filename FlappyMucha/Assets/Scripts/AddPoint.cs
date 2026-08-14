using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    public AudioClip addPointSound;

    private void OnTriggerEnter(Collider other)
    {
        FlyController fc = other.GetComponent<FlyController>();
        if (fc != null)
        {
            GameController.instance.AddPoint();

            if (SoundController.instance.effectsActive)
                AudioSource.PlayClipAtPoint(addPointSound, transform.position);

            enabled = false;
        }
            

    }
}
