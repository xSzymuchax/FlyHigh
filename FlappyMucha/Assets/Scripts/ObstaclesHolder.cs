using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesHolder : MonoBehaviour
{
    public GameObject simple;
    public GameObject singleBird;
    public GameObject vertical;
    public GameObject horizontal;
    public GameObject doubleBird;
    public GameObject wideSimple;
    public GameObject rotatedSimple;
    public GameObject rotatedHorizontal;
    public GameObject rotatedVertical;

    public GameObject[] obstacles;

    private void Awake()
    {
        obstacles = new GameObject[] { simple, singleBird, vertical, horizontal, doubleBird, wideSimple, rotatedSimple, rotatedHorizontal, rotatedVertical };
    }

}
