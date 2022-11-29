using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Items
{
    public delegate void EquipmentHandler();
    public class Equipment : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer _characterTop;
        [SerializeField]
        SpriteRenderer _characterBottom;

        Item _top = null;
        Item _bottom = null;
        Container _inventory;

        Animator _topAnimator, _bottomAnimator;
        AnimatorOverrideController _topOverrideController, _bottomOverrideController;

        public event EquipmentHandler OnEquipmentChanged;
        public void Setup(Container inventory)
        {
            _inventory = inventory;
            _topAnimator = _characterTop.gameObject.GetComponent<Animator>();
            _bottomAnimator = _characterBottom.gameObject.GetComponent<Animator>();
            _topOverrideController = new AnimatorOverrideController(_topAnimator.runtimeAnimatorController);
            _bottomOverrideController = new AnimatorOverrideController(_bottomAnimator.runtimeAnimatorController);
            _topAnimator.runtimeAnimatorController = _topOverrideController;
            _bottomAnimator.runtimeAnimatorController = _bottomOverrideController;
        }
        public bool CanDeEquip()
        {
            return _inventory.Items.Count < _inventory.Items.Capacity;
        }

        public void Equip(Item item)
        {
            if (item.Type == ItemType.Top)
            {
                if (_top != null)
                {
                    DeEquip(_top);
                }
                _top = item;
                _characterTop.sprite = item.Sprite;

                _topOverrideController["Idle_Down"] = _top.Clips[0];
                _topOverrideController["Idle_Left"] = _top.Clips[1];
                _topOverrideController["Idle_Right"] = _top.Clips[2];
                _topOverrideController["Idle_Up"] = _top.Clips[3];
                _topOverrideController["Walk_Down"] = _top.Clips[4];
                _topOverrideController["Walk_Left"] = _top.Clips[5];
                _topOverrideController["Walk_Right"] = _top.Clips[6];
                _topOverrideController["Walk_Up"] = _top.Clips[7];

                var __color = _characterTop.color;
                __color.a = 1;
                _characterTop.color = __color;

            }
            else if (item.Type == ItemType.Bottom)
            {
                if (_bottom != null)
                {
                    DeEquip(_bottom);
                }
                _bottom = item;

                var __color = _characterBottom.color;
                __color.a = 1;
                _characterBottom.color = __color;

                _bottomOverrideController["Idle_Down"] = _bottom.Clips[0];
                _bottomOverrideController["Idle_Left"] = _bottom.Clips[1];
                _bottomOverrideController["Idle_Right"] = _bottom.Clips[2];
                _bottomOverrideController["Idle_Up"] = _bottom.Clips[3];
                _bottomOverrideController["Walk_Down"] = _bottom.Clips[4];
                _bottomOverrideController["Walk_Left"] = _bottom.Clips[5];
                _bottomOverrideController["Walk_Right"] = _bottom.Clips[6];
                _bottomOverrideController["Walk_Up"] = _bottom.Clips[7];
            }
            _inventory.RemoveItem(item);
            OnEquipmentChanged?.Invoke();
            AudioManager.instance.Play("Equip_SFX");

        }

        public void DeEquip(Item item)
        {
            if (_bottom == item)
            {
                if (_bottom == null)
                    return;
                _inventory.AddItem(item);
                _bottom = null;

                _bottomOverrideController["Idle_Down"] = null;
                _bottomOverrideController["Idle_Left"] = null;
                _bottomOverrideController["Idle_Right"] = null;
                _bottomOverrideController["Idle_Up"] = null;
                _bottomOverrideController["Walk_Down"] = null;
                _bottomOverrideController["Walk_Left"] = null;
                _bottomOverrideController["Walk_Right"] = null;
                _bottomOverrideController["Walk_Up"] = null;

                var __color = _characterBottom.color;
                __color.a = 0;
                _characterBottom.color = __color;

            }
            else if (_top == item)
            {
                if (_top == null)
                    return;
                _inventory.AddItem(item);
                _top = null;
                _characterTop.sprite = null;

                _topOverrideController["Idle_Down"] = null;
                _topOverrideController["Idle_Left"] = null;
                _topOverrideController["Idle_Right"] = null;
                _topOverrideController["Idle_Up"] = null;
                _topOverrideController["Walk_Down"] = null;
                _topOverrideController["Walk_Left"] = null;
                _topOverrideController["Walk_Right"] = null;
                _topOverrideController["Walk_Up"] = null;

                var __color = _characterTop.color;
                __color.a = 0;
                _characterTop.color = __color;
            }
            OnEquipmentChanged?.Invoke();
            AudioManager.instance.Play("DeEquip_SFX");
        }

        public void DeEquip(int index)
        {
            if (index == 0)
            {
                if (_top == null)
                    return;
                _inventory.AddItem(_top);
                _top = null;
                _characterTop.sprite = null;

                _topOverrideController["Idle_Down"] = null;
                _topOverrideController["Idle_Left"] = null;
                _topOverrideController["Idle_Right"] = null;
                _topOverrideController["Idle_Up"] = null;
                _topOverrideController["Walk_Down"] = null;
                _topOverrideController["Walk_Left"] = null;
                _topOverrideController["Walk_Right"] = null;
                _topOverrideController["Walk_Up"] = null;

                var __color = _characterTop.color;
                __color.a = 0;
                _characterTop.color = __color;

            }
            else if (index == 1)
            {
                if (_bottom == null)
                    return;
                _inventory.AddItem(_bottom);
                _bottom = null;
                _characterBottom.sprite = null;

                _bottomOverrideController["Idle_Down"] = null;
                _bottomOverrideController["Idle_Left"] = null;
                _bottomOverrideController["Idle_Right"] = null;
                _bottomOverrideController["Idle_Up"] = null;
                _bottomOverrideController["Walk_Down"] = null;
                _bottomOverrideController["Walk_Left"] = null;
                _bottomOverrideController["Walk_Right"] = null;
                _bottomOverrideController["Walk_Up"] = null;

                var __color = _characterBottom.color;
                __color.a = 0;
                _characterBottom.color = __color;

            }
            OnEquipmentChanged?.Invoke();
            AudioManager.instance.Play("DeEquip_SFX");
        }

        public Sprite GetEquipmentSprite(ItemType slotType)
        {
            if (slotType == ItemType.Top)
            {
                if (_top != null)
                    return _top.Sprite;
            }
            else if (slotType == ItemType.Bottom)
            {
                if (_bottom != null)
                    return _bottom.Sprite;
            }
            return null;
        }

        public void UpdatePlayerDirection(Vector2 direction)
        {
            
            _bottomAnimator.SetFloat("x", direction.x);
            _bottomAnimator.SetFloat("y", direction.y);

            _topAnimator.SetFloat("x", direction.x);
            _topAnimator.SetFloat ("y", direction.y);
            
        }

        public void SetAnimatorLayer(string layerName)
        {
            for (var __i = 0; __i < _topAnimator.layerCount; __i++)
            {
                _topAnimator.SetLayerWeight(__i, 0);
            }
            _topAnimator.SetLayerWeight(_topAnimator.GetLayerIndex(layerName), 1);

            for (var __i = 0; __i < _bottomAnimator.layerCount; __i++)
            {
                _bottomAnimator.SetLayerWeight(__i, 0);
            }
            _bottomAnimator.SetLayerWeight(_bottomAnimator.GetLayerIndex(layerName), 1);
        }
    }
}

