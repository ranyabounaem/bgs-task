using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Items;

namespace BGS.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        InventoryUI _inventoryUI;
        [SerializeField]
        Inventory _playerInventory;

        void Awake()
        {
            _inventoryUI.Setup(_playerInventory);
        }
    }
}

