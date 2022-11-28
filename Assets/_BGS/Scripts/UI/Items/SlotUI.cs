using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BGS.UI
{
    public delegate void SlotClickHandler(int index);
    public class SlotUI : MonoBehaviour, IPointerClickHandler
    {
        public event SlotClickHandler OnSlotClicked;
        [SerializeField]
        Image _image;
        public int Index { get; set; }

        public void UpdateImageSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnSlotClicked.Invoke(Index);
        }
    }
}

