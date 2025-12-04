using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls controls;
    [SerializeField] private float _valueX;

    public float valueX { get => _valueX; }

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.PlayerV2.Move.performed += StartMove;
        controls.PlayerV2.Move.canceled += StopMove;
        controls.PlayerV2.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerV2.Move.performed -= StartMove;
        controls.PlayerV2.Move.canceled -= StopMove;
        controls.PlayerV2.Disable();
    }

    private void StartMove(InputAction.CallbackContext ctx)
    {
        _valueX = ctx.ReadValue<float>();
    }

    private void StopMove(InputAction.CallbackContext ctx)
    {
        _valueX = 0;
    }
}
