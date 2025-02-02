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
    [Tooltip("What gameobject is currently stored")] private int storedItem = 0;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject.TryGetComponent<S_ResourceManager>(out resourceManager) && storedItem == 0)
        {
            scoreManager.ChangeScore(resourceManager.resource.type, resourceManager.resource.ammount);
            storedItem = other.gameObject.GetInstanceID();
        }
        else
            Debug.Log("Failed to change resource");
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.TryGetComponent<S_ResourceManager>(out resourceManager) && other.gameObject.GetInstanceID() == storedItem)
        {
            scoreManager.ChangeScore(resourceManager.resource.type, resourceManager.resource.ammount * -1);
            storedItem = 0;
        }
    }
}
