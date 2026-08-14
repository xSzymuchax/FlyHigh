using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingObstacle : ObstacleController
{
    public float horizontalSpeed = 0.015f;
    public float maxhorizontalSpeed = 0.1f;
    public float maxOffset = 2f;

    public GameObject Obstacle;

    private Vector3 startPosition;
    private float maxPosition;
    private float minPosition;

    private int movingDirection = 1;

    private void Start()
    {
        GenerateMoveBounds();
        GenerateMovingDirection();
        GenerateHorizontalSpeed();
    }

    private void FixedUpdate()
    {
        MoveObstacle();
        HorizontalMove();
    }

    public void HorizontalMove()
    {
        if (movingDirection == 1)
        {
            Obstacle.transform.position += new Vector3(horizontalSpeed, 0, 0);
            if (Obstacle.transform.localPosition.x > maxPosition)
                movingDirection *= -1;
        }

        else
        {
            Obstacle.transform.position -= new Vector3(horizontalSpeed, 0, 0);
            if (Obstacle.transform.localPosition.x < minPosition)
                movingDirection *= -1;
        }
    }

    public void GenerateMovingDirection()
    {
        movingDirection = Random.Range(0, 2);
        if (movingDirection == 0)
            movingDirection = -1;
    }

    public void GenerateMoveBounds()
    {
        startPosition = Obstacle.transform.localPosition;
        maxPosition = startPosition.x + maxOffset;
        minPosition = startPosition.x - maxOffset;
    }

    public void GenerateHorizontalSpeed()
    {
        horizontalSpeed = Random.Range(0, maxhorizontalSpeed);
    }
}
