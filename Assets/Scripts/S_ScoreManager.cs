using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

/*[System.Serializable]
public class Resource
{
    public enum Supplies { water, food, heat, communcation, money, toilet, misc }
    public Supplies type;
    public int ammount;
}*/

public class S_ScoreManager : MonoBehaviour
{

    #region Variables
    [SerializeField, Tooltip("A List of the resources and the assosiated values")] private S_Resource[] resource = new S_Resource[System.Enum.GetValues(typeof(S_Resource.Supplies)).Length];
    private static int resourceLenght = System.Enum.GetValues(typeof(S_Resource.Supplies)).Length;
    public S_Resource[] Resource { get => resource;}
    private S_StatDisplayManager statDisplayManager;
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

    public void ChangeScore(S_Resource.Supplies supplies, int changeAmmount)
    {
        Resource[((int)supplies)].ammount += changeAmmount;
        Debug.Log("Changed Resources by:" + changeAmmount);
    }

    public void ResetResources()
    {
        for (int i = 0; i < resourceLenght; i++)
        {
            Resource[i].type = (S_Resource.Supplies)i;
            Resource[i].ammount = 0;
        }
    }

    //private void ChangedActiveScene(Scene current, Scene next)
    //{
    //    if (current.name == "Starting" && next == null)
    //    {
    //        statDisplayManager = FindAnyObjectByType<S_StatDisplayManager>();
    //        statDisplayManager.SetStatDisplay();
    //    }
    //    else if (current.name == "Main" && next == null)
    //    {
    //        ResetResources();
    //        Debug.Log("Reseted Resources");
    //    }
    //    else
    //        Debug.LogError("Did not register scene change\n current scene: " + current + " next scene: " + next);
    //}
}
