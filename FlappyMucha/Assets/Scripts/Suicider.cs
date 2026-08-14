using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicider : MonoBehaviour
{
    public float time=10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Suicide());
    }

    private IEnumerator Suicide()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
