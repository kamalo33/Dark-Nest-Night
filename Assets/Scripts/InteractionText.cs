using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//APPEARS TEXT AND BUTTON OVER PLAYER AND GETS PLAYER INPUT E
public class InteractionText : MonoBehaviour {

    //private bool interaction;
    private GameControllerSC gameController;
    public GameObject instantiateButton;
    public GameObject squareText; //Text panel

    //Conditions to see interactive text
    private bool seeText = false;
    private bool interactiveZone = false;

    //text to show and call this text
    private string[] interactiveTexts = { "Inserta aquí lo que quieras 1", "Inserta aquí lo que quieras 2", "Inserta aquí lo que quieras 3"};
    public int num;

    //Edit texts
    public GameObject interactiveText;
   

    private void Start()
    {
        //gameController call
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactiveZone)
        {
            //set visible square text
            squareText.SetActive(true);
            seeText = true;
            interactiveZone = false;
            interactiveText.GetComponent<Text>().text = interactiveTexts[num];
       
        }
        else if (Input.GetKeyDown(KeyCode.E) && seeText)
        {
            //set invisible squaretext
            squareText.SetActive(false);
            interactiveZone = true;
            seeText = false; 
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {  
            //SET BUTTON ANIMATION HERE
            Instantiate(instantiateButton, new Vector3(0, 0, 0), Quaternion.identity);
            interactiveZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy button
        Destroy(GameObject.FindGameObjectWithTag("button"));
        interactiveZone = false;
        seeText = false;
        squareText.SetActive(false);
     
       
   
    }
   
}
