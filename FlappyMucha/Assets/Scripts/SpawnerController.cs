using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private float baseSpawnDelay = 2f;
    public float spawnDelay = 2f;
    public float obstacleOffset = 3f;

    public GameObject coin;
    public GameObject czikinaget;
    public GameObject timeClock;

    public GameObject[] obstacles;
    public GameObject[] volumes;
    private int unlockedObstacle = 1;

    public Transform obstaclesContainer;
    public Transform volumesSpawner;

    public float volumespawntime = 1f;

    public IEnumerator StartSpawnerClassic()
    {
        int trapcount = 0;
        spawnDelay = baseSpawnDelay;
        while (GameController.instance.gameActive)
        {
            float accumulator = 0;

            // Dopóki akumulator jest mniejszy od spawnDelay
            while (accumulator < spawnDelay)
            {
                accumulator += Time.deltaTime;
                yield return null; // Oczekiwanie na nastêpn¹ klatkê
            }

            int obstacleID = Random.Range(0, unlockedObstacle);
            trapcount++;

            //obstacle
            GameObject newObstacle = Instantiate(obstacles[obstacleID]);
            newObstacle.transform.position = new Vector3(transform.position.x, transform.position.y + Random.value * obstacleOffset, transform.position.z);
            newObstacle.transform.SetParent(obstaclesContainer);

            if (newObstacle.transform.name.Contains("Wide"))
                yield return new WaitForSeconds(0.5f);

            //collectible (every 3 traps)
            if (trapcount % 3 == 0)
            {
                // 10% na czikinugets
                int chance = Random.Range(0, 100);

                if (chance < 10)
                    newObstacle = Instantiate(czikinaget);
                else
                    newObstacle = Instantiate(coin);

                newObstacle.transform.position = new Vector3(transform.position.x + 10, transform.position.y + 5, transform.position.z);
                newObstacle.transform.SetParent(obstaclesContainer);
            }
        }
    }

    public IEnumerator StartSpawnerTimeAttack()
    {
        int trapcount = 0;
        spawnDelay = baseSpawnDelay;
        while (GameController.instance.gameActive)
        {
            float accumulator = 0;

            // Dopóki akumulator jest mniejszy od spawnDelay
            while (accumulator < spawnDelay)
            {
                accumulator += Time.deltaTime;
                yield return null; // Oczekiwanie na nastêpn¹ klatkê
            }

            int obstacleID = Random.Range(0, unlockedObstacle);
            trapcount++;

            //obstacle
            GameObject newObstacle = Instantiate(obstacles[obstacleID]);
            newObstacle.transform.position = new Vector3(transform.position.x, transform.position.y + Random.value * obstacleOffset, transform.position.z);
            newObstacle.transform.SetParent(obstaclesContainer);

            if (newObstacle.transform.name.Contains("Wide"))
                yield return new WaitForSeconds(0.5f);

            //collectible (every 3 traps)
            if (trapcount % 3 == 0)
            {
                // 10% na czikinugets
                int chance = Random.Range(0, 100);

                if (chance < 10)
                    newObstacle = Instantiate(czikinaget);
                else
                    newObstacle = Instantiate(coin);

                newObstacle.transform.position = new Vector3(transform.position.x + 10, transform.position.y + 5, transform.position.z);
                newObstacle.transform.SetParent(obstaclesContainer);
            }

            //time (every 2 traps)
            if (trapcount % 2 == 0)
            {
                newObstacle = Instantiate(timeClock);
                newObstacle.transform.position = new Vector3(transform.position.x + 10 * Random.value, transform.position.y + 5 * Random.value, transform.position.z);
                newObstacle.transform.SetParent(obstaclesContainer);
            }
        }
    }

    public IEnumerator SpawnVolumes()
    {
        while (GameController.instance.gameActive)
        {
            yield return null; // Oczekiwanie na nastêpn¹ klatkê

            // Akumulator czasu
            float accumulator = 0;

            // Dopóki akumulator jest mniejszy od czasu spawnu
            while (accumulator < volumespawntime)
            {
                // Dodajemy do akumulatora czas, jaki up³yn¹³ od poprzedniej klatki
                accumulator += Time.deltaTime;
                yield return null; // Oczekiwanie na nastêpn¹ klatkê
            }

            // Losujemy indeks
            int volID = Random.Range(0, volumes.Length);

            // Tworzymy obiekt
            GameObject go = Instantiate(volumes[volID], volumesSpawner);
            go.transform.SetParent(obstaclesContainer);
        }
    }

    public void UnlockNextObstacle()
    {
        if (unlockedObstacle < obstacles.Length)
            unlockedObstacle++;
    }

    public void ResetUnlockedObstacles()
    {
        unlockedObstacle = 1;
    }

    public void SpeedUpSpawner(float amount)
    {
        spawnDelay -= amount;
    }
}
