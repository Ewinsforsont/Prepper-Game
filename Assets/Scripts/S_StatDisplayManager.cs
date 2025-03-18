using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S_StatDisplayManager : MonoBehaviour
{
    #region Variables
    [Header ("Text fields")]
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text foodText;
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text waterText;
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text heatText;
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text toiletriesText;
    [SerializeField, Tooltip("The textfield that manages the specified resource")] private TMP_Text miscText;
    [SerializeField, Tooltip("The textfield that displayes the items collected in the main scene")] private TMP_Text itemText;

    private S_ScoreManager scoreManager;
    private S_Resource[] resources;
    private S_Item[] items;
    private string[] itemNames;
    [Header("Options")]
    [SerializeField, Tooltip("If enabled items that were not collected will not show up on display")] private bool hideEmptyItems;
    [Header ("Debug")]
    [SerializeField] private bool updateStatDisplay = false;
    [SerializeField] private bool printText = false;

    #endregion
    void Start()
    {
        scoreManager = FindAnyObjectByType<S_ScoreManager>();
        if (scoreManager != null)
            SetStatDisplay();
        else
            Debug.LogWarning("No scoreManager");
    }

    void Update()
    {
        if (updateStatDisplay)
            SetStatDisplay();
    }

    /// <summary>
    /// Set the text of the specified Text Fields to the numbers stored in the scoreManager
    /// </summary>
    public void SetStatDisplay()
    {
        if (scoreManager == null)
            scoreManager = FindAnyObjectByType<S_ScoreManager>();
        resources = scoreManager.Resource;
        items = scoreManager.Items;
        
        for (int i = 0; i < resources.Length; i++) // Switch for resource text display
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
                    Debug.LogError("S_StatDisplayManager: Did not set any text");
                    break;
            }
        }
        string text = "";
        itemNames = SetItemText(items);
        for (int i = 0; i < scoreManager.Items.Length; i++)
        {
            if (!hideEmptyItems)
            {
                text += items[i].ammount + itemNames[i];
                if (printText)
                    Debug.Log(items[i].ammount + " " + i);
            }
            else if (hideEmptyItems && items[i].ammount != 0)
            {
                text += items[i].ammount + itemNames[i];
                if (printText)
                    Debug.Log(items[i].ammount + " " + i);
            }
        }
        if (itemText != null)
            itemText.text = text;
        else
            Debug.LogWarning("Item Text is null");
        if (printText)
            Debug.Log(text);
        updateStatDisplay = false;
    }

    /// <summary>
    /// changes the names to singular or plural depending on how many items is in the item list
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    private string[] SetItemText(S_Item[] items)
    {
        string[] names = new string[System.Enum.GetValues(typeof(S_Item.Items)).Length];
        for (int i = 0; i < items.Length; i++)
        {
            switch (items[i].itemType)
            {
                case S_Item.Items.hink:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " hinkar, ";
                    else
                        names[i] = " hink, ";
                    break;
                case S_Item.Items.flaska:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " flaskor, ";
                    else
                        names[i] = " flaska, ";
                    break;
                case S_Item.Items.dunk:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " dunkar, ";
                    else
                        names[i] = " dunk, ";
                    break;
                case S_Item.Items.t�ndsticka:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " t�ndstickor, ";
                    else
                        names[i] = " t�ndsticka, ";
                    break;
                case S_Item.Items.filt:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " filtar, ";
                    else
                        names[i] = " filt, ";
                    break;
                case S_Item.Items.jacka:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " jackor, ";
                    else
                        names[i] = " jacka, ";
                    break;
                case S_Item.Items.halsduk:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " halsdukar, ";
                    else
                        names[i] = " halsduk, ";
                    break;
                case S_Item.Items.vante:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " vantar, ";
                    else
                        names[i] = " vante, ";
                    break;
                case S_Item.Items.m�ssa:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " m�ssor, ";
                    else
                        names[i] = " m�ssa, ";
                    break;
                case S_Item.Items.konservburk:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " konservburkar, ";
                    else
                        names[i] = " konservburk, ";
                    break;
                case S_Item.Items.n�tter:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " p�sar n�tter, ";
                    else
                        names[i] = " p�se n�tter, ";
                    break;
                case S_Item.Items.v�lling:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " kartonger v�lling, ";
                    else
                        names[i] = " kartong v�lling, ";
                    break;
                case S_Item.Items.toalettpapper:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " rullar toalettpapper, ";
                    else
                        names[i] = " rulle toalettpapper, ";
                    break;
                case S_Item.Items.hush�llspapper:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " rullar hush�llspapper, ";
                    else
                        names[i] = " rulle hush�llspapper, ";
                    break;
                case S_Item.Items.plastp�se:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " plastp�sar, ";
                    else
                        names[i] = " plastp�se, ";
                    break;
                case S_Item.Items.bl�ja:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " bl�jor, ";
                    else
                        names[i] = " bl�ja, ";
                    break;
                case S_Item.Items.f�rsta_hj�lpen:
                    names[i] = " f�rsta hj�lpen kit, ";
                    break;
                case S_Item.Items.penna:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " pennor, ";
                    else
                        names[i] = " penna, ";
                    break;
                case S_Item.Items.ryggs�ck:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " ryggs�ckar, ";
                    else
                        names[i] = " ryggs�ck, ";
                    break;
                case S_Item.Items.ID:
                    names[i] = " ID papper, ";
                    break;
                case S_Item.Items.radio:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " radior, ";
                    else
                        names[i] = " radio, ";
                    break;
                case S_Item.Items.mobil:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " mobiler, ";
                    else
                        names[i] = " mobil, ";
                    break;
                case S_Item.Items.karta:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " kartor, ";
                    else
                        names[i] = " karta, ";
                    break;
                case S_Item.Items.ficklampa:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " ficklampor, ";
                    else
                        names[i] = " ficklampa, ";
                    break;
                case S_Item.Items.nalleBj�rn:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " teddybj�rnar, ";
                    else
                        names[i] = " teddybj�rn, ";
                    break;
                case S_Item.Items.p�rm:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " p�rmar";
                    else
                        names[i] = " p�rm";
                    break;
                default:
                    names[i] = " " + items[i].itemType + ", ";
                    break;
            }
        }
        return names;

    }
}
