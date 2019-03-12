using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCollision : MonoBehaviour {

    private Rigidbody2D rgbd2D;
    public float mass = 1f;

    private void Start()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            rgbd2D.bodyType = RigidbodyType2D.Dynamic;
            rgbd2D.mass = mass;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rgbd2D.isKinematic = true;
        rgbd2D.velocity = Vector2.zero;
       

    }
}
