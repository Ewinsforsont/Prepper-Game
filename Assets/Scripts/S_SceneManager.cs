using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(S_ScoreManager))]
public class S_SceneManager : MonoBehaviour
{
    #region Variables
    [Header("Scenes")]
    [SerializeField, Tooltip("The name of the starting scene")] private string startingScene;
    [SerializeField, Tooltip("The name of the main scene")] private string mainScene;
    private S_StatDisplayManager statDisplayManager;
    private S_ScoreManager scoreManager;
    #endregion
    private void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }
    public void EndScene()
    {
        SceneManager.LoadScene(startingScene);
    }

    public void MainScene()
    {
        SceneManager.LoadScene(mainScene);
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (current == null && next.name == "Starting")
        {
            statDisplayManager = FindAnyObjectByType<S_StatDisplayManager>();
            statDisplayManager.SetStatDisplay();
        }
        if (current == null && next.name == "Main")
        {
            scoreManager.ResetResources();
        }
    }
}
