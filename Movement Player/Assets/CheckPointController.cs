using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SAVE POSITION WHEN PRESS E. WHEN DIE, RESPAWN.
public class CheckPointController : MonoBehaviour {

    private GameControllerSC gameController;
    public GameObject instantiateButton; 
    public GameObject squareText; //Text panel
    public string historyText; //Text inside square
    private Transform player;

    private bool inCheckPointArea=false;

    void Start () {

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
        player = gameObject.GetComponent<Transform>(); 
    }

    private void Update()
    {
        if (gameController.getInteraction() && !gameController.gethideText() && Input.GetKeyDown(KeyCode.E) && inCheckPointArea)
        {
            //set visible square text
            squareText.SetActive(true);
            gameController.sethideText(true);
            //Save transform position of player
            gameController.setcheckPoint(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
            inCheckPointArea = false;
            gameController.setcheckPointController(true);
            print(gameController.getcheckPoint());

        }
        else if (gameController.gethideText() && Input.GetKeyDown(KeyCode.E) && !inCheckPointArea)
        {
            //set invisible squaretext
            squareText.SetActive(false);
            gameController.sethideText(false);
            inCheckPointArea = true;

            print("gola holita");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //SET BUTTON ANIMATION HERE
            Instantiate(instantiateButton, new Vector3(0, 0, 0), Quaternion.identity);
            gameController.setInteraction(true);
            inCheckPointArea=true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision);
        Destroy(GameObject.FindGameObjectWithTag("button"));
        inCheckPointArea = false;
        gameController.setInteraction(false);
        inCheckPointArea = false;
        //Destroy button
    }
}
