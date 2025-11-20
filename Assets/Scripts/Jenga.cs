using UnityEngine;
using System.Collections;

public class Jenga : MonoBehaviour
{
    [SerializeField] private GameObject _jenga;
    [SerializeField] private PlayerControler _playerScript;
    [SerializeField] private TimeLineDirector _timelineDirector;
    private bool _textDone = false;

    public void OnTriggerEnter(Collider collider)
    {
        if(_playerScript._talked == true && gameObject.tag == "JengaActive" && _textDone == false)
        {
            _textDone = true;
            StartCoroutine(JengaText());
        }
    }

    public void ToggleJenga(bool cosas)
    {
        _jenga.SetActive(cosas);
        if(gameObject.tag == "JengaInActive")
        {
            _timelineDirector.PlayTimeline1();
        }
    }

    IEnumerator JengaText()
    {
        UIManager.Instance.WriteText("Oye, ya que estas ahi, trae el jenga...");
        yield return new WaitForSeconds(4);
        UIManager.Instance.WriteText(" ");
    }
}
