using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Items;

namespace BGS.UI
{
    public class InventoryUI : ContainerUI
    {
        Equipment _playerEquipment;
        UIManager _UIManager;

        public void Setup(UIManager UIManager, Container inventory, Equipment equipment)
        {
            Setup(inventory);
            _playerEquipment = equipment;
            _UIManager = UIManager;
        }

        protected override void HandleSlotClicked(int index)
        {
            if (index < _container.Items.Count)
            {
                var __activeShop = _UIManager.GetActiveShop();
                if (__activeShop != null)
                {
                    var __clickedItem = _container.Items[index];
                    var __cost = __clickedItem.Cost;
                    if (__activeShop.Currency >= __cost)
                    {
                        __activeShop.UseCurrency(__cost);
                        __activeShop.AddItem(__clickedItem);
                        AudioManager.instance.Play("Sell_SFX");
                        _container.AddCurrency(__cost);
                        _container.RemoveItem(index);
                    }
                }
                else
                {
                    _playerEquipment.Equip(_container.Items[index]);
                }

                
            }
           
           
        }
    }
}

