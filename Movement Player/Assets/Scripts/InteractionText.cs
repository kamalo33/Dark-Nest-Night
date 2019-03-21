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

    private bool seeText = false;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
    }
    private void Update()
    {
        if (gameController.getInteraction() && Input.GetKeyDown(KeyCode.E) && !gameController.gethideText() && seeText)
        {
            print("gola");
            //set visible square text
            squareText.SetActive(true);
            gameController.sethideText(true);
          
            StartCoroutine(hideTextControll());



        }
        else if (gameController.gethideText() && Input.GetKeyDown(KeyCode.E) && !seeText)
        {
            //set invisible squaretext
            print("afio");
            squareText.SetActive(false);
            gameController.sethideText(false);
            seeText = true; 
         

        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {  
            //SET BUTTON ANIMATION HERE
            Instantiate(instantiateButton, new Vector3(0, 0, 0), Quaternion.identity);
            gameController.setInteraction(true);
            seeText = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy button
        Destroy(GameObject.FindGameObjectWithTag("button"));
        gameController.setInteraction(false);
        seeText = false;
     
       
   
    }
    IEnumerator hideTextControll()
    {
        yield return new WaitForSeconds(0.5f);
        gameController.sethideText(true);
        seeText = false;
    }
    
}
