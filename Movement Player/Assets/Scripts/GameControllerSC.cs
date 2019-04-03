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
    private bool hideText = false;

    //Freeze camera
    private bool freezCam = false;

    //CheckPoint position and controller
    private Vector3 checkPoint;
    private bool checkPointController = false;

    //State abilities
    private bool hideState = false;
    private bool rockState = false;

    //Daily save
    private int [] daily;
    


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

   
    //Freeze camera
    public void setfreezeCamera (bool freezCamIs)
    {
        freezCam = freezCamIs;

    }
    public bool getfreezCam()
    {
        return freezCam;
    }
    //Hide text condition
    public void sethideText(bool hideTextIs)
    {
        hideText = hideTextIs;
    }
    public bool gethideText()
    {
        return hideText;
    }

    //Checkpoint position
    public void setcheckPoint(Vector3 checkPointWorld)
    {
        checkPoint = checkPointWorld;
    }
    public Vector3 getcheckPoint()
    {
        return checkPoint; 
    }

    //Checkpoint controller
    public void setcheckPointController(bool checkPointActivated)
    {
        checkPointController = checkPointActivated;
    }
    public bool getcheckPointController()
    {
        return checkPointController; 
    }

    //Hide State
    public void sethideState(bool hideStateActivated)
    {
        hideState = hideStateActivated;
    }
    public bool gethideState()
    {
        return hideState;
    }

    //Rock State
    public void setrockState(bool rockStateActivated)
    {
        rockState = rockStateActivated;
    }
    public bool getrockState()
    {
        return rockState;
    }

    //Return bool if true or false and save it 
    public void setDaily(int [] dailyNumber)
    {
        daily = dailyNumber; 
    }
    public int [] getDaily()
    {
        return daily;
    }

}
