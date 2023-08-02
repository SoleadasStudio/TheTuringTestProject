using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Movement
    public float horizontal { get; private set; }

    public float vertical { get; private set; }

    public float mouseX { get; private set; }

    public float mouseY { get; private set; }

    public bool jumpActivated { get; private set; }


    //Interact
    public bool activatedPress { get; private set; }

    public bool mousePress { get; private set; }

    public bool launcher1Pressed { get; private set; }

    public bool launcher2Pressed { get; private set; }

    public bool commandPressed { get; private set; }

    public bool undoPressed { get; private set; }


    /// Singleton Pattern
    private static PlayerInput instance;


    /// Insures there is only one Instance of PlayerInput
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }

    ///Giving other classes access to this instance
    public static PlayerInput GetInstance()
    {
        return instance;
    }

    ///End Singleton

    private void Start()
    {
        //Hide Mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        ProccessInputs();
    }

    void ProccessInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        jumpActivated = Input.GetButtonDown("Jump");
        activatedPress = Input.GetKeyDown(KeyCode.E);

        mousePress = Input.GetButtonDown("Fire1");

        //Assign launcher based on number key pressed
        launcher1Pressed = Input.GetKeyDown(KeyCode.Alpha1);
        launcher2Pressed = Input.GetKeyDown(KeyCode.Alpha2);

        commandPressed = Input.GetKeyDown(KeyCode.C);
        undoPressed = Input.GetKeyDown(KeyCode.Z);
    }
}
