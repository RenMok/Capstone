using System.Collections;
using UnityEngine;

public class InElevatorTrigger : MonoBehaviour
{
    [SerializeField] private Animator elevatorAnimator;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            elevatorAnimator.SetBool("Open", true);

        }
    }
    
    private void OnTriggerExit()
    {
        StartCoroutine(DelayedClose());
    }

    private IEnumerator DelayedClose()
    {
        yield return new WaitForSeconds(6);
        elevatorAnimator.SetBool("Open", false);
    }
}
