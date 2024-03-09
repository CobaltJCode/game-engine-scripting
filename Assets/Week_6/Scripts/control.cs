using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class control : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float HorizontalRotation = 5.0f;
    [SerializeField] float VerticalRotation = 5.0f;
    
    

    private float mouseDeltaX = 0f;
    private float mouseDeltaY = 0f;
    private float cameraRotX = 0f;
    private int rotDir = 0;

    PlayerControlMapping playerMappings;

    InputAction move;
    InputAction fire;
    InputAction jump;
    InputAction look;

    Rigidbody rb;

    private void Awake()
    {
        playerMappings = new PlayerControlMapping();
        move = playerMappings.Player.Move;

        fire = playerMappings.Player.Fire;
        fire.performed += Fire;

        jump = playerMappings.Player.Jump;
        jump.performed += Jump;

        look = playerMappings.Player.Look;
        rb = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        move.Enable();
        fire.Enable();
        jump.Enable();
        look.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        jump.Disable();
        look.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        HandleHorizontalRotation();
        HandleVerticalRotation();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        //Debug.Log(input);
        //float x = (input.x * speed * transform.right) + transform.position.x;
        //float y = transform.position.y;
        //float z = (input.y * speed * transform.forward) + transform.position.z;
        Vector3 dir = (input.x * transform.right) + (input.y * transform.forward);
        dir *= speed;
        transform.position += dir;
    }

    void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("I was fired!");
    }

    void Jump(InputAction.CallbackContext context)
    {
        //Debug.Log("I jumped");
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void HandleHorizontalRotation()
    {
        mouseDeltaX = look.ReadValue<Vector2>().x;

        if (mouseDeltaX != 0)
        {
            rotDir = mouseDeltaX > 0 ? 1 : -1;

            transform.eulerAngles += new Vector3(0, HorizontalRotation * Time.deltaTime * rotDir, 0);
        }
    }

    void HandleVerticalRotation()
    {
        mouseDeltaY = look.ReadValue<Vector2>().y;

        if (mouseDeltaY != 0)
        {
            rotDir = mouseDeltaY > 0 ? -1 : 1;

            cameraRotX += VerticalRotation * Time.deltaTime * rotDir;
            cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);

            var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);


            //Vector3 angle = new Vector3(rotation * Time.deltaTime * rotDir, 0, 0);

            Debug.Log(Camera.main.transform.localRotation.x);

            Camera.main.transform.localRotation = targetRotation;
            //Camera.main.transform.Rotate(angle, Space.Self);

        }
    }

    

}
