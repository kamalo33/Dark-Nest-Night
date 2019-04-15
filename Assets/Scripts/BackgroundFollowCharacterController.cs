using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowCharacterController : MonoBehaviour {

    private Transform player;
  
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	
	void Update () {
        //Center of background follow player in all time
        transform.position = new Vector2(player.position.x, player.position.y);
		
	}
}
