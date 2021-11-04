using UnityEngine;
using System.Collections;

public class BoxCollisionScript : MonoBehaviour
{

    //public float movementSpeed = 1.5f;
    public Rigidbody2D rb2D;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayerHit();
    }

    //Check if the player is hitting a box, from one of its four sides. Set the box is kinematic to false, if player hits.
    void CheckForPlayerHit()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + new Vector3(0.0f, 0.7f, 0.0f), Vector2.up);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + new Vector3(0.0f, -0.7f, 0.0f), -Vector2.up);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0.0f, 0.0f), Vector2.right);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-0.7f, 0.0f, 0.0f), -Vector2.right);

        if (hitUp.collider.gameObject.tag == "Player" || hitDown.collider.gameObject.tag == "Player" ||
            hitRight.collider.gameObject.tag == "Player" || hitLeft.collider.gameObject.tag == "Player")
        {
            rb2D.isKinematic = false;
        }
        else
        {
            rb2D.isKinematic = true;
        }
    }
}