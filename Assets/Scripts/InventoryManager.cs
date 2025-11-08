using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static List<InventoryItem> InventoryItemList = new List<InventoryItem>();

    public int rand_ID;
    public float rand_Value;

    
    private string[] nArray = {"SWORD", "SHIELD", "BOW", "POTION", "EYEOFAGRESS", "WAND", "SPELLBOOK"};
    
   
    void Awake()
    {
        for(int i = 0; i<nArray.Length; i++)
        {
            rand_ID = Random.Range(1, 11);
            rand_Value = Random.Range(20f, 50f);

            InventoryItemList.Add(new InventoryItem(rand_ID, nArray[i], rand_Value));

           // Debug.Log(InventoryItemList[i].name);
        }

        
    }

}
