using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    public float moveSpeed;
    private Rigidbody playerRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    new Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
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

            transform.LookAt(new Vector3(Look.x, Look.y, Look.z));
        }
    }
    private void FixedUpdate()
    {
        playerRigidbody.velocity = moveVelocity;
    }
}
