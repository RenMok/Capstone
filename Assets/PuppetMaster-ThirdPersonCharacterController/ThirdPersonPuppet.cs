using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using StarterAssets;

public class ThirdPersonPuppet : MonoBehaviour
{
    public BehaviourPuppet puppet;
    public ThirdPersonController controller;

    private float moveSpeed, sprintSpeed, rotationSmoothTime;

    private void Start()
    {
        // Store controller speed values
        moveSpeed = controller.MoveSpeed;
        sprintSpeed = controller.SprintSpeed;
        rotationSmoothTime = controller.RotationSmoothTime;

        // Register to get a call from BehaviourPuppet when it loses/regains balance
        puppet.onLoseBalance.unityEvent.AddListener(OnLoseBalance);
        puppet.onRegainBalance.unityEvent.AddListener(OnRegainBalance);
    }

    void OnLoseBalance()
    {
        // Disable the controller from moving while ragdolled
        controller.MoveSpeed = 0f;
        controller.SprintSpeed = 0f;
        controller.RotationSmoothTime = Mathf.Infinity;
    }

    void OnRegainBalance()
    {
        // Reset controller params
        controller.MoveSpeed = moveSpeed;
        controller.SprintSpeed = sprintSpeed;
        controller.RotationSmoothTime = rotationSmoothTime;
    }


}
