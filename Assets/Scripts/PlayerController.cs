using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Avoids ability to move diagonally
    public bool Move(Vector2 direction)
    {
        // Sets coordinates to 0
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }

        // Makes either x or y = 1
        direction.Normalize();

        if (Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Block");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                //GameObject bx = GameObject.FindGameObjectWithTag("Block");
                //if (bx && bx.Move(direction))
                //{
                //    return false;
                //}
                //else
                //{
                    return true;
                //}
            }
        }
        return false;
    }

    //Rigidbody2D body;

    //float horizontal;
    //float vertical;
    //float moveLimiter = 1f;

    //public float runSpeed = 20.0f;

    //void Start()
    //{
    //    body = GetComponent<Rigidbody2D>();
    //}

    //void Update()
    //{
    //    // Gives a value between -1 and 1
    //    horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
    //    vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    //}

    //void FixedUpdate()
    //{
    //    if (horizontal != 0 && vertical != 0) // Check for diagonal movement
    //    {
    //        // limit movement speed diagonally, so you move at 70% speed
    //        horizontal *= moveLimiter;
    //        vertical *= moveLimiter;
    //    }

    //    body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    //}

    //public float moveSpeed = 5f;

    //public Rigidbody2D rb;

    //Vector2 movement;

    //// Update is called once per frame
    //void Update()
    //{
    //    movement.x = Input.GetAxisRaw("Horizontal");
    //    movement.y = Input.GetAxisRaw("Vertical");
    //}

    //void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    //}
}
