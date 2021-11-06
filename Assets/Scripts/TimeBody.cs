using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;

    List<Vector2> positions;


    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("Space");
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Space))
            StopRewind();
    }

    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }
    void Record()
    {
        positions.Insert(0, transform.position);
        Debug.Log("Player is at: " + positions[0]);
    }

    void Rewind()
    {
        //if (positions.Count > 0)
            transform.position = positions[0];
            positions.RemoveAt(0);
    }


    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
