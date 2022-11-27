using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Items
{
    public delegate bool InventoryHandler(Item item);
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        List<Item> items = new List<Item>(12);
        public event InventoryHandler OnItemAdded;
        public event InventoryHandler OnItemRemoved;

        public bool AddItem(Item item)
        {
            if (items.Count < items.Capacity)
            {
                items.Add(item);
                OnItemAdded.Invoke(item);
                return true;
            }
            else
                return false;
        }

        public bool RemoveItem(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                OnItemRemoved.Invoke(item);
                return true;
            }
            else
                return false;
        }

        public bool RemoveItem(int index)
        {
            if (index >= items.Count)
                return false;
            items.RemoveAt(index);
            return true;
        }
    }
}

