using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    private Vector3 _spawnPosition;
    private PlayerController _playerController;
    [SerializeField]
    private GameObject[] _obstacles;
    [SerializeField]
    private float _startTime = 3;
    [SerializeField]
    private float _intervalToSpawn = 2;
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _spawnPosition = new Vector3(25,0,0);
        InvokeRepeating("RandomSpawn", _startTime, _intervalToSpawn);
    }

    void Update()
    {
        
    }
    private void RandomSpawn()
    {
        float _randomTime = Random.Range(0f,1.2f);
        Invoke("SpawnObstacle",_randomTime);
    }
    private void SpawnObstacle()
    {
        if (!_playerController.GetIsGameOver())
        {
            int _obstacleIndex = Random.Range(0, 3);
            Instantiate(_obstacles[_obstacleIndex], _spawnPosition, _obstacles[_obstacleIndex].transform.rotation);
        }
    }
}
