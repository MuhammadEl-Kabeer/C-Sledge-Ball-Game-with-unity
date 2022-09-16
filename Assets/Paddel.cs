using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddel : MonoBehaviour
{
    [SerializeField]  // serilizefield help so we can edit the speed in unity
    float speed;

    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            //place paddle on thr right screen
            pos = new Vector2( GameManger.topRight.x , 0);
            pos -= Vector2.right * transform.localScale.x; //move a bit to the left

            input = "PaddleRight";
        }
        else
        {
            // place paddle on thr Left screen
            pos = new Vector2(GameManger.bottomleft.x, 0);
            pos += Vector2.right * transform.localScale.x; //move a bit to the right

            input = "PaddleLeft";
        }

        //upadte this paddle's position
        transform.position = pos;
        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        //move the paddles

        //GetAxis is a number between -1 to 1 (-1 for down, 1 for up) 
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        //restrict paddle movement
        //if paddle is too low and the player is still moving down ,stop
        if(transform.position.y< GameManger.bottomleft.y + height / 2 && move < 0)
        {
            move = 0;
        }

        //if paddle is too high and the player is still moving up ,stop
        if (transform.position.y > GameManger.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
