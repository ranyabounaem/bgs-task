using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BGS.Items;

namespace BGS.UI
{
    public class ContainerUI : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> _slots;
        protected Container _container;

        [Header("References")]
        [SerializeField]
        GameObject _slotUI;
        [SerializeField]
        Text _text;
        private void OnDisable()
        {
            _container.OnContainerUpdated -= RefreshContainer;
        }

        public virtual void Setup(Container container)
        {
            _container = container;
            _container.OnContainerUpdated += RefreshContainer;
            var capacity = _container.GetCapacity();
            
            if (_slots.Count == 0)
            {
                _slots = new List<GameObject>(capacity);
                CreateSlots();
            }
                 
            RefreshContainer();
        }

        protected void CreateSlots()
        {
            for (var i = 0; i < _slots.Capacity; i++)
            {
                var __slot = Instantiate(_slotUI, transform);
                _slots.Add(__slot);
                if (_slots[i].TryGetComponent(out SlotUI __slotUI))
                {
                    __slotUI.Index = i;
                    __slotUI.OnSlotClicked += HandleSlotClicked;
                }
            }
        }

        protected void RefreshContainer()
        {
            for (int i = 0; i < _slots.Capacity; i++)
            {
                var __slotUI = _slots[i].GetComponent<SlotUI>();
                Sprite __sprite = null;
                if (i < _container.Items.Count)
                {
                    __sprite = _container.Items[i]?.Sprite;
                }
                __slotUI.UpdateImageSprite(__sprite);
                __slotUI.Index = i;
                _text.text = "Currency: " + _container.Currency;
            }
        }

        protected virtual void HandleSlotClicked(int index)
        {

        }
    }
}

