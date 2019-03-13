using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSC : MonoBehaviour
{
    //Stats player
    private float life = 100;

    //Hunted condition
    private bool beingHunted = false;

    //Interaction button
    private bool interaction = false;

    //Hide State
    private bool hideState = false;

    //Freeze camera
    private bool freezCam = false;

    public static GameControllerSC instance = null;//Variable to save the instance

    void Awake()
    {
        //Singleton start
        if (instance == null)//Check if instance already exists
            instance = this;//if not, the instance is set to this GO
        else if (instance != this)//If instance already exists but difirent GO:
            Destroy(gameObject);//Destroys gameobject if diferent instance
        DontDestroyOnLoad(gameObject); //Sets this to not be destroyed when reloading scene
        //Singleton ends
    }
  
    public void setLife(float diferential) //Life
    {
        life -= diferential;//With a negative value life increses
        if (life < 0)
        {
            //Thing that have to take place when player dies, like return to last savefile, maybe, just ask Alejandro
        }
    }
    public float getLife() {
        return life;
    }

    //Hunted condition (+5% speed)
    public void setbeingHunted(bool state) //hunted State
    {
        beingHunted = state;
    }
    public bool getbeingHunted()
    {
        return beingHunted;
    }

    //Interaction button
    public void setInteraction(bool interactionTrue)
    {
        interaction = interactionTrue;
    }
    public bool getInteraction()
    {
        return interaction;
    }

   
    //Freeze camera and Hide State
    public void setFreezeCamera (bool freezCamIs)
    {
        freezCam = freezCamIs;

    }
    public bool getfreezCam()
    {
        return freezCam;
    }





}
