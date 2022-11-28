 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BGS.Items;


namespace BGS.UI
{
    public class EquipmentUI : MonoBehaviour
    {
        Equipment _playerEquipment;

        [SerializeField]
        SlotUI _topSlotUI;
        [SerializeField]
        SlotUI _bottomSlotUI;

        public void Setup(Equipment playerEquipment)
        {
            _playerEquipment = playerEquipment;
            _playerEquipment.OnEquipmentChanged += RefreshEquipment;
            _topSlotUI.Index = 0;
            _bottomSlotUI.Index = 1;
            _topSlotUI.OnSlotClicked += HandleSlotClicked;
            _bottomSlotUI.OnSlotClicked += HandleSlotClicked;
        }

        private void RefreshEquipment()
        {
            var __sprite = _playerEquipment.GetEquipmentSprite(ItemType.Top);
            _topSlotUI.UpdateImageSprite(__sprite);

            __sprite = _playerEquipment.GetEquipmentSprite(ItemType.Bottom);
            _bottomSlotUI.UpdateImageSprite(__sprite);
        }

        void HandleSlotClicked(int index)
        {
            if (_playerEquipment.CanDeEquip())
            {
                _playerEquipment.DeEquip(index);
            }
            
        }

    }
}

