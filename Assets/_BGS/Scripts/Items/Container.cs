using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Items
{
    public delegate void ContainerHandler();
    public class Container : MonoBehaviour
    {
        int _currency = 200;

        public int Currency => _currency;

        [SerializeField]
        List<Item> _items = new List<Item>(12);
        public event ContainerHandler OnContainerUpdated;

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
                OnContainerUpdated.Invoke();
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
                OnContainerUpdated.Invoke();
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
            OnContainerUpdated.Invoke();
            return true;
        }

        public void UseCurrency(int amount)
        {
            _currency -= amount;
        }
        public void AddCurrency(int amount)
        {
            _currency += amount;
        }
    }
}

