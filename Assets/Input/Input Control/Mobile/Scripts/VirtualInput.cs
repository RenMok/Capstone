using PlayerControls;
using UnityEngine;

public class VirtualInput : MonoBehaviour
{
    [Header("Output")]
    public PlayerInputs Inputs;

    public void VirtualMoveInput(Vector2 virtualMoveDirection)
    {
        Inputs.MoveInput(virtualMoveDirection);
    }

    public void VirtualLookInput(Vector2 virtualLookDirection)
    {
        Inputs.LookInput(virtualLookDirection);
    }

    public void VirtualJumpInput(bool virtualJumpState)
    {
        Inputs.JumpInput(virtualJumpState);
    }

    public void VirtualSprintInput(bool virtualSprintState)
    {
        Inputs.SprintInput(virtualSprintState);
    }
}
