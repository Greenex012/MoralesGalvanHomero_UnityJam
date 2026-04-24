using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Input inputActions;

    private float _moveX;
    public float MoveX { get => _moveX; }

    private float _moveY;
    public float MoveY { get => _moveY; }

    private bool _jump;
    public bool Jump { get => _jump; }

    private bool _grabLader;
    public bool GrabLader { get => _grabLader; }

    private bool _grabItem;
    public bool GrabItem { get => _grabItem; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputActions = new Input();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        inputActions.Player.Move.performed += StartMoveX;
        inputActions.Player.Move.canceled += EndMoveX;

        inputActions.Player.Climb.performed += StartMoveY;
        inputActions.Player.Climb.canceled += EndMoveY;

        inputActions.Player.Jump.performed += StartJump;
        inputActions.Player.Jump.canceled += EndJump;

        inputActions.Player.GrabLadder.performed += StartGrabLader;
        inputActions.Player.GrabLadder.canceled += EndGrabLader;

        inputActions.Player.GrabItem.performed += StartGrabItem;
        inputActions.Player.GrabItem.canceled += EndGrabItem;


        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= StartMoveX;
        inputActions.Player.Move.canceled -= EndMoveX;

        inputActions.Player.Climb.performed -= StartMoveY;
        inputActions.Player.Climb.canceled -= EndMoveY;

        inputActions.Player.Jump.performed -= StartJump;
        inputActions.Player.Jump.canceled -= EndJump;

        inputActions.Player.GrabLadder.performed -= StartGrabLader;
        inputActions.Player.GrabLadder.canceled -= EndGrabLader;

        inputActions.Player.GrabItem.performed -= StartGrabItem;
        inputActions.Player.GrabItem.canceled -= EndGrabItem;

        inputActions.Player.Disable();
    }

    void StartMoveX(InputAction.CallbackContext contexto)
    {

        _moveX = contexto.ReadValue<float>();

    }

    void EndMoveX(InputAction.CallbackContext contexto)
    {

        _moveX = 0f;

    }

    void StartMoveY(InputAction.CallbackContext contexto)
    {

        _moveY = contexto.ReadValue<float>();

    }

    void EndMoveY(InputAction.CallbackContext contexto)
    {

        _moveY = 0f;

    }

    void StartJump(InputAction.CallbackContext contexto)
    {

        _jump = true;

    }

    void EndJump(InputAction.CallbackContext contexto)
    {

        _jump = false;

    }

    void StartGrabLader(InputAction.CallbackContext contexto)
    {

        _grabLader = true;

    }

    void EndGrabLader(InputAction.CallbackContext contexto)
    {

        _grabLader = false;

    }

    void StartGrabItem(InputAction.CallbackContext contexto)
    {

        _grabItem = true;

    }

    void EndGrabItem(InputAction.CallbackContext contexto)
    {

        _grabItem = false;

    }
}

