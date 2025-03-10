using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_ScoreManager : MonoBehaviour
{

    #region Variables
    [SerializeField, Tooltip("A List of the resources and the assosiated values")] private S_Resource[] resource = new S_Resource[System.Enum.GetValues(typeof(S_Resource.Supplies)).Length];
    private static int resourceLenght = System.Enum.GetValues(typeof(S_Resource.Supplies)).Length;
    public S_Resource[] Resource { get => resource;}

    private S_StatDisplayManager statDisplayManager;
    [SerializeField] private S_Item[] items = new S_Item[System.Enum.GetValues(typeof(S_Item.Items)).Length];
    public S_Item[] Items { get => items; }

    [Header("Debug")]
    [SerializeField] private bool resetResources = false;
    #endregion

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //SceneManager.activeSceneChanged += ChangedActiveScene;
        ResetResources();
    }

    private void Update()
    {
        if (resetResources)
        {
            resetResources = false;
            ResetResources();
        }
    }

    public void ChangeScore(S_Resource.Supplies supplies, int changeAmmount, S_Item.Items item)
    {
        Resource[((int)supplies)].ammount += changeAmmount;
        Items[((int)item)].ammount += changeAmmount;
        Debug.Log("Changed Resources by:" + changeAmmount);
    }

    public void ResetResources()
    {
        for (int i = 0; i < resourceLenght; i++)
        {
            Resource[i].type = (S_Resource.Supplies)i;
            Resource[i].ammount = 0;
        }
        for (int i = 0; i < System.Enum.GetValues(typeof(S_Item.Items)).Length; i++)
        {
            Items[i].itemType = (S_Item.Items)i;
        }
    }
}
