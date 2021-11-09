using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float _speed;
    public Rigidbody2D rb;
    public Transform boxL;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            transform.Translate(0.0f, 1.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.A))
            transform.Translate(-1.0f, 0.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.S))
            transform.Translate(0.0f, -1.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.D))
            transform.Translate(1.0f, 0.0f, 0.0f);
    }

    //public bool Move(Vector2 direction)
    //{
    //    if (Mathf.Abs(direction.x) < 0.8)
    //    {
    //        direction.x = 0;
    //    }
    //    else
    //    {
    //        direction.y = 0;
    //    }
    //    direction.Normalize();
    //    if (Blocked(transform.position, direction))
    //    {
    //        Debug.Log("Blocked");
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
    //            Debug.Log("Wall");
    //            return true;
    //        }
    //    }

    //GameObject[] boxes = GameObject.FindGameObjectsWithTag("MoveableObject");
    //foreach (var box in boxes)
    //{
    //    if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
    //    {
    //        Box bx = box.GetComponent<Box>();
    //        if (bx && bx.Move(direction))
    //        {
    //            Debug.Log("BoxTrue");
    //            return false;
    //        }
    //        else
    //        {
    //            Debug.Log("BoxFalse");
    //            return true;
    //        }
    //    }
    //}
    //    return false;
    //}

    //void Update()
    //{
    //    Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    //    input.Normalize();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("MoveableObject"))
        {
            Debug.Log("Moveable Object");

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
                collider.transform.Translate(0.0f, 1.0f, 0.0f);

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
                collider.transform.Translate(-1.0f, 0.0f, 0.0f);

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
                collider.transform.Translate(0.0f, -1.0f, 0.0f);

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
                collider.transform.Translate(1.0f, 0.0f, 0.0f);



            //float difference = transform.position - collider.transform.position;
            //collider.transform.position = Vector2(transform.position.x + difference.x, transform.position.y - difference.y);

            //if (collider.gameObject.GetComponent<Rigidbody2D>() == null) return;
            //var pushDir = new Vector3(collider.transform.position.x, collider.transform.position.y, 0);
            //collider.velocity = pushDir * _speed;
        }
    }

}





