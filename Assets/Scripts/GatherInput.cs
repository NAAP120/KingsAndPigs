using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls controls;

    [field: SerializeField]
    public float valueX { get; private set; }
    [SerializeField] private bool _IsJumping;
    public bool IsJumping { get => _IsJumping; set => _IsJumping = value;}
    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.PlayerV2.Move.performed += StartMove;
        controls.PlayerV2.Move.canceled += StopMove;
        controls.PlayerV2.Jump.performed += StartJump;
        controls.PlayerV2.Jump.canceled += StopJump;
        controls.PlayerV2.Enable();
    }

   

    private void StartMove(InputAction.CallbackContext ctx)
    {
        valueX = ctx.ReadValue<float>();
    }

    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }

      private void StartJump(InputAction.CallbackContext ctx)
    {
        valueX = ctx.ReadValue<float>();
    }

    private void StopJump(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }
     private void OnDisable()
    {
        controls.PlayerV2.Move.performed -= StartMove;
        controls.PlayerV2.Move.canceled -= StopMove;
        controls.PlayerV2.Jump.performed += StartJump;
        controls.PlayerV2.Jump.canceled += StopJump;
        controls.PlayerV2.Disable();
    }
}
