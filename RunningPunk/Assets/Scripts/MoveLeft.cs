using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _bounds = -15;
    private PlayerController _playerController;
    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!_playerController.GetIsGameOver())
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        if (gameObject.transform.position.x < _bounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
