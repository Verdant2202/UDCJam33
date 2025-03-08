using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InGameData
{
    public static List<ItemSO> items = new List<ItemSO>();
    public static List<SwordPartSO> swordParts = new List<SwordPartSO>();
    public static bool doorOpen = false;
    public static void AddSwordPart(SwordPartSO swordPartSO)
    {
        swordParts.Add(swordPartSO);
    }

    public static void AddItem(ItemSO itemSO)
    {
        items.Add(itemSO);
    }
}
