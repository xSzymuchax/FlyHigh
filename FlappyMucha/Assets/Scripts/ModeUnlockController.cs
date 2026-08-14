using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ModeUnlockController : MonoBehaviour
{
    public static ModeUnlockController instance;

    public int timeAttack = 0;
    public int crazy = 0;
    public int timeAttackCrazy = 0;

    public GameObject timeAttackBlocked;
    public GameObject timeAttackUnlocked;

    public GameObject crazyBlocked;
    public GameObject crazyUnlocked;

    public GameObject timeAttackCrazyBlocked;
    public GameObject timeAttackCrazyUnlocked;

    private void Start()
    {
        instance = this;
        UnlockModes();
    }

    public void UnlockModes()
    {
        if (GameController.instance.highscoreClassic >= 30)
            timeAttack = 1;

        if (GameController.instance.highscoreClassic >= 50)
            crazy = 1;

        if (GameController.instance.highscoreCrazy >= 50)
            timeAttackCrazy = 1;

        if (timeAttack == 1)
        {
            timeAttackBlocked.SetActive(false);
            timeAttackUnlocked.SetActive(true);
        }

        if (crazy == 1)
        {
            crazyBlocked.SetActive(false);
            crazyUnlocked.SetActive(true);
        }

        if (timeAttackCrazy == 1)
        {
            timeAttackCrazyBlocked.SetActive(false);
            timeAttackCrazyUnlocked.SetActive(true);
        }


    }
}
