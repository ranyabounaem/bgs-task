using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Items
{
    public delegate void EquipmentHandler();
    public class Equipment : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer _characterTop;
        [SerializeField]
        SpriteRenderer _characterBottom;

        Item _top = null;
        Item _bottom = null;
        Container _inventory;

        public event EquipmentHandler OnEquipmentChanged;
        public void Setup(Container inventory)
        {
            _inventory = inventory;
        }
        public bool CanDeEquip()
        {
            return _inventory.Items.Count < _inventory.Items.Capacity;
        }

        public void Equip(Item item)
        {
            if (item.Type == ItemType.Top)
            {
                if (_top != null)
                {
                    DeEquip(_top);
                }
                _top = item;
                _characterTop.sprite = item.Sprite;
            }
            else if (item.Type == ItemType.Bottom)
            {
                if (_bottom != null)
                {
                    DeEquip(_bottom);
                }
                _bottom = item;
                _characterBottom.sprite = item.Sprite;
            }
            _inventory.RemoveItem(item);
            OnEquipmentChanged?.Invoke();

        }

        public void DeEquip(Item item)
        {
            if (_bottom == item)
            {
                if (_bottom == null)
                    return;
                _inventory.AddItem(item);
                _bottom = null;
                _characterBottom.sprite = null;
            }
            else if (_top == item)
            {
                if (_top == null)
                    return;
                _inventory.AddItem(item);
                _top = null;
                _characterTop.sprite = null;
            }
            OnEquipmentChanged?.Invoke();
        }

        public void DeEquip(int index)
        {
            if (index == 0)
            {
                if (_top == null)
                    return;
                _inventory.AddItem(_top);
                _top = null;
                _characterTop.sprite = null;
            }
            else if (index == 1)
            {
                if (_bottom == null)
                    return;
                _inventory.AddItem(_bottom);
                _bottom = null;
                _characterBottom.sprite = null;
                
            }
            OnEquipmentChanged?.Invoke();
        }

        public Sprite GetEquipmentSprite(ItemType slotType)
        {
            if (slotType == ItemType.Top)
            {
                if (_top != null)
                    return _top.Sprite;
            }
            else if (slotType == ItemType.Bottom)
            {
                if (_bottom != null)
                    return _bottom.Sprite;
            }
            return null;
        }
    }
}

