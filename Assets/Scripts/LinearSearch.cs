using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearSearch : MonoBehaviour
{
    public string searchName;

    void Start()
    {
        Debug.Log(LinearSearchMethod());
    }

    public string LinearSearchMethod()
    {
        if(searchName == null)
            return "Search is null";

        foreach(InventoryItem item in InventoryManager.InventoryItemList){
            
            if(searchName.ToUpper().Replace(" ", string.Empty) == item.name){
                return item.name;
            }
            
        }
        return "item not found";
    }
}
