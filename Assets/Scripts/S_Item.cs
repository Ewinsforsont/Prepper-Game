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
        halsduk, vantar, mössa, konservburk, knäckebröd, nötter, välling, toapapper,
        hushållspapper, plastpåsar, blöjor, handsprit, första_hjälpen, konservöppnare, stormkök,
        penna, skrivblock, ryggsäck, ID, radio, mobil, karta, ficklampa
    }
    public Items itemType;
    public int ammount;
}
