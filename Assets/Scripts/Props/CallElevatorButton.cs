using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevatorButton : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator elevatorAnimator;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material materialToChange;
    public void OnFocus()
    {
        materialToChange = highlightMaterial;
    }

    public void OnInteract()
    {
        StartCoroutine(CallElevator());
    }

    public void OnLoseFocus()
    {
        materialToChange = normalMaterial;
    }

    private IEnumerator CallElevator()
    {
        yield return new WaitForSeconds(1);
        elevatorAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(5);
        elevatorAnimator.SetBool("Open", false);
    }

    void Start()
    {
        materialToChange = normalMaterial;
    }
}

