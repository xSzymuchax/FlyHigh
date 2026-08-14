using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class VerticalMovingObstacle : ObstacleController
{
    public float verticalSpeed = 0.015f;
    public float maxverticalSpeed = 0.1f;
    public float maxOffset = 2f;

    private Vector3 startPosition;
    private float maxPosition;
    private float minPosition;

    private int movingDirection = 1;

    private void Start()
    {
        GenerateMoveBounds();
        GenerateMovingDirection();
        GenerateVerticalSpeed();
    }

    private void FixedUpdate()
    {
        MoveObstacle();
        VerticalMove();
    }

    public void VerticalMove()
    {
        if (movingDirection == 1)
        {
            transform.position += new Vector3(0, verticalSpeed, 0);
            if (transform.position.y > maxPosition)
                movingDirection *= -1;
        }

        else
        {
            transform.position -= new Vector3(0, verticalSpeed, 0);
            if (transform.position.y < minPosition)
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
        startPosition = transform.position;

        // y = [2, 8] -> max boundaries obstacle can be
        // minPosition -> 2
        // maxPosition -> 8
        // if obstacle spawned not in [4,6], we have to move it

        if (startPosition.y > 6)
            startPosition.y = 6;
        if (startPosition.y < 2)
            startPosition.y = 4;

        transform.position = startPosition;

        maxPosition = startPosition.y + maxOffset;
        minPosition = startPosition.y - maxOffset;
    }

    public void GenerateVerticalSpeed()
    {
        verticalSpeed = Random.Range(0, maxverticalSpeed);
    }
}
