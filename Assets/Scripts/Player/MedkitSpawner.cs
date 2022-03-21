using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _minSpawnTime = 30;
    [SerializeField] float _maxSpawnTime = 100;
    [SerializeField] Transform _spawnPoint;
    float time;
    private void Update()
    {

        if (time <= Time.time)
        {
            GameObject newMedkit = Instantiate(_prefab);
            newMedkit.transform.position = new Vector2(_spawnPoint.position.x, _spawnPoint.position.y);
            time = Time.time + Random.Range(_minSpawnTime, _maxSpawnTime);
        }
    }
}
