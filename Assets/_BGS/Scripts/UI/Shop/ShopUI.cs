using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.ShopSystem;
using BGS.Items;
namespace BGS.UI
{
    public class ShopUI : ContainerUI
    {
        Container _playerInventory;

        public void Setup(Container playerInventory, Container shop)
        {
            Setup(shop);
            _playerInventory = playerInventory;
        }

        protected override void HandleSlotClicked(int index)
        {
            base.HandleSlotClicked(index);

            if (index < _container.Items.Count)
            {
                var __clickedItem = _container.Items[index];
                var __cost = __clickedItem.Cost;
                if (_playerInventory.Currency >= __cost)
                {
                    _playerInventory.UseCurrency(__cost);
                    _playerInventory.AddItem(__clickedItem);
                    _container.AddCurrency(__cost);
                    _container.RemoveItem(index);

                }
            }   
        }
    }
}

