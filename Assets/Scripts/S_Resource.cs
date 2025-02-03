using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_Resource
{
    public enum Supplies { water, food, heat, toilet, misc }
    public Supplies type;
    public int ammount;
}
