using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Items;

namespace BGS.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> _slots;
        Inventory _playerInventory;

        [Header("References")]
        [SerializeField]
        GameObject _slotUI;

        public void Setup(Inventory inventory)
        {
            _playerInventory = inventory;
            _playerInventory.OnInventoryUpdated += RefreshInventory;
            var capacity = _playerInventory.GetCapacity();
            _slots = new List<GameObject>(capacity);
            CreateSlots();
            RefreshInventory();
        }

        void CreateSlots()
        {
            for (var i = 0; i < _slots.Capacity; i++)
            {
                var __slot = Instantiate(_slotUI, transform);
                _slots.Add(__slot);
            }
        }

        void RefreshInventory()
        {
            for (int i = 0; i < _playerInventory.Items.Count; i++)
            {
                if (_slots[i].TryGetComponent(out SlotUI __slotUI))
                {
                    __slotUI.itemSprite.sprite = _playerInventory.Items[i]?.Sprite;
                }
            }
        }
    }
}

