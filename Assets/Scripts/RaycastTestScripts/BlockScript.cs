using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public bool firstPressed;
    public bool reset;

    public float doubleTapTime = 0.5f;
    private float lastKeyPressed;

    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MoveableObject"))
        {
            Debug.Log("Collision");
            if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.Space))
            {
                collision.transform.Translate(0.0f, 0.1f, 0.0f);
            }
        }
    }
}
