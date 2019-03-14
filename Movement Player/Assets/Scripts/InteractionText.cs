using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//APPEARS TEXT AND BUTTON OVER PLAYER AND GETS PLAYER INPUT E
public class InteractionText : MonoBehaviour {

    //private bool interaction;
    private GameControllerSC gameController;
    public GameObject instantiateButton;
    public GameObject squareText; //Text panel
    public string historyText;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
    }
    private void Update()
    {
        if (gameController.getInteraction() && Input.GetKeyDown(KeyCode.E) && !gameController.gethideText())
        {
            //set visible square text
            squareText.SetActive(true);
            gameController.sethideText(true);
        
        
        }
        else if (gameController.gethideText() && Input.GetKeyDown(KeyCode.E))
        {
            //set invisible squaretext
            squareText.SetActive(false);
            gameController.sethideText(false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {  
            //SET BUTTON ANIMATION HERE
            Instantiate(instantiateButton, new Vector3(0, 0, 0), Quaternion.identity);
            gameController.setInteraction(true);
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision);
        Destroy(GameObject.FindGameObjectWithTag("button"));
        
        gameController.setInteraction(false);
        //Destroy button
    }
}
