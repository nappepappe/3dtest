using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class SpectatorCamera : MonoBehaviour
{
    [Range(0.01f, 100f)]
    public float Sensitivity;


    [Range(0.1f, 50f)]
    public float moveSpeed = 8f;

    private Camera cam;

    [Range(5f,60)]
    public float ZoomedInFov = 25F;
    private float defaultFov;
	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
        defaultFov = cam.fieldOfView;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = ZoomedInFov;
        }
        if(Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = defaultFov;
            
        }

        transform.position += 
        transform.up * moveSpeed *
        Time.deltaTime * 
        Input.GetAxis("Lift");

        transform.position +=
        transform.forward * moveSpeed *
        Time.deltaTime *
        Input.GetAxis("Vertical");

        transform.position +=
        transform.right * moveSpeed *
        Time.deltaTime * Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * Sensitivity *
        Input.GetAxis("Mouse X"), Space.World);

        transform.Rotate(Vector3.right * Sensitivity *
        -Input.GetAxis("Mouse Y"),Space.Self);
	}
}
