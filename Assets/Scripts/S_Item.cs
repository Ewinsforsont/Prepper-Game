using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class S_Item
{
    public enum Items
    {
        hink, flaska, dunk, ljus, t�ndsticka, brast�ndare, filt, jacka,
        halsduk, vante, m�ssa, konservburk, kn�ckebr�d, n�tter, v�lling, toalettpapper,
        hush�llspapper, plastp�se, bl�ja, handsprit, f�rsta_hj�lpen, konserv�ppnare, stormk�k,
        penna, skrivblock, ryggs�ck, ID, radio, mobil, karta, ficklampa
    }
    public Items itemType;
    public int ammount;
}
