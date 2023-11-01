using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    // Add methods for item management (e.g., AddItem, RemoveItem, UseItem).

    public void AddItem(Item item)
    {
        items.Add(item);
        // You can update the UI to reflect the changes in the inventory.
    }

}
