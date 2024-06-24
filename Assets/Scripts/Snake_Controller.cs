using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Snake_Controller : MonoBehaviour
{
    private Vector2 _direction;
    void Start()
    {
        Reset();
    }

    void Update()
    {
        GetUserInput();
    }

    private void FixedUpdate()
    {
        SnakeMover();
    }

    private void Reset()
    {
        _direction = Vector2.right;
        Time.timeScale = 0.1f;
    }

    private void SnakeMover()
    {
        float x, y;
        x = transform.position.x + _direction.x;
        y = transform.position.y + _direction.y;

        transform.position = new Vector2(x, y);
    }

    private void GetUserInput(){
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;

        }
    }
}
