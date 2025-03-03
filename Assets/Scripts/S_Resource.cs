using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_Resource
{
    public enum Supplies { water, food, heat, toilet, misc }
    public enum Items {hink, flaska, dunk, ljus, tändsticka, braständare, filt, jacka,
    halsduk, vantar, mössa, konservburk, knäckebröd, nötter, välling, toapapper, 
    hushållspapper, plastpåsar, blöjor, handsprit, första_hjälpen, konservöppnare, stormkök,
    penna, skrivblock, ryggsäck, ID, radio, mobil, karta, ficklampa}

    public Supplies type;
    public Items itemType;
    public int ammount;
}
