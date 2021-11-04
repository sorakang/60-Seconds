using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float timeToMove = 0.2f;
    private bool isMoving;
    private Vector3 origPos, targetPos;

    public float floatHeight;     // Desired floating height.
    public float liftForce;       // Force to apply when lifting the rigidbody.
    public float damping;         // Force reduction proportional to speed (reduces bouncing).

    public Rigidbody2D rb;
    public Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKey(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKey(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));
    }
    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {
            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = floatHeight - distance;

            // The force is proportional to the height error, but we remove a part of it
            // according to the object's speed.
            float force = liftForce * heightError - rb.velocity.y * damping;

            // Apply the force to the rigidbody.
            rb.AddForce(Vector3.up * force);
        }
    }
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    void OnCollisionExit2D(Collision2D colExt)
    {
        if (colExt.gameObject.tag == "Block")
            //colExt.gameObject.CompareTag("block").velocity = Vector3.zero;
            Debug.Log("Collision");
    }


    //    transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

    //    if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
    //    {
    //        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
    //        {
    //            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, stopMovement))
    //            {
    //                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
    //            }
    //        }
    //        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
    //        {
    //            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, stopMovement))
    //            {
    //                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
    //            }
    //        }
    //    }
}
