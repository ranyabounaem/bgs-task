using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Items
{
    public delegate void InventoryHandler();
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        List<Item> _items = new List<Item>(12);
        public event InventoryHandler OnInventoryUpdated;
        //public event InventoryHandler OnItemAdded;
        //public event InventoryHandler OnItemRemoved;

        public List<Item> Items => _items;
        public int GetCapacity()
        {
            return _items.Capacity;
        }
        public bool AddItem(Item item)
        {
            if (_items.Count < _items.Capacity)
            {
                _items.Add(item);
                OnInventoryUpdated.Invoke();
                return true;
            }
            else
                return false;
        }

        public bool RemoveItem(Item item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                OnInventoryUpdated.Invoke();
                return true;
            }
            else
                return false;
        }

        public bool RemoveItem(int index)
        {
            if (index >= _items.Count)
                return false;
            _items.RemoveAt(index);
            return true;
        }
    }
}

