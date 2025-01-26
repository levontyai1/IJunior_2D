using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class SpawnReturned : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoints;
    [SerializeField] private GameObject _spawnPointPrefab;

    private void Start()
    {
        StartCoroutine(Spawner(_spawnPoints.GetComponentsInChildren<Transform>()));
    }

    private IEnumerator Spawner(Transform[] spawnPoints)
    {
        var wait = new WaitForSeconds(2f);
        Random random = new Random();
        for (int i = 0; i < 36; i++)
        {
            Instantiate(_spawnPointPrefab, spawnPoints[random.Next(1, spawnPoints.Length)].position, Quaternion.identity);
            yield return wait;
        }
    }
}
