using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("open");
        }
    }
}
