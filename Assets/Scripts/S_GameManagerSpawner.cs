using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManagerSpawner : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("The gameManager prefab that will be spawned")]private GameObject gameManager;
    #endregion
    void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager != null)
            if (manager == null)
                Instantiate(gameManager);
    }
}
