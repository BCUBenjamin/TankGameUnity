using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

    // Bounding size of car
    public float BoundSize = 20.0f;


    //refrence Camera
    Camera GameCamera;

    //Player1Pos holdsinfo on current positon this moves due to key input
    Vector3 Player1Pos = new Vector3(0, 0, 0);

    public float CarHeight = 0;

    //Method for stopping car
    private void StopPlayer1() { Player1Pos = new Vector3(0, 0, 0); }

	// Use this for initialization
	void Start () {
        GameCamera = FindObjectOfType<Camera>();

	}
	
	// Update is called once per frame
	void Update () {



        // Getting Keyboard inputs
        if (Input.GetKey(KeyCode.W) /*Input.GetButton("Vertical") */ )
        {
            Player1Pos = new Vector3(0, 6) * Time.deltaTime /* Input.GetAxis("Vertical") */ ;            //delta time is time between frames
         
        }
        else if (Input.GetKey(KeyCode.S)  /*(Input.GetButton("Horizontal"))*/)
        {
            Player1Pos = new Vector3(0, 6) * Time.deltaTime /*Input.GetAxis("Vertical")* */ ;//Moving Left

        }



        else
        {
            StopPlayer1(); //Calling on stop car method 

        }

        //Detecting collision of Car, making the car not move if detected
        Vector3 NewPos = GameCamera.WorldToScreenPoint(transform.position + Player1Pos);
        if (NewPos.x + BoundSize > GameCamera.pixelWidth)
            { StopPlayer1(); }

        else if (NewPos.x - BoundSize < 0)
        { StopPlayer1(); }

        else if (NewPos.y + BoundSize > GameCamera.pixelHeight)
        { StopPlayer1(); }

        else if (NewPos.y - BoundSize < 0)
        { StopPlayer1(); }
    
        //Apply Translation to move car
        transform.Translate(Player1Pos);
    }
}
