using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{

    [Tooltip("Speed multiplier for horizontal & vertical rotation.")]
    public Vector2 turnSpeed = new Vector2(1, 1);

    [Tooltip("Maximum rotation from the initial orientation.")]
    public Vector2 degreeClamp = new Vector2(90, 80);

    [Tooltip("Check this box if you want forward input to look downward.")]
    public bool invertY;

    // Orientation state.
    Quaternion _initialOrientation;
    Vector2 _currentAngles;

    // Cached cursor state.
    CursorLockMode _previousLockState;
    bool _wasCursorVisible;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float stepRate = 0.4f;
    public float stepCoolDown;


    void OnEnable()
    {
        // Cache our starting orientation as our center point.
        _initialOrientation = transform.localRotation;

        // Cache the previous cursor state so we can restore it later.
        _previousLockState = Cursor.lockState;
        _wasCursorVisible = Cursor.visible;

        // Hide & lock the cursor for that FPS experience
        // and to avoid distractions / accidental clicks
        // from the mouse cursor moving around.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        // Collect relative motion of mouse since last frame.
        Vector2 motion = new Vector2(
                            Input.GetAxis("Mouse X"),
                            Input.GetAxis("Mouse Y"));

        // Scale it by the turn speed, add it to our current angle, and clamp.
        motion = Vector2.Scale(motion, turnSpeed);
        _currentAngles += motion;
        _currentAngles = Vector2.Min(_currentAngles, degreeClamp);
        _currentAngles = Vector2.Max(_currentAngles, -degreeClamp);

        // Rotate to look in this direction, relative to our initial orientation.
        Quaternion look = Quaternion.Euler(
                            -_currentAngles.y,                       // Yaw
                            (invertY ? -1f : 1f) * _currentAngles.x, // Pitch
                            0);                                      // Roll

        transform.localRotation = _initialOrientation * look;

        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

        //Footstep SFX
        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f && controller.isGrounded)
        {
            AkSoundEngine.PostEvent("PlayerFootsteps", gameObject);
            stepCoolDown = stepRate;
        }

    }

    void OnDisable()
    {
        // When switched off, put everything back the way we found it.
        Cursor.visible = _wasCursorVisible;
        Cursor.lockState = _previousLockState;
        transform.localRotation = _initialOrientation;
    }
}