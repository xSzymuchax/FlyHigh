using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour, Obstacle
{
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObstacle();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public IEnumerator DieAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Die();
    }

    public virtual void MoveObstacle()
    {
        if (!GameController.instance.gameActive)
            return;

        transform.position = new Vector3(transform.position.x - GameController.instance.GameSpeed, transform.position.y, transform.position.z);
    }
}
