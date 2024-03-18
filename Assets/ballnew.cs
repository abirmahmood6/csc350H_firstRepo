// Abir Mahmood
// CSC 350H
// Dr. Hao Tang
// 03/12/2024

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject prefabBall;

    static int nunCollisions = 0;
    const float MinimpulseForce = 3.06f;
    const float MaxInpulseForce = 5.0f;

    float screenLeft, serenRight, screenTop, screenBotton;
    float colLiderHaLfWidth, colLiderHalfHeight;
    void Start()
    {
        //float angle = Random. Range(0, 2* Mathf.PI);
        //Vector2 direction = new Vector2(Nathf.Cos(angle), Mathf.Sin(angle));
        //float magnitude = Random.Range(NinImpulseForce, MaxInpulseForce);
        //GetComponent<Rigidbody2D>). AddForce(nagnitude * direction, ForceMode2D. Impulse);
        float screen = -Camera.main.transform.position.z;
        Debug.Log(UnityEngine.Screen.width + " " + UnityEngine.Screen.height);
        Vector3 LowerLeftCornerScreen = new Vector3(0, 0, screen);
        Vector3 LowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(LowerLeftCornerScreen);
        Vector3 topRightCornerScreen = new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height, screen);
        Vector3 topRightCornerWorld = Camera.main.ScreenToWorldPoint(topRightCornerScreen);

        float screenLeft = LowerLeftCornerWorld.x;
        float screenRight = topRightCornerWorld.x;
        screenTop = topRightCornerWorld.y;
        float screenBottom = LowerLeftCornerWorld.y;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector3 boxColliderDim = collider.bounds.max - collider.bounds.min;
        colLiderHaLfWidth = boxColliderDim.x / 2;
        colLiderHalfHeight = boxColliderDim.y / 2;
        Debug.Log(screenLeft + " " + UnityEngine.Screen.height);

        initialize();   //calling the initialize function

    }

    // Update is called once per frame
    void Update()
    {
        float movingSpeedPerSecond = 5.0f;  // movement speed of ball

        float horizontalInput = Input.GetAxis("Horizontal"); //-1,0,1
        transform.position += new Vector3(horizontalInput, 0, 0) * movingSpeedPerSecond * Time.deltaTime; //horizontal

        float verticalInput = Input.GetAxis("Vertical"); //-1,0,1
        transform.position += new Vector3(0, verticalInput, 0) * movingSpeedPerSecond * Time.deltaTime; //vertical


        KeepInScreen(); 

    }

    void KeepInScreen()
    {
        Vector3 position = transform.position;

        // Clamp the x position to keep the ball within the screen horizontally
        position.x = Mathf.Clamp(position.x, screenLeft + colLiderHalfWidth, serenRight - colLiderHalfWidth);

        // Clamp the y position to keep the ball within the screen vertically
        position.y = Mathf.Clamp(position.y, screenBotton + colLiderHalfHeight, screenTop - colLiderHalfHeight);

        // Update the ball's position
        transform.position = position;
    }



    
}




