using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _ECircle;
    [SerializeField] private PlayerControler _playerScript;

    void Update()
    {
        if(_playerScript.CanInteract())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Show()
    {
        _ECircle.SetActive(true);
    }

    void Hide()
    {
        _ECircle.SetActive(false);
    }
}
