using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _repeatSize;
    
    void Start()
    {
        _startPosition = transform.position;
        _repeatSize = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < _startPosition.x -_repeatSize)
        {
            transform.position = _startPosition;
        }
    }
}
