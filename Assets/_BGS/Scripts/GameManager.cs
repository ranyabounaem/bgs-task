using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Items;
using BGS.UI;
using BGS.ShopSystem;

public class GameManager : MonoBehaviour
{
    [Header("Starting Items")]
    [SerializeField]
    Item _top;
    [SerializeField]
    Item _bottom;

    [Header("References")]
    [SerializeField]
    Equipment _equipment;
    [SerializeField]
    Container _inventory;
    [SerializeField]
    UIManager _uiManager;
    

    private void Awake()
    {
        _uiManager.Setup(_equipment, _inventory);
        _equipment.Setup(_inventory);
        _inventory.AddItem(_top);
        _inventory.AddItem(_bottom);
        _equipment.Equip(_inventory.Items[0]);
        _equipment.Equip(_inventory.Items[0]);
    }
}
