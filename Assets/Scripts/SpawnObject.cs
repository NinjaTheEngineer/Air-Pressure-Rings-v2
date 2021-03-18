using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float timeDifference;

    ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler._instance;

        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        objectPooler.SpawnFromPool("Bubble", CalculateRandomPosition(), Quaternion.identity);
        objectPooler.SpawnFromPool("Bubble", CalculateRandomPosition(), Quaternion.identity);
        objectPooler.SpawnFromPool("Bubble", CalculateRandomPosition(), Quaternion.identity);
        yield return new WaitForSeconds(timeDifference);
        StartCoroutine(StartSpawning());

    }
    /*
    public GameObject GenerateObjectToSpawn()
    {
        GameObject toSpawn = objectToSpawn;
        toSpawn.transform.localScale = GenerateRandomScale();
        return toSpawn;
    }*/

    public Vector3 GenerateRandomScale()
    {
        float randomScale = UnityEngine.Random.Range(0.5f, 2.5f);
        return new Vector3(randomScale, randomScale, randomScale);
    }
    public Vector3 CalculateRandomPosition()
    {

        float randomX = UnityEngine.Random.Range(0.5f, 24.5f);
        float randomY = UnityEngine.Random.Range(7, 10f);
        float randomZ = UnityEngine.Random.Range(-9.5f, -4.5f);

        Vector3 position = new Vector3(randomX, randomY, randomZ);
        return position;

    }
}
