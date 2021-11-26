using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool gameActive = false;
    private Rigidbody sharkRigidBody;

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
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A is clicked");
            sharkRigidBody.AddForce(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
            sharkRigidBody.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W))
            sharkRigidBody.AddForce(Vector3.up);
        if (Input.GetKey(KeyCode.S))
            sharkRigidBody.AddForce(Vector3.down);
    }
}
