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
                case S_Item.Items.tändsticka:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " tändstickor, ";
                    else
                        names[i] = " tändsticka, ";
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
                case S_Item.Items.mössa:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " mössor, ";
                    else
                        names[i] = " mössa, ";
                    break;
                case S_Item.Items.konservburk:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " konservburkar, ";
                    else
                        names[i] = " konservburk, ";
                    break;
                case S_Item.Items.nötter:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " påsar nötter, ";
                    else
                        names[i] = " påse nötter, ";
                    break;
                case S_Item.Items.välling:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " kartonger välling, ";
                    else
                        names[i] = " kartong välling, ";
                    break;
                case S_Item.Items.toalettpapper:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " rullar toalettpapper, ";
                    else
                        names[i] = " rulle toalettpapper, ";
                    break;
                case S_Item.Items.hushållspapper:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " rullar hushållspapper, ";
                    else
                        names[i] = " rulle hushållspapper, ";
                    break;
                case S_Item.Items.plastpåse:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " plastpåsar, ";
                    else
                        names[i] = " plastpåse, ";
                    break;
                case S_Item.Items.blöja:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " blöjor, ";
                    else
                        names[i] = " blöja, ";
                    break;
                case S_Item.Items.första_hjälpen:
                    names[i] = " första hjälpen kit, ";
                    break;
                case S_Item.Items.penna:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " pennor, ";
                    else
                        names[i] = " penna, ";
                    break;
                case S_Item.Items.ryggsäck:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " ryggsäckar, ";
                    else
                        names[i] = " ryggsäck, ";
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
                case S_Item.Items.nalleBjörn:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " teddybjörnar, ";
                    else
                        names[i] = " teddybjörn, ";
                    break;
                case S_Item.Items.pärm:
                    if (items[i].ammount > 1 || items[i].ammount == 0)
                        names[i] = " pärmar";
                    else
                        names[i] = " pärm";
                    break;
                default:
                    names[i] = " " + items[i].itemType + ", ";
                    break;
            }
        }
        return names;

    }
}
