using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    #region Variables
    [Header("Scenes")]
    [SerializeField, Tooltip("The name of the starting scene")] private string startingScene;
    [SerializeField, Tooltip("The name of the main scene")] private string mainScene;

    [Header("Debug")]
    [SerializeField] private bool loadMainScene = false;
    [SerializeField] private bool loadStartingScene = false;

    private S_ScoreManager scoreManager;
    #endregion
    private void Update()
    {
        if (loadMainScene)
        {
            loadMainScene = false;
            MainScene();
        }
        if (loadStartingScene)
        {
            loadStartingScene = false;
            StartingScene();
        }

    }
    public void StartingScene() // opens the starting scene
    {
        SceneManager.LoadScene(startingScene);
    }

    public void MainScene()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void ChangeScene(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    
}
