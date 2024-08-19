using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractModule : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;

    private IInteractable inFocus = null;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, 4f, interactableLayer))
        {
            if (inFocus == null)
            {
                inFocus = hit.collider.GetComponent<IInteractable>();
                inFocus.OnFocus();
            }
            else if (!inFocus.Equals(hit.collider.TryGetComponent(out IInteractable newFocus)))
            {
                inFocus.OnLoseFocus();
                inFocus = newFocus;
                inFocus.OnFocus();
            }
            else
            {
                inFocus.OnLoseFocus();
                inFocus = null;
            }
            
        }
    }

    public void Interact()
    {
        if (inFocus != null) inFocus.OnInteract();
        else return;
    }
}
