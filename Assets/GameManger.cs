using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public Ball ball;
    public Paddel paddel;
    public static Vector2 bottomleft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {

        //coverts screen pixels coordinats into game's coordinates ( in this case (0,0)
        bottomleft = Camera.main.ScreenToWorldPoint (new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //create a ball
        Instantiate(ball);

        //create 2 paddles
        Paddel paddel1 = Instantiate(paddel) as Paddel;
        Paddel paddel2 = Instantiate(paddel) as Paddel;

        paddel1.Init(true);//right paddle
        paddel2.Init(false);//left paddle
    }

    // Update is called once per frame
    
}
