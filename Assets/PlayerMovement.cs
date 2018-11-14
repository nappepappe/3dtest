using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
   public float moveSpeed;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        controller.SimpleMove(transform.forward * moveSpeed * Input.GetAxis("Vertical"));
        controller.SimpleMove(transform.right * moveSpeed * Input.GetAxis("Horizontal"));

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"), Space.World);
    }
}
