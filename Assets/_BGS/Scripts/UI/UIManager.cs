using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Items;

namespace BGS.UI
{
    public enum UIState { Normal, Shop }
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        InventoryUI _inventoryUI;
        [SerializeField]
        EquipmentUI _equipmentUI;
        [SerializeField]
        ShopUI _shopUI;

        Container _playerInventory;
        Container _activeShop;

        public Container GetActiveShop()
        {
            return _activeShop;
        }

        public void Setup(Equipment playerEquipment, Container playerInventory)
        {
            _playerInventory = playerInventory;
            _inventoryUI.Setup(this, playerInventory, playerEquipment);
            _equipmentUI.Setup(playerEquipment); 
        }

        public void OpenShop(Container activeShop)
        {
            _activeShop = activeShop;
            _shopUI.gameObject.SetActive(true);
            _shopUI.Setup(_playerInventory, activeShop);
        }

        public void CloseShop()
        {
            _activeShop = null;
            _shopUI.gameObject.SetActive(false);
        }
    }
}

