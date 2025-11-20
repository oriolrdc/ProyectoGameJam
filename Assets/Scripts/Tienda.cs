using UnityEngine;

public class Tienda : MonoBehaviour
{
    [SerializeField] private TimeLineDirector _timelineDirector;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player" && gameObject.tag == "Tienda")
        {
            _timelineDirector.ChangeScene("Room6");
        }

        if(collider.gameObject.tag == "Player" && gameObject.tag == "Cama")
        {
            _timelineDirector.ChangeScene("Room7");
        }
    }
}
