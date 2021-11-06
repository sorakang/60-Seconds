using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBlock : MonoBehaviour
{
    public GameObject firstChild;
    public GameObject secondChild;
    public GameObject thirdChild;
    public GameObject fourthChild;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if()
            firstChild.transform.position = secondChild.transform.position + new Vector3(1, 0, 0);
            secondChild.transform.position = firstChild.transform.position + new Vector3(-1, 0, 0);
        //thirdChild.transform.position = secondChild.transform.position + new Vector3(0, 0, 0);
    }
}
