using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class TimeLineDirector : MonoBehaviour
{
    [SerializeField] private PlayableDirector _timelineDirector;
    public InputActionAsset _playerInputs;
    [SerializeField] private PlayableAsset timeline;
    [SerializeField] private PlayableAsset timeline1;
    public bool _TimelineCompleted = true;
    public bool _jengaPlayed = false;

    void Start()
    {
        _jengaPlayed = false;
    }

    public void PlayTimeline()
    {
        _timelineDirector.Play(timeline);
    }

    public void PlayTimeline1()
    {
        _timelineDirector.Play(timeline1);
    }

    public void CinematicFinished(bool state)
    {
        _TimelineCompleted = state;
    }

    public void JengaPlayed()
    {
        _jengaPlayed = true;
    }

    public void ChangeScene(string room)
    {
        GameManager.Instance.ChangeScene(room);
    }

    public void ECircle()
    {
        UIManager.Instance.Hide();
    }
}
