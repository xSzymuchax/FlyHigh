using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duszek : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        Vector3 v3 = new Vector3(0, 600 ,0);
        rb.AddForce(v3);    
    }
}
