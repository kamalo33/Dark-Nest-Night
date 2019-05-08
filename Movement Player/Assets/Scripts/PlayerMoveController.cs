using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    //Movement player stats
    public float maxSpeed = 4f;
    public float jumpImpulse = 5f;

    public float sprintSpeed = 0.02f;

    private bool jump = true;
    private bool jumpPressed;
    private float speed;
    private float running;
    private float moveReduction = 1f;

    //Jump controll
    private bool grounded;
    public Transform groundPosition;
    public LayerMask groundLayer;
    public float groundDetectionRadius = 0.02f;

    //Controll fields
    [Range(0, 1)] public float darkness;
    [Range(0, 1)] public float thickWeed;
    [Range(0, 1)] public float surfaceWater;
    [Range(0, 1)] public float midiumWater;
    [Range(0, 1)] public float deepWater;
    [Range(0, 1)] public float beingHuntedSpeed;

    private bool ice = false;
    private bool directionIce = false;
    private bool blockDirectionIce = false;
    public float iceForce = 3f;

    private bool huntedState = false;

    //Hide
    private bool stopped = false;

    //Damage function and controller
    public float damageTime = 2f;
    private bool invokeIsCalled = false;

    [Range(0, 100)] public float fireDamage;
    private bool insideFire = false;

    [Range(0, 100)] public float bramblesDamage;
    private bool insideBrambles = false;

    private float boneSplintersDamage = 100;

    //CloseEyes ability
    public Animator animator;
    private bool eyesClosed=false;
   

    //Start function
    private GameControllerSC gameController;
    private Vector3 position;
    private Rigidbody2D rb;
    private Animator anim;

    
    private void Start() //get components
    {


        //deathPanel = gameObject.GetComponent<Renderer>().material.color;//Color player
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        //spr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        //circle = GameObject.FindGameObjectsWithTag("box").GetComponent<Rigidbody2D>();

      
    }

    private void Update()
    {

        float x = Input.GetAxis("Horizontal"); //Input movement

        //Swap sprite and can't move when enter on ice or hide ability
        if (x > 0 && !blockDirectionIce && !gameController.getfreezCam())
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            directionIce = false;
            stopped = false;
        }
        else if (x < 0 && !blockDirectionIce && !gameController.getfreezCam())
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            directionIce = true;
            stopped = false;

        }
        //Hide condition
        else if (speed == 0)
        {
            stopped = true;

        }

        //RockForm activation
        try
        {
            if (Input.GetKey(KeyCode.Space) && stopped && !ice)
            {
                //Change state 
                gameController.setfreezeCamera(true);
                gameController.setrockState(true);
                eyesClosed = true;
            
            }
            else
            {
                gameController.setfreezeCamera(false);
                gameController.setrockState(false);
                eyesClosed = false;

            }
            
        }
        catch (Exception e)
        {

            print(e);
        }
        finally
        {

        }
      
        //Close eyes form activation
        try
        {
            if(Input.GetKey(KeyCode.Q) && stopped && !ice)
            {
                gameController.setfreezeCamera(true);
                gameController.sethideState(true);
                eyesClosed = true;

            }
            else
            {
                
                gameController.sethideState(false);
                
            }
            
        }
        catch (Exception e)
        {
            print (e);
        }
        finally
        {

        }

        //Jump activation
        jump = (Input.GetAxis("Jump") > 0); //devuelve true cuando se está saltando, sino, no se devuelve nada
        if (!jump)
        {
            jumpPressed = false;
        }

        try //Movement
        {
            if (grounded)
            {
                speed = (x * maxSpeed) * (moveReduction);
                running = (x * sprintSpeed + speed) * (moveReduction);
            }
        }
        catch (Exception e)
        {
            print("SpeedPlayer");
            print(e);
        }

        try //Try to invoke damage functions (InvokeRepeatings)
        {
            if (insideFire)
            {
                if (!invokeIsCalled)
                {
                    InvokeRepeating("fireDamageTiming", 0f, damageTime);

                }
            }
            if (insideBrambles)
            {
                if (!invokeIsCalled)
                {
                    InvokeRepeating("bramblesDamageTiming", 0f, damageTime);
                    invokeIsCalled = true;
                }
            }
        }
        catch (Exception e)
        {
            print("Damage Functions");
            print(e);
        }
        finally
        {
            if (insideFire || insideBrambles)
                invokeIsCalled = true;
        }

        try //haunted condition
        {
            if (gameController.getbeingHunted() && !huntedState)
            {
                moveReduction += beingHuntedSpeed;
                print(moveReduction);
                huntedState = true;
            }
            else if (!gameController.getbeingHunted() && huntedState)
            {
                moveReduction -= beingHuntedSpeed;
                print(moveReduction);
                huntedState = false;
            }


        }
        catch (Exception e)
        {
            print("BeingHunted");
            print(e);
        }
        finally
        {

        }

        anim.SetFloat("speed", Mathf.Abs(x)); //Run animation
        anim.SetBool("grounded", grounded); //Jump animation
        anim.SetBool("hidestate", gameController.getrockState()); //Hide animation
        animator.SetBool("eyes", eyesClosed);//Closed eyes animation
        anim.SetBool("eyestate", gameController.gethideState());
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Sprint") > 0 && !ice && grounded && !gameController.getfreezCam()) //Sprint if press button (Conditions that null sprint)
        {
            //rb.transform.Translate(new Vector3(running * Time.deltaTime, 0, 0));
            rb.velocity = new Vector3(running, rb.velocity.y, 0);
            //gameController.setbeingHunted(true); Haunted test (IN)

        }
        else if (!ice && !gameController.getfreezCam()) //Movement
        {

            //rb.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

            rb.velocity = new Vector3(speed, rb.velocity.y, 0);

        }

        grounded = Physics2D.OverlapCircle(groundPosition.position, groundDetectionRadius, groundLayer.value); //rayCast to ground

        if (jump && !jumpPressed && grounded && !stopped && !ice) //In Jump 
        {
            rb.AddForce(new Vector2(0, jumpImpulse), ForceMode2D.Impulse);
            jumpPressed = true;
            grounded = false;
            //gameController.setbeingHunted(false); Haunted test (ON) 
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) //switch for terrain effects
        {
            case "darkness":

                moveReduction = darkness;
                break;

            case "thickWeed":

                moveReduction = thickWeed;
                break;

            case "surfaceWater":

                moveReduction = surfaceWater;
                break;

            case "midiumWater":

                moveReduction = midiumWater;
                break;

            case "deepWater":

                moveReduction = deepWater;
                break;

            case "ice":
                gameController.setfreezeCamera(true);
                ice = true;
                if (!directionIce)
                {
                    rb.AddForce(new Vector2(iceForce, 0), ForceMode2D.Impulse);
                }
                else if (directionIce)
                {
                    rb.AddForce(new Vector2(-iceForce, 0), ForceMode2D.Impulse);
                }
                blockDirectionIce = true;

                break;

            case "fire":
                insideFire = true;
                break;

            case "brambles":
                insideBrambles = true;
                break;

            case "bonesplinters":
                gameController.setLife(boneSplintersDamage);
                print(gameController.getLife());
                break;

           
        }
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyController>().playerDetected == true)
        {
            print("mueres");
            gameController.setLife(100);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) //switch for ice sliding
        {
            case "ice":
                ice = false;
                if (!directionIce)
                {
                    rb.AddForce(new Vector2(-iceForce, 0), ForceMode2D.Impulse);
                }
                else if (directionIce)
                {
                    rb.AddForce(new Vector2(iceForce, 0), ForceMode2D.Impulse);
                }
                blockDirectionIce = false;
                gameController.setfreezeCamera(false);
                break;

        }


        try//Try for damage fields
        {
            insideFire = false;
            insideBrambles = false;
            invokeIsCalled = false; //Stop invoke in Update function
            CancelInvoke("fireDamageTiming"); //Cancel damage function of fire
            CancelInvoke("bramblesDamageTiming");
          

        }
        catch (Exception e) //Print error
        {
            print(e);

        }
        finally //Execute anyway
        {
            moveReduction = 1f; //Return normal speed to player
        }

    }

    private void fireDamageTiming()//Damage function for fire
    {

        gameController.setLife(fireDamage);
        print(gameController.getLife());

    }

    private void bramblesDamageTiming()//Damage function for brambles (espinas)
    {

        gameController.setLife(bramblesDamage);
        print(gameController.getLife());
    }

}


