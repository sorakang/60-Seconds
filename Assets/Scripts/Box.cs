using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    //public bool onCrox;

    public static BoxCollider2D boxCol;

    public void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    public bool Move(Vector2 direction) {
        if (Mathf.Abs(direction.x) < 0.8)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
        if (BoxBlocked(transform.position, direction)) {
            return false;
        }
        else {
            transform.Translate(direction);
            //TransformForCrox();
            return true;
        }
    }

    //private void TransformForCrox() {
    //    GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
    //    foreach (var cross in crosses) {
    //        if (transform.position.x == cross.transform.position.x && transform.position.y == cross.transform.position.y) {
    //            GetComponent<SpriteRenderer>().color = Color.red;
    //            onCrox = true;
    //            return;
    //        }
    //    }
    //    GetComponent<SpriteRenderer>().color = Color.white;
    //    onCrox = false;
    //}

    private bool BoxBlocked(Vector3 position, Vector2 direction) {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls) {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y) {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes) {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y) {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.Move(direction)) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
        return false;
    }
}
