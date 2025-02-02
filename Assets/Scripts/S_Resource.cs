using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_Resource
{
    public enum Supplies { water, food, heat, communcation, money, toilet, misc }
    public Supplies type;
    public int ammount;
}
