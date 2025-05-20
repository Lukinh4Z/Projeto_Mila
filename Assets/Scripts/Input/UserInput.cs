using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    [HideInInspector] public PlayerControls playerControls;
    [HideInInspector] public Vector2 moveInput;
    [HideInInspector] public Vector2 aimInput;
    [HideInInspector] public bool shoot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        playerControls = new PlayerControls();

        playerControls.Controls.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerControls.Controls.Aim.performed += ctx => aimInput = ctx.ReadValue<Vector2>();

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
