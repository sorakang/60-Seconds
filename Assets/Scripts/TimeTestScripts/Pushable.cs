using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    //public float force;
    //public float pushTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionExit2D(Collision2D colExt)
    {
        if (colExt.gameObject.tag == "Box")
            Debug.Log("colExt");
            colExt.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    }

    // Update is called once per frame
    //protected void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if(coll.gameObject.CompareTag("Box"))
    //    {
    //        Rigidbody2D box = coll.GetComponent<Rigidbody2D>();
    //        if(box != null)
    //        {
    //            box.isKinematic = false;
    //            Vector2 difference = box.transform.position - transform.position;
    //            difference = difference.normalized * force;
    //            //box.AddForce(difference, ForceMode2D.Impulse);
    //            box.transform.position = new Vector2(Mathf.Round(box.position.x), Mathf.Round(box.position.y));
    //            StartCoroutine(PushCo(box));
    //        }
    //    }
    //}

    //private IEnumerator PushCo(Rigidbody2D box)
    //{
    //    if(box != null)
    //    {
    //        yield return new WaitForSeconds(pushTime);
    //        box.velocity = Vector2.zero;
    //        box.isKinematic = true;
    //    }
    //}
}
