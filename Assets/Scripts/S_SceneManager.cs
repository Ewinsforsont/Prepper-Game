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

    private S_ScoreManager scoreManager;
    #endregion
    private void Start()
    {

    }
    public void StartingScene()
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
