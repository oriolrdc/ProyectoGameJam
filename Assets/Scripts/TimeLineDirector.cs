using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class TimeLineDirector : MonoBehaviour
{
    [SerializeField] private PlayableDirector _timelineDirector;
    public InputActionAsset _playerInputs;
    [SerializeField] private PlayableAsset timeline;
    [SerializeField] private PlayableAsset timeline1;
    public bool _TimelineCompleted = true;
    public bool _jengaPlayed = false;
    public VideoPlayer _videoPlayer;

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

    public void Dialogo1()
    {
        UIManager.Instance.WriteText("Jose: Angel, que haces metiéndote en el cofre?!");
    }

    public void Pensamiento1()
    {
        UIManager.Instance.WriteText("Pensamiento: ¿A quién se lo está diciendo?");
    }

    public void DialogoVacio()
    {
        UIManager.Instance.WriteText(" ");
    }
    public void Dialogo2()
    {
        UIManager.Instance.WriteText("Jose: Venga Ángel te toca mover a ti!");
    }
    public void Pensamiento2()
    {
        UIManager.Instance.WriteText("Pensamiento: Jose está hablando con…alguien, pero no lo veo, que raro…");
    }
    public void Pensamiento3()
    {
        UIManager.Instance.WriteText("Tu: Jose estás bien? te he notado un poco raro.");
    }

    public void PlayVideo()
    {
        _videoPlayer.Play();
    }
}
