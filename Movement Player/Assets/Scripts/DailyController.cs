using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyController : MonoBehaviour {

    public GameObject instantiateButton;
    public GameObject dailyMesh;
    
    //Conditions to see daily
    private bool dailyIsOpen = false;
    private bool interactionZone = false;

    //Edit texts
    public GameObject storyText;
    public GameObject dailyPageText;

    //Text to insert
    public string dailyPage;

    //Text array and number to call it
    private string[] texts = {"Solo se escuchan gritos... Todo está perdido... \n Hemos perdido la ciudad... Todo es culpa mia...\n Lo he arruinado todo... " , "Texto 2 aquí", "Texto 3 aquí", "Texto 4 aquí"};
    public int textNumber;

	
	void Update () {

        //If E is pressed, see daily, 
        if (Input.GetKeyDown(KeyCode.E) && interactionZone)
        {
            dailyMesh.SetActive(true);
            dailyIsOpen = true;
            interactionZone = false;
            storyText.GetComponent<Text>().text = texts[textNumber];
            dailyPageText.GetComponent<Text>().text = dailyPage;

        }
        //When press again, hide it
        else if (Input.GetKeyDown(KeyCode.E) && dailyIsOpen)
        {
            dailyMesh.SetActive(false);
            dailyIsOpen = false;
            interactionZone = true;
          
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Button appears and detected that player is on checkpoint area
            Instantiate(instantiateButton, new Vector3(0, 0, 0), Quaternion.identity);
            interactionZone = true;
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy button and out of interaction
        Destroy(GameObject.FindGameObjectWithTag("button"));
        interactionZone = false;
        dailyIsOpen = false;
        dailyMesh.SetActive(false);
        
    }
}
