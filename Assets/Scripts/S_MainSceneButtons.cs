using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MainSceneButtons : MonoBehaviour
{
    #region Variables
    private S_SceneManager sceneManager;
    #endregion
    void Start()
    {
        sceneManager = FindAnyObjectByType<S_SceneManager>();
    }
    
    public void ChangeScene()
    {

    }
}
