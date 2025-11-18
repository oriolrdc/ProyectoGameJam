using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            GameManager.Instance.Interact();
        }
    }
}
