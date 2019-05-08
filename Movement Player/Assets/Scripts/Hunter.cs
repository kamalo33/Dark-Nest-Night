using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

    bool ifTocado;
    public int minRangeMov, maxRangeMov;
    public float speed = 2;
    public GameObject objetoQueSuelta;



    


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (ifTocado == true)
        {
            int number = Random.Range(minRangeMov, maxRangeMov);
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            Invoke("Stop",number);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {           
            ifTocado = true;
        }
    }

    private void Stop()
    {
        
        speed = 0;
        objetoQueSuelta.SetActive(true);

    }
}
