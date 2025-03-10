using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_ResourceManager : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("Set what type of resource this is and how many points it is worth")] public S_Resource resource;
    [SerializeField, Tooltip("Set what type of item this is")] public S_Item.Items item;
    #endregion
}
