using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoisitionController : MonoBehaviour {

    private Transform player;
    private GameControllerSC gameController;

    public Animator animator;
    private bool fade = false;
    public float timeToFade = 4f;

	void Start ()
    {
        //Get components of gameobjects
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
    }
	
	

	void Update ()
    {
        //die without checkPoint
        if (gameController.getLife()<=0 && !gameController.getcheckPointController())
        {
            StartCoroutine(FadeTransition());
            
        }
        //die with checkpoints
        else if(gameController.getLife() <= 0 && gameController.getcheckPointController())
        {
            StartCoroutine(RespawnCheckPoint());
        }

        animator.SetBool("Fade", fade);
        
    }

   

    IEnumerator FadeTransition()
    {
        //reset life
        gameController.setLife(-100);
        //Stop fps
        Time.timeScale = 0;
        //Fade ON
        fade = true;
        yield return new WaitForSecondsRealtime(timeToFade);
        //new position of player and camera is the gameobject startPosition
        player.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
   
        
        //Return fps
        Time.timeScale = 1;
        //Fade OFF
        fade = false;
        
    }

    IEnumerator RespawnCheckPoint()
    {
        //reset life
        gameController.setLife(-100);
        //Stop fps
        Time.timeScale = 0;
        //Fade ON
        fade = true;
        yield return new WaitForSecondsRealtime(timeToFade);
        //new position of player and camera is the gameobject checkpoint position
        player.transform.position = new Vector3(gameController.getcheckPoint().x, gameController.getcheckPoint().y, 0);
        Camera.main.transform.position = new Vector3(gameController.getcheckPoint().x, gameController.getcheckPoint().y, -10);
        //Return fps
        Time.timeScale = 1;
        //Fade OFF
        fade = false;
        //Don't repeat checkpoint tranform position
        gameController.setcheckPointController(false);
        print("enter checkpoint condition");

    }
}
