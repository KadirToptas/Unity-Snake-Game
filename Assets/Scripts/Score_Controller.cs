using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Score_Controller : MonoBehaviour
{
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private Snake_Controller snake;
    void Start()
    {
        RandomScorePosition();
    }

    private void RandomScorePosition()
    {
        transform.position = new Vector2(
            Mathf.Round(Random.Range(minX, maxX)) + 0.5f, MathF.Round(Random.Range(minY, maxY)) + 0.5f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Snake"))
        {
            RandomScorePosition();
            snake.CreateSegment();
        }
    }
}
