using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [Header("Char stats")]
    public float walkSpeed = 2;
    public float runSpeed = 8;
    public float currentSpeed;
    public float gravity = -12;

    [Range(0, 1)]
    public float airControlPercent = 1;

    [Range(0, 1.0f)]
    public float turnSmoothTime = 0.2f;
    public float speedSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private float speedSmoothVelocity;
    private float velocityY;

    CharacterController charController;
    Transform cameraT;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        cameraT = Camera.main.transform; // Is this the Camera which are tagged as the main in the scene?..
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 inputDir = input.normalized; // I am not sure IF I need this.
        bool walking = Input.GetKey(KeyCode.LeftShift); // Probably player sometimes will need to walk slowly

        move(inputDir, walking);
    }

    void move(Vector2 inputDir, bool walking)
    {

        // I am not sure what next 2 lines does
        float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));

        float targetSpeed = runSpeed * inputDir.magnitude;
        if (walking) { targetSpeed = walkSpeed; }
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        if (velocityY > -5) { velocityY += Time.deltaTime * gravity; }
        currentSpeed = new Vector2(charController.velocity.x, charController.velocity.z).magnitude;
    }

    float GetModifiedSmoothTime(float time)
    {
        if (charController.isGrounded) { return time; }
        if (airControlPercent == 0) { return float.MaxValue; }
        return time / airControlPercent;
    }
}
