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
            AudioManager.instance.Play("Door_Open_SFX");
            _UIManager.OpenShopDialogue(_shop);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            AudioManager.instance.Play("Door_Close_SFX");
            _UIManager.CloseShop();
        }
    }
}

