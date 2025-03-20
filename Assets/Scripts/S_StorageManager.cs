using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class S_StorageManager : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("This is a refrence to the Gamemanager that will keep track of the score")] private S_ScoreManager scoreManager;
    private S_ResourceManager resourceManager; // the resource manager
    [Tooltip("What gameobject is currently stored")] private int storedItem = 0;
    #endregion


    private void Start()
    {
        if (scoreManager == null)
        {
            if (!FindGameManager(out scoreManager))
                Debug.LogError("No GameManager Was found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject.TryGetComponent<S_ResourceManager>(out resourceManager) && storedItem == 0)
        {
            scoreManager.ChangeScore(resourceManager.resource.type, resourceManager.resource.ammount, resourceManager.item);
            storedItem = other.gameObject.GetInstanceID();
        }
        else
            Debug.Log("Failed to change resource");
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.TryGetComponent<S_ResourceManager>(out resourceManager) && other.gameObject.GetInstanceID() == storedItem)
        {
            scoreManager.ChangeScore(resourceManager.resource.type, resourceManager.resource.ammount * -1, resourceManager.item);
            storedItem = 0;
        }
    }

    private bool FindGameManager(out S_ScoreManager ScoreManager)
    {
        GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
        if (manager == null)
        {
            ScoreManager = null;
            return false;
        }
        else
        {
            ScoreManager = manager.GetComponent<S_ScoreManager>();
            return true;
        }

    }
}
