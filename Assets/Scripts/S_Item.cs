using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class S_Item
{
    public enum Items
    {
        hink, flaska, dunk, ljus, tändsticka, braständare, filt, jacka,
        halsduk, vante, mössa, konservburk, knäckebröd, nötter, välling, toalettpapper,
        hushållspapper, plastpåse, blöja, handsprit, första_hjälpen, konservöppnare, stormkök,
        penna, skrivblock, ryggsäck, ID, radio, mobil, karta, ficklampa
    }
    public Items itemType;
    public int ammount;
}
