using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;  // direction is (1,1) normilzed
        radius = transform.localScale.x / 2; // half the width

    }

    // Update is called once per frame
    void Update()
    {
        //move the ball
        transform.Translate(direction * speed * Time.deltaTime);

        // bounce top and bottom
        if (transform.position.y < GameManger.bottomleft.y + radius && direction.y <0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.y > GameManger.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        //game over!
        if (transform.position.x < GameManger.bottomleft.x + radius && direction.x < 0)
        {
            Debug.Log("Right player wins!!");

            //for now , just freeze the game
            Time.timeScale = 0;
            enabled = false;    //stop updating the scrpit
        }

        if (transform.position.x > GameManger.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left player wins!!");


            //for now , just freeze the game
            Time.timeScale = 0;
            enabled = false;   //stop updating the scrpit
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddel>().isRight;
            // if hitting right paddle and moving right , flip direction
            if(isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            //if hitting left paddle and moving right , flip direction
           
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}
