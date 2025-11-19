using UnityEngine;

public class Jenga : MonoBehaviour
{
    [SerializeField] private GameObject _jenga;
    public void ToggleJenga(bool cosas)
    {
        _jenga.SetActive(cosas);
    }
}
