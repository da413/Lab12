using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<InventoryItem> InventoryItemList = new List<InventoryItem>();

    public int rand_ID;
    public float rand_Value;

    public string[] nameArray = new string[10];


    void Start()
    {
        for(int i = 0; i<10; i++)
        {
            rand_ID = Random.Range(1, 11);
            rand_Value = Random.Range(20f, 50f);

            InventoryItemList.Add(new InventoryItem(rand_ID, nameArray[i], rand_Value));

            Debug.Log(InventoryItemList[i].name);
        }

        
    }

}
