using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

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
    [SerializeField, Tooltip("")] private S_Resource resourcePrefab;
    [SerializeField, Tooltip("A List of the resources and the assosiated values")] private S_Resource[] resource = new Resource[System.Enum.GetValues(typeof(S_Resource.Supplies)).Length];
    private int resourceLenght = System.Enum.GetValues(typeof(S_Resource.Supplies)).Length;


    #endregion
    void Start()
    {
        for (int i = 0; i < resourceLenght; i++)
        {
            resource[i].type = (S_Resource.Supplies)i;
            resource[i].ammount = 0;
        }
    }


    void Update()
    {

    }

    public void ChangeScore(S_Resource.Supplies supplies, int changeAmmount)
    {
        resource[((int)supplies)].ammount += changeAmmount;
    }
}
