using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class S_StorageManager : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("This is a refrence to the Gamemanager that will keep track of the score")] private S_ScoreManager scoreManager;
    private S_ResourceManager resourceManager;
    [SerializeField, Tooltip("If there is currently an item stored in the trigger box"), ReadOnly] private bool hasItem;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject.TryGetComponent<S_ResourceManager>(out resourceManager) && !hasItem)
        {
            hasItem = true;
            scoreManager.ChangeScore(resourceManager.resource.type, resourceManager.resource.ammount);
        }
        else
            Debug.Log("Failed to change resource");
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.TryGetComponent<S_ResourceManager>(out resourceManager) && hasItem)
        {
            scoreManager.ChangeScore(resourceManager.resource.type, resourceManager.resource.ammount * -1);
            hasItem = false;
        }
    }
}
