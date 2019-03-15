using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    public float moveSpeed;
    private Rigidbody playerRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

    public Shooting primary;
    public Shooting secondary;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 Look = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, Look, Color.blue);

            transform.LookAt(new Vector3(Look.x,transform.position.y, Look.z));
        }

        if(Input.GetMouseButton(0))
        {
            primary.isFiring = true;
            secondary.isFiring = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            primary.isFiring = false;
            secondary.isFiring = false;
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = moveVelocity;
    }

}
