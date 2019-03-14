using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {


    private Transform player;//Player location
    [Range(0, 0.7f)] public float highButton;

	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	

	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + highButton, transform.position.z); ; 
	}
}
