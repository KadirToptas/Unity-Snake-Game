using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Snake_Controller : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private GameObject segmentPrefab;
    private List<GameObject> _segments = new List<GameObject>();
    void Start()
    {
        Reset();
        ResetSegment();
    }

    void Update()
    {
        GetUserInput();
    }

    private void FixedUpdate()
    {
        SnakeMover();
        MoveSegment();
    }

    public void CreateSegment()
    {
        GameObject _newSegment = Instantiate(segmentPrefab);
        _newSegment.transform.position = _segments[_segments.Count - 1].transform.position;
        _segments.Add(_newSegment);
    }

    private void ResetSegment()
    {
        for (int i=1; i<_segments.Count; i++)
        {
            Destroy(_segments[i]);
        }
        
        _segments.Clear();
        _segments.Add(gameObject);

        for (int i = 0; i < 3; i++)
        {
            CreateSegment();
        }
    }

    private void MoveSegment()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].transform.position = _segments[i - 1].transform.position;
        }
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

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            RestartGame();
        }
    }
}
