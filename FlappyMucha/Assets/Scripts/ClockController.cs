using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : CoinController
{
    public float rotationSpeed = 90f; // Prêdkoœæ obrotu w stopniach na sekundê
    public float timeBonus = 2f;

    private float targetAngle = 360f;
    private float currentAngle = 0f;
    private float rotationTime = 2f;
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float progress = elapsedTime / rotationTime;
        currentAngle = Mathf.Lerp(0, targetAngle, progress);
        transform.rotation = Quaternion.Euler(0, currentAngle, 0);

        if (progress >= 1)
            elapsedTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FlyController>() != null)
        {
            collectedParticle.Play();
            GameController.instance.AddTime(timeBonus);

            if (SoundController.instance.effectsActive)
                audioSource.Play();

            foreach (Transform t in transform)
            {
                MeshRenderer mr = t.gameObject.GetComponent<MeshRenderer>();
                if (mr != null)
                    mr.enabled = false;
            }
            


            GetComponent<SphereCollider>().enabled = false;
            StartCoroutine(DieAfterTime(dieTime));
        }
    }
}
