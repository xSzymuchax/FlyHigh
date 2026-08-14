using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float jumpForce = 100f;
    public KeyCode jumpKey = KeyCode.Space;
    public float rotationSpeed = 10f;

    public ParticleSystem bloodParticle;
    public ParticleSystem jumpParticle;
    public Transform jumpParticleSpawner;

    private bool isAlive = true;
    private Rigidbody rb;

    public AudioClip jumpSound;
    public AudioClip deathSound;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Jump();
        //rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
            return;

        Turn();

        if (Input.GetKeyDown(jumpKey) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard"))
        {
            Die();
        }
    }

    public bool Lives()
    {
        return isAlive;
    }

    public void Jump()
    {
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(0, jumpForce, 0));

        GameObject go = Instantiate(jumpParticle.gameObject, jumpParticleSpawner.transform);
        go.transform.SetParent(GameObject.Find("ObstaclesContainer").transform);

        audioSource.clip = jumpSound;
        if (SoundController.instance.effectsActive)
            audioSource.Play();
    }

    public void Turn()
    {
        float minRotation = 50f; 
        float maxRotation = -80f; 
    
        float verticalVelocity = rb.velocity.y;
        float rotation = Mathf.Clamp(-verticalVelocity * rotationSpeed, maxRotation, minRotation);

        transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, rotation); 
}

    public void Die()
    {
        if (!isAlive)
            return;

        isAlive = false;
        GameController.instance.EndGame();
        rb.constraints = RigidbodyConstraints.None;

        GameObject go = Instantiate(bloodParticle.gameObject, transform);
        go.transform.SetParent(GameObject.Find("ObstaclesContainer").transform);

        audioSource.clip = deathSound;
        if (SoundController.instance.effectsActive) 
            audioSource.Play();

        // -2 -> blood particle system is on the end of player's prefab
        for (int i = transform.childCount - 2; i >= 0; i--)
        {
            transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
            transform.GetChild(i).gameObject.GetComponent<MeshCollider>().enabled = true;
        }
            
    }
}
