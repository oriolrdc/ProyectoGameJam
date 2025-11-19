using UnityEngine;
using UnityEngine.Playables;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider _trigger;

    public void Interact()
    {
        GameManager.Instance.ChangeScene("Scene2");
    }

    public void InteractCinematic(PlayableAsset timeline)
    {
        TimeLineDirector.Instance.PlayTimeline(timeline);
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
