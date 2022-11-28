using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.UI;
using BGS.Items;

namespace BGS.ShopSystem
{
    public class Shop : MonoBehaviour
    {
        Container _shop;
        [SerializeField]
        UIManager _UIManager;
        private void Awake()
        {
            _shop = GetComponent<Container>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _UIManager.OpenShop(_shop);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _UIManager.CloseShop();
        }
    }
}

