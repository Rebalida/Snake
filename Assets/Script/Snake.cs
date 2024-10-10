using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 snakeDirection;

    private List<Transform> segments;

    public Transform segmentPrefab;

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            snakeDirection = Vector2.up;

        }else if (Input.GetKeyDown(KeyCode.S))
        {
            snakeDirection = Vector2.down;

        }else if (Input.GetKeyDown(KeyCode.A))
        {
            snakeDirection = Vector2.left;

        }else if (Input.GetKeyDown(KeyCode.D))
        {
            snakeDirection = Vector2.right;

        }
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count -1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + snakeDirection.x,
            Mathf.Round(this.transform.position.y) + snakeDirection.y,
            0.0f
        );
 
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
    }
}
