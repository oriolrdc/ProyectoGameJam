using UnityEngine;
using UnityEngine.Playables;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider _trigger;
    [SerializeField] private string _scene;
    [SerializeField] private TimeLineDirector _timelineDirector;

    public void Interact()
    {
        GameManager.Instance.ChangeScene(_scene);
    }

    public void InteractCinematic()
    {
        _timelineDirector.PlayTimeline();
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
