using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public float maxRotate = 30f;

    private void Start()
    {
        float rotation = Random.Range(-maxRotate, maxRotate);
        gameObject.transform.Rotate(0, 0, rotation);
    }
}
