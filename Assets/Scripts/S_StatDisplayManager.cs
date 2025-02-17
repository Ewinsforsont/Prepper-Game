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
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text MISCText;

    private S_ScoreManager scoreManager;

    #endregion
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
