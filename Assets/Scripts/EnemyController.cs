using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    //Needs rigidbody2d, maybe a triger for kill
    private Transform playerTransform;// a way to detect player
    private Vector3 startPosition, currentPosition;
    public bool playerDetected;
    private float dir_routine = 1;
    private GameControllerSC gameController;
  
    //Parametrizable parameters / public
    public float xRangeView, yRangeView, enemySpeed, xRangeMovement_Left, xRangeMovement_Right, maxRangeFromStart;
    public bool rockHideWorks = false, handHideWorkd = false;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPosition = this.transform.position;
    }

    void Update ()
    {
        detectplayer();
    }
    private void detectplayer_1()
    {
        if (playerTransform.position.x - this.transform.position.x <= xRangeView && playerTransform.position.y - this.transform.position.y <= yRangeView && playerTransform.position.x - this.transform.position.x >= -xRangeView && playerTransform.position.y - this.transform.position.y >= -yRangeView)//Detects in inside imaginary box
        {
            float distance = playerTransform.position.x - this.transform.position.x;//sees the player distance
            float dir = 0;//for the direction of the enemy
            if (distance > 0)
            {
                dir = 1;
               
                

            }
            if (distance < 0)
            {
                dir = -1;
                
              
            }
            transform.position = new Vector3(transform.position.x + enemySpeed*dir,transform.position.y,0);//moves in the direction in speed parameter
        }
    }
    private void detectplayer()
    {
        if (playerDetected == false)
        {
            currentPosition = this.transform.position;
        }
        //---------------------------------------------------
        if ((playerTransform.position.x - this.transform.position.x <= xRangeView && playerTransform.position.y - this.transform.position.y <= yRangeView && playerTransform.position.x - this.transform.position.x >= -xRangeView && playerTransform.position.y - this.transform.position.y >= -yRangeView) && (!gameController.getrockState() && rockHideWorks == true || !gameController.gethideState() && handHideWorkd == true || playerDetected == true))//Detects in inside imaginary box
        {
            float distance = playerTransform.position.x - this.transform.position.x;//sees the player distance
            float dir = 0;//for the direction of the enemy
            if (distance > 0)
            {
                dir = 1;
                print("derecha");
                //transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (distance < 0)
            {
                dir = -1;
                print("izquerda");
                //transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            transform.position = new Vector3(transform.position.x + enemySpeed * dir, transform.position.y, 0);//moves in the direction in speed parameter
            playerDetected = true;
        }
        else
        {
            if ((currentPosition.x != this.transform.position.x) && playerDetected)
            {
                if (playerTransform.position.x > currentPosition.x + maxRangeFromStart || playerTransform.position.x < currentPosition.x - maxRangeFromStart)
                {
                    float distance = currentPosition.x - this.transform.position.x;//sees the objective to move
                    float dir = 0;//for the direction of the enemy
                    if (distance > 0)
                    {
                        dir = 1;
                        print("1");
                    }
                    if (distance < 0)
                    {
                        dir = -1;
                        print("2");
                    }
                    transform.position = new Vector3(transform.position.x + enemySpeed * dir, transform.position.y, 0);//moves in the direction in speed parameter
                }
            }
            else
            {
                if (playerTransform.position.x < currentPosition.x + xRangeMovement_Right || playerTransform.position.x > currentPosition.x - xRangeMovement_Left)
                {

                    if (this.transform.position.x >= startPosition.x + xRangeMovement_Right)
                    {
                        dir_routine = -1;
                        transform.localScale =new Vector2 (1, transform.localScale.y);
           

                    }
                    if (this.transform.position.x <= startPosition.x - xRangeMovement_Left)
                    {
                        dir_routine = +1;
                        transform.localScale = new Vector2(-1, transform.localScale.y);

                    }
                    transform.position = new Vector3(transform.position.x + enemySpeed * dir_routine, transform.position.y, 0);//moves in the direction in speed parameter
                }
            }
            if (this.transform.position.x >= currentPosition.x - 1 || this.transform.position.x <= currentPosition.x + 1)
            {
                playerDetected = false;
            }
        }
        
    }
}
