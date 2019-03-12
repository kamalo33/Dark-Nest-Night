using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementSCR : MonoBehaviour
{
    public Transform cam_transform;//Put here camera by dragging it
    public float smoothCam = 0.1f;
    private GameControllerSC gameController;
    [Range(-0.5f, 0.5f)]public float distanceX_CamToPlayer = 0, distanceY_CamToPlayer = 0;
    [HideInInspector] public Camera cam_Camera;
    private float camHeight, camWidth;//altura, anchura, in that order
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerSC>();
        cam_Camera = Camera.main;
        //Gets camera dimensions
        camHeight = 2f * cam_Camera.orthographicSize;
        camWidth = camHeight * cam_Camera.aspect;
        print(camHeight);
        print(camWidth);
    }

    void Update()
    {
        
        float x = Input.GetAxis("Horizontal"); //Input movement
        if (x > 0 && !gameController.getfreezCam())
        {
            cam_transform.position = new Vector3(this.transform.position.x + (camWidth * distanceX_CamToPlayer), this.transform.position.y + (camHeight * distanceY_CamToPlayer), -10);
            //Vector3 newPosition = cam_transform.position;
            //cam_transform.position = Vector3.Lerp(cam_transform_now, cam_transform_end, smoothCam);
        }
        else if(x < 0 && !gameController.getfreezCam())
        {
            cam_transform.position = new Vector3(this.transform.position.x - (camWidth * distanceX_CamToPlayer), this.transform.position.y + (camHeight * distanceY_CamToPlayer), -10);
            
            //transform.position = Vector3.Lerp(cam_transform_now, cam_transform_end, 2f);
        }
       
    }
}
