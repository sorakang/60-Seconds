using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 4f;
    public float moveSpeed = 4f;

    private Rigidbody2D rb;

    private Vector2 target;

    public LayerMask solidLayers;
    private RaycastHit2D[] solidHits = new RaycastHit2D[4];

    private Vector2[] directions = new Vector2[4]
    {
        Vector2.up, Vector2.down, Vector2.left, Vector2.right
    };

    private Directions facing = Directions.Down;

    private Coroutine moving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = moveSpeed;
        target = rb.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(2);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(3);
        }
    }

    private void FixedUpdate()
    {
        // solid
        for (int i = 0; i < 4; i++)
        {
            solidHits[i] = Physics2D.Raycast(rb.position, directions[i], 0.8f, solidLayers);
        }

        // move
        if (rb.position != target)
        {
            rb.position = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        }
    }

    public void Move(int direction)
    {
        if (moving != null)
        {
            return;
        }

        facing = (Directions)direction;

        if (solidHits[(int)facing].collider == null)
        {
            moving = StartCoroutine(Moving());
        }
    }

    private IEnumerator Moving()
    {
        while (solidHits[(int)facing].collider == null)
        {
            target += directions[(int)facing];

            yield return new WaitUntil(() => rb.position == target);
        }

        moving = null;
    }

    //// Avoids ability to move diagonally
    //public bool Move(Vector2 direction)
    //{
    //    // Sets coordinates to 0
    //    if (Mathf.Abs(direction.x) < 0.5)
    //    {
    //        direction.x = 0;
    //    }
    //    else
    //    {
    //        direction.y = 0;
    //    }

    //    // Makes either x or y = 1
    //    direction.Normalize();

    //    if (Blocked(transform.position, direction))
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        transform.Translate(direction);
    //        return true;
    //    }
    //}

    //bool Blocked(Vector3 position, Vector2 direction)
    //{
    //    Vector2 newPos = new Vector2(position.x, position.y) + direction;

    //    GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
    //    foreach (var wall in walls)
    //    {
    //        if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
    //        {
    //            return true;
    //        }
    //    }

    //    GameObject[] boxes = GameObject.FindGameObjectsWithTag("Block");
    //    foreach (var box in boxes)
    //    {
    //        if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
    //        {
    //            //GameObject bx = GameObject.FindGameObjectWithTag("Block");
    //            //if (bx && bx.Move(direction))
    //            //{
    //            //    return false;
    //            //}
    //            //else
    //            //{
    //                return true;
    //            //}
    //        }
    //    }
    //    return false;
    //}
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
