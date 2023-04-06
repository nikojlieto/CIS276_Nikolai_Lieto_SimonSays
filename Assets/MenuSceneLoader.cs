using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneLoader : MonoBehaviour
{
    public const string SECOND_SCENE = "MainMenu";
    [SerializeField]
    private Button loadSceneButton;
    private void Start()
    {
        loadSceneButton.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SECOND_SCENE);
    }
}
