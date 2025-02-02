using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_StorageManager : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("This is a refrence to the Gamemanager that will keep track of the score")] private S_ScoreManager scoreManager;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        //scoreManager.ChangeScore();
    }
    private void OnCollisionExit(Collision collision) 
    {
       //scoreManager.ChangeScore();
    }
}
