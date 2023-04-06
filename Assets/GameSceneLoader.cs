using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneLoader : MonoBehaviour
{
    public const string FIRST_SCENE = "SampleScene";
    [SerializeField]
    private Button loadSceneButton;
    private void Start()
    {
        loadSceneButton.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(FIRST_SCENE);
    }
}
