using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : ObstacleController
{
    public bool birdActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FlyController>() != null)
            birdActive = true;
    }

    public override void MoveObstacle()
    {
        if (!GameController.instance.gameActive)
            return;

        if (birdActive)
            transform.position = new Vector3(transform.position.x - GameController.instance.GameSpeed * 2f, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x - GameController.instance.GameSpeed, transform.position.y, transform.position.z);

    }
}
