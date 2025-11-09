using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static List<InventoryItem> InventoryItemList = new List<InventoryItem>();
    public int rand_ID;
    public float rand_Value;    
    private string[] nArray = {"SWORD", "SHIELD", "BOW", "POTION", "EYEOFAGRESS", "WAND", "SPELLBOOK"};

    void Awake()
    {
        int[] previousIDs = new int[nArray.Length];

        for (int i = 0; i < nArray.Length; i++)
        {
            int temp = Random.Range(1, 11);

            while (previousIDs.Contains(temp))
            {
                temp = Random.Range(1, 11);
            }

            rand_ID = temp;
            previousIDs[i] = rand_ID;
            
            rand_Value = Random.Range(20f, 50f);

            InventoryItemList.Add(new InventoryItem(rand_ID, nArray[i], rand_Value));
        }
    }

    void Start()
    {
        PrintInventoryList("Initial List");
        QuickSortByValue();
    }

  public static InventoryItem LinearSearchByName(string itemName)
    {
        if (itemName == null)
        {
            return null;
        }

        foreach (InventoryItem item in InventoryItemList)
        {
            if (itemName.ToUpper().Replace(" ", string.Empty) == item.name)
            {
                return item;
            }
        }

        return null;
    }

    public static InventoryItem BinarySearchByID(int ID)
    {
        void QuickSort (int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivotIndex = (left + right) / 2;
            int pivotID = InventoryItemList[pivotIndex].ID;

            int i = left;
            int j = right;

            while (i <= j)
            {
                while (InventoryItemList[i].ID < pivotID)
                {
                    i++;
                }

                while (InventoryItemList[j].ID > pivotID)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = InventoryItemList[i];
                    InventoryItemList[i] = InventoryItemList[j];
                    InventoryItemList[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(left, j);
            }

            if (i < right)
            {
                QuickSort(i, right);
            }
        }

        QuickSort(0, InventoryItemList.Count - 1);

        int left = 0;
        int right = InventoryItemList.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (InventoryItemList[mid].ID == ID)
            {
                return InventoryItemList[mid];
            }
            else if (InventoryItemList[mid].ID < ID)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return null;        
    }

    public void QuickSortByValue()
    {
        void QuickSort(int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivotIndex = (left + right) / 2;
            float pivotValue = InventoryItemList[pivotIndex].value;

            int i = left;
            int j = right;

            while (i <= j)
            {
                while (InventoryItemList[i].value < pivotValue)
                {
                    i++;
                }

                while (InventoryItemList[j].value > pivotValue)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = InventoryItemList[i];
                    InventoryItemList[i] = InventoryItemList[j];
                    InventoryItemList[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(left, j);
            }

            if (i < right)
            {
                QuickSort(i, right);
            }
        }

        QuickSort(0, InventoryItemList.Count - 1);

        PrintInventoryList("Quick Sorted List");
    }

    public void PrintInventoryList(string title)
    {
        Debug.Log($"---{title}---");
        foreach (InventoryItem item in InventoryItemList)
        {
            Debug.Log($"Name: {item.name}, ID: {item.ID}, Value: {item.value}");
        }
    }
}
