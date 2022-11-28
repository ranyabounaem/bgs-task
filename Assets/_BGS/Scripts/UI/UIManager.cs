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
        [SerializeField]
        ShopDialogue _shopDialogue;

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
            _shopDialogue.Setup(this);
        }

        public void OpenShopDialogue(Container activeShop)
        {
            _activeShop = activeShop;
            _shopDialogue.gameObject.SetActive(true);
            _shopDialogue.StartDialogue();


        }

        public void OpenShop ()
        {
            _shopDialogue.ResetDialogue();
            _shopDialogue.gameObject.SetActive(false);
            _shopUI.transform.parent.gameObject.SetActive(true);
            _shopUI.Setup(_playerInventory, _activeShop);
        }

        public void CloseShop()
        {
            _shopDialogue.gameObject.SetActive(false);
            _activeShop = null;
            _shopUI.transform.parent.gameObject.SetActive(false);
        }
    }
}

