using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get ; private set;}
    [SerializeField] private GameObject _ECircle;
    //Subtitulos
    [SerializeField] private Text _subtitlesText;
    [SerializeField] private float _textVelocity = 0.5f;
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

    void Start()
    {
        _ECircle.SetActive(false);
    }

    public void Show()
    {
        _ECircle.SetActive(true);
    }

    public void Hide()
    {
        _ECircle.SetActive(false);
    }

    public void WriteText(string text)
    {
        StartCoroutine(TextVelocity(text));
    }

    IEnumerator TextVelocity(string text)
    {
        string texto = text;
        char[] letras = texto.ToCharArray();
        foreach (char letra in letras)
        {
            _subtitlesText.text += letra;
            yield return new WaitForSeconds(_textVelocity);
        }
        
    }
}
