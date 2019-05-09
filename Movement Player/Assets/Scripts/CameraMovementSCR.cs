using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementSCR : MonoBehaviour
{
    public Transform cam_transform;//Put here camera by dragging it
    private GameControllerSC gameController;
    [Range(-0.5f, 0.5f)]public float distanceX_CamToPlayer = 0, distanceY_CamToPlayer = 0;
    [Range(0, 0.5f)] public float camSpeed;
    [HideInInspector] public Camera cam_Camera;
    private float camHeight, camWidth, dir;//altura, anchura and direction (-1,0,1) in that order
    
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
        cam_Camera = Camera.main;
        //Gets camera dimensions
        camHeight = 2f * cam_Camera.orthographicSize;
        camWidth = camHeight * cam_Camera.aspect;
       
    }

    void Update()
    {
        
        float x = Input.GetAxis("Horizontal"); //Input movement
        if (x > 0)
        {
             dir = 0.1F;
         
        }
        if(x < 0)
        {
            dir = -0.1F;
                  
        }
        if (gameController.getfreezCam())
        {
            dir = 0;
        }
        if (cam_transform.position.x > transform.position.x - (camWidth * distanceX_CamToPlayer) && dir < 0) //Right
        {
            cam_transform.position += new Vector3(camSpeed * dir, 0, 0);
        }
        if (cam_transform.position.x < transform.position.x + (camWidth * distanceX_CamToPlayer) && dir > 0) //Left
        {
            cam_transform.position += new Vector3(camSpeed * dir, 0, 0);
        }
    }
}
