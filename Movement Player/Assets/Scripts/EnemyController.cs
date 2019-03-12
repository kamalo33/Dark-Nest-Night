using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    //Needs rigidbody2d, maybe a triger for kill
    private Transform playerTransform;// a way to detect player
    public float xRangeView, yRangeView, enemySpeed;
    // Update is called once per frame

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update ()
    {
        detectplayer();
    }
    private void detectplayer()
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
}
