using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class TimeLineDirector : MonoBehaviour
{
    public static TimeLineDirector Instance {get ; private set;}

    private PlayableDirector _timelineDirector;
    [SerializeField] private InputActionAsset _playerInputs;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
        _timelineDirector = GetComponent<PlayableDirector>();
    }

    public void PlayTimeline()
    {
        _playerInputs.FindActionMap("Player").Disable();
        _timelineDirector.Play();
    }
}
