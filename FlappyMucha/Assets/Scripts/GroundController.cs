using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject plane1;
    public GameObject plane2;

    private Vector3 plane2StartPosition;

    public Transform resetPoint;

    private void Start()
    {
        plane2StartPosition = plane2.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameController.instance.backgroundActive)
            return;

        plane1.transform.position += new Vector3(-GameController.instance.GameSpeed, 0, 0);
        plane2.transform.position += new Vector3(-GameController.instance.GameSpeed, 0, 0);

        if (plane1.transform.position.x < resetPoint.position.x)
            plane1.transform.position = plane2StartPosition;

        if (plane2.transform.position.x < resetPoint.position.x)
            plane2.transform.position = plane2StartPosition;

    }
}
