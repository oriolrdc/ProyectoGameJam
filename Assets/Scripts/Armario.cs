using UnityEngine;

public class Armario : MonoBehaviour
{
    [SerializeField] private TimeLineDirector _timelineDirector;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player" && _timelineDirector._jengaPlayed == true)
        {
            GameManager.Instance.ChangeScene("Room3");
        }
    }
}
