using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*Para el jenga que lo pille y tal ahre una variable que ponga si tiene o no tiene el jenga entonces 
    pondre dos modelos y hare que mediante esta variable se active o se desactive el modelo ya en el sitio.*/
    public static GameManager Instance {get ; private set;}

    [SerializeField] private GameObject _loadingCanvas;
    public InputActionAsset _playerInputs;
    
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
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadNewScene(sceneName));
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        yield return null;

        _loadingCanvas.SetActive(true);
    
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        float fakeLoadPercentage = 0;

        while (!asyncLoad.isDone)
        {
            fakeLoadPercentage += 0.01f;
            Mathf.Clamp01(fakeLoadPercentage);

            if (asyncLoad.progress >= 0.9f && fakeLoadPercentage >= 0.99f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return new WaitForSecondsRealtime(0.008f);
        }
        _loadingCanvas.SetActive(false);
        _playerInputs.FindActionMap("Player").Enable();
    }
}
