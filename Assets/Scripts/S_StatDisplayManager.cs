using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S_StatDisplayManager : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text foodText;
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text waterText;
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text heatText;
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text toiletriesText;
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text miscText;

    private S_ScoreManager scoreManager;
    private S_Resource[] resources;

    #endregion
    void Start()
    {
        scoreManager = FindAnyObjectByType<S_ScoreManager>();
        if (scoreManager != null)
            SetStatDisplay();
    }

    public void SetStatDisplay()
    {
        resources = scoreManager.Resource;
        for (int i = 0; i < resources.Length; i++)
        {
            switch (resources[i].type)
            {
                case S_Resource.Supplies.water:
                    if (waterText != null)
                        waterText.text = "" + resources[i].ammount;
                    else
                        Debug.LogWarning("Water text is null");
                    break;
                case S_Resource.Supplies.food:
                    if (foodText != null)
                        foodText.text = "" + resources[i].ammount;
                    else
                        Debug.LogWarning("Food text is null");
                    break;
                case S_Resource.Supplies.toilet:
                    if (toiletriesText != null)
                        toiletriesText.text = "" + resources[i].ammount;
                    else
                        Debug.LogWarning("Toiletries text is null");
                    break;
                case S_Resource.Supplies.heat:
                    if (heatText != null)
                        heatText.text = "" + resources[i].ammount;
                    else
                        Debug.LogWarning("Heat text is null");
                    break;
                case S_Resource.Supplies.misc:
                    if (miscText != null)
                        miscText.text = "" + resources[i].ammount;
                    else
                        Debug.LogWarning("Misc text is null");
                    break;
                default:
                    Debug.Log("S_StatDisplayManager: Did not set any text");
                    break;
            }
        }
    }
}
