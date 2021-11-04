using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    // Avoids ability to move diagonally
    public bool Move(Vector2 direction)
    {
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            // Box is not blocked, therefore moveable
            transform.Translate(direction);
            return true;
        }
    }

    // Boxes blocked by other boxes and walls
    bool BoxBlocked(Vector3 position, Vector2 direction)
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
                return true;
            }
        }
    }

    //public Rigidbody2D rb;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //void OnCollisionEnter(Collision c)
    //{
    //    // force is how forcefully we will push the player away from the enemy.
    //    float force = 30;

    //    // If the object we hit is the enemy
    //    if (c.gameObject.tag == "Player")
    //    {
    //        // Calculate Angle Between the collision point and the player
    //        Vector3 dir = c.contacts[0].point - transform.position;
    //        // We then get the opposite (-Vector3) and normalize it
    //        dir = -dir.normalized;
    //        // And finally we add force in the direction of dir and multiply it by force. 
    //        // This will push back the player
    //        GetComponent<Rigidbody>().AddForce(dir * force);
    //    }
    //}
}
