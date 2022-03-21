using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _minSpawnTime = 1;
    [SerializeField] float _maxSpawnTime = 10;
    [SerializeField] Transform _spawnPoint;
    //int xPos;
    //int yPos;
    float time;
    private void Update()
    {

        if (time <= Time.time)
        {
            GameObject newEnemy = Instantiate(_prefab);
            newEnemy.transform.position = new Vector2(_spawnPoint.position.x, _spawnPoint.position.y);
            time = Time.time + Random.Range(_minSpawnTime, _maxSpawnTime);
        }
    }
    //IEnumerator EnemySpawn()
    //{
    //    while (time <= Time.time)
    //    {
    //        xPos = Random.Range(1, 10);
    //        yPos = Random.Range(1, 10);
    //        Instantiate(_prefab ,new Vector2 (xPos,yPos),Quaternion.identity);
    //        yield return new WaitForSeconds(0.1f);
    //        time = Time.time + Random.Range(_minSpawnTime, _maxSpawnTime);
    //    }

    //}

}
