using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    public GameObject squareText;
    public GameObject dailyText; 

    private void Awake()
    {
        //Initiate with text off
        squareText.SetActive(false);
        dailyText.SetActive(false);
        
    }

}
