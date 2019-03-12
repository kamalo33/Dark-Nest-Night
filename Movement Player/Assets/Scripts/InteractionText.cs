using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//APPEARS TEXT AND BUTTON OVER PLAYER AND GETS PLAYER INPUT E
public class InteractionText : MonoBehaviour {

    //private bool interaction;
    private GameControllerSC gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
    }
    private void Update()
    {
        if (gameController.getInteraction() && Input.GetKeyDown(KeyCode.E))
        {
            //TEXT            
            print("buenas");

        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gameController.setInteraction(true);
            //SET BUTTON ANIMATION HERE
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameController.setInteraction(false);
        //Destroy button
    }
}
