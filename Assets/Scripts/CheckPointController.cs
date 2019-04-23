using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SAVE POSITION WHEN PRESS E. WHEN DIE, RESPAWN.
public class CheckPointController : MonoBehaviour {

    private GameControllerSC gameController;
    public GameObject instantiateButton; 
    public GameObject squareText; //Text panel
    public Animator animator;

    private bool checkPoint = false;

    void Start () {

        //get components
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();

    }

    private void Update()
    {
        //if inside of trigger
        if (gameController.getInteraction() && Input.GetKeyDown(KeyCode.E))
        {
            //set visible square text and interaction with element is true
            squareText.SetActive(true);

            //only enter one time per checkpoint
            if (!checkPoint)
            {
                //save position
                gameController.setcheckPoint(new Vector3(transform.position.x, transform.position.y, -10));
                //only one checkpoint
                gameController.setcheckPointController(true);
                checkPoint = true;
                print("solo una vez");
                print(gameController.getcheckPoint());

            }

            gameController.setInteraction(false);

        }
        //interaction is false
        else if (!gameController.getInteraction() && Input.GetKeyDown(KeyCode.E))
        {
            //set visible square text and finish of interaction
            squareText.SetActive(false);
            gameController.setInteraction(true);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //Button appears and detected that player is on checkpoint area
            Instantiate(instantiateButton, new Vector3(0, 0, 0), Quaternion.identity);
            gameController.setInteraction(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy button and out of interaction
        Destroy(GameObject.FindGameObjectWithTag("button"));
        gameController.setInteraction(false);

    }
}
