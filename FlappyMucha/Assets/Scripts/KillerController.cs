using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ObstacleController oc = collision.gameObject.GetComponent<ObstacleController>();
        
        if (oc != null)
            oc.Die();
    }
}
