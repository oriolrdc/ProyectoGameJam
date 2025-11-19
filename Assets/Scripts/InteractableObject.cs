using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider _trigger;
    
    public void Interact()
    {
        TimeLineDirector.Instance.PlayTimeline();
    }

    void Start()
    {
        UIManager.Instance.Hide();
    }

    void OnTriggerEnter(Collider collider)
    {
        UIManager.Instance.Show();
    }

    void OnTriggerExit(Collider collider)
    {
        UIManager.Instance.Hide();
    }
}
