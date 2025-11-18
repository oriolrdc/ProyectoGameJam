using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Interact()
    {
        
    }
}
