using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool invert;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        transform.Rotate(Vector3.right, invert?
        Input.GetAxis("Mouse Y") :
        -Input.GetAxis("Mouse Y"), Space.Self);
	}
}
