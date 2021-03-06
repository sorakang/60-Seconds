using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static bool isMoved = false;

    public bool Move(Vector2 direction) {
        Debug.Log("Player is moving");
        if (Mathf.Abs(direction.x) < 0.8) {
            direction.x = 0;
        }
        else {
            direction.y = 0;
        }
        direction.Normalize();
        if (Blocked(transform.position, direction)) {
            Debug.Log("Blocked");
            return false;
        }
        else {
            transform.Translate(direction);
            return true;
        }
    }

    bool Blocked(Vector3 position, Vector2 direction) {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls) {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y) {
                Debug.Log("Wall");
                return true;
            }
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes) {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y) {
                Box bx = box.GetComponent<Box>();
                if(bx && bx.Move(direction)) {
                    Debug.Log("BoxTrue");
                    isMoved = true;
                    return false;
                }
                else {
                    Debug.Log("BoxFalse");
                    isMoved = true;
                    return true;
                }
            }
        }
        isMoved = false;
        return false;
    }
}
