using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionCaller : MonoBehaviour
{
    public int idToSearch = -1;
    public string nameToSearch;
    int previousID;
    string previousName;

    // Start is called before the first frame update
    void Start()
    {
        previousID = idToSearch;
        previousName = nameToSearch;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (idToSearch != previousID)
        {
            InventoryItem binarySearchResult = InventoryManager.BinarySearchByID(idToSearch);
            if (binarySearchResult != null)
            {
                Debug.Log($"Binary Search Result - Name: {binarySearchResult.name}, ID: {binarySearchResult.ID}, Value: {binarySearchResult.value}");
            }
            else
            {
                Debug.Log($"Binary Search Failed, ID {idToSearch} not found in Item List");
            }

            previousID = idToSearch;
        }
        
        if (nameToSearch != previousName)
        {
            InventoryItem linearItemResult = InventoryManager.LinearSearchByName(nameToSearch);
            if (linearItemResult != null)
            {
                Debug.Log($"Linear Search Result - Name: {linearItemResult.name}, ID: {linearItemResult.ID}, Value: {linearItemResult.value}");
            }
            else
            {
                Debug.Log($"Linear Search Failed, name {nameToSearch} not found in Item List");
            }

            previousName = nameToSearch;
        }
    }
}
