using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBlock : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;

    //public List<GameObject> PlayerPieces = new List<GameObject>();
    //void UpdatePlayerPieces()
    //{
    //    foreach (GameObject piece in PlayerPieces)
    //    {
    //        Vector3 offset = (this.transform.position - piece.transform.position);
    //        piece.transform.position = piece.transform.position + offset;
    //    }
    //}


    void Start()
    {
        offset = target.transform.position - this.transform.position;
    }
    void Update()
    {
        //this.transform.position = target.transform.position + offset;
        transform.localPosition = new Vector3(0, -1, 0) + offset;
    }
}
