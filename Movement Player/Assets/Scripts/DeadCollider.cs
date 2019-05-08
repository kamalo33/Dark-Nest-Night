using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCollider : MonoBehaviour {

    public GameObject instantiateButton;

    private GameControllerSC gameController;


    private bool objetoMueres = false;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
    }

    void Update () {

        //If E is pressed, see daily, 
        if (Input.GetKeyDown(KeyCode.E) & objetoMueres == true)
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
            objetoMueres = true;
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy button and out of interaction
        Destroy(GameObject.FindGameObjectWithTag("button"));
        objetoMueres = false;
        
    }
}
