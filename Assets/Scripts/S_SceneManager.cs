using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    #region Variables
    [Header("Scenes")]
    [SerializeField, Tooltip("The name of the starting scene")]private string startingScene;
    [SerializeField, Tooltip("The name of the main scene")]private string mainScene;
    #endregion
    
    public void EndScene()
    {
        
    }

    public void MainScene()
    {
        SceneManager.LoadScene(mainScene);
    }
}
