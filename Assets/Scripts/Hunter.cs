using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

    bool ifTocado;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

        if (ifTocado == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime * 2);
            Invoke("Stop", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ifTocado = true;
        }
        
    }

    private void Stop()
    {
        Destroy(this.gameObject);
    }

 
}
