using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool gameActive = false;
    private Rigidbody sharkRigidBody;
    private float playerSpeed = 0.6f;

    //get rigid body of shark
    private void Awake()
    {
        sharkRigidBody = transform.GetComponent<Rigidbody>();
        if (sharkRigidBody == null) Debug.Log("Rigid body not found on player");
    }

    //bool controlling whether to allow shark movement
    public void allowSharkMovement(bool allow)
    {
        gameActive = allow;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive) return; //only check for shark movement is game is active
        checkMovement();
    }

    void checkMovement()
    {
        if (Input.GetKey(KeyCode.A)) //move left
        {
            Vector3 currentPosition = transform.localPosition;
            if (currentPosition.x < -290) return; //dont allow to move off screen
            transform.localPosition = new Vector3(currentPosition.x - playerSpeed, currentPosition.y, currentPosition.z);

        }
        if (Input.GetKey(KeyCode.D)) //move right
        {
            Vector3 currentPosition = transform.localPosition;
            if (currentPosition.x > 290) return; //dont allow to move off screen
            transform.localPosition = new Vector3(currentPosition.x + playerSpeed, currentPosition.y, currentPosition.z);
            
        }
    }

    void setSpeedDefault()
    {
        playerSpeed = 0.6f;
    }

    void changePlayerSpeed(float change)
    {
        playerSpeed = playerSpeed + change;
    }
}
