using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCollider : MonoBehaviour {

    public GameObject instantiateButton;

    private GameControllerSC gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
    }

    void Update () {

        //If E is pressed, see daily, 
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameController.setLife(100f);
        }
       


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Button appears and detected that player is on checkpoint area
            Instantiate(instantiateButton, new Vector3(0, 0, 0), Quaternion.identity);
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy button and out of interaction
        Destroy(GameObject.FindGameObjectWithTag("button"));
        
    }
}
