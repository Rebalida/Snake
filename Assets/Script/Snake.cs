using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 snakeDirection;

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
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + snakeDirection.x,
            Mathf.Round(this.transform.position.y) + snakeDirection.y,
            0.0f
        );
    }
}
