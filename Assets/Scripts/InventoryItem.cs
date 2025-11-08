using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem 
{
    public int ID;
    public string name;
    public float value;

    public InventoryItem(int a, string b, float c)
    {
        ID = a;
        name = b;
        value = c;
    }
}
