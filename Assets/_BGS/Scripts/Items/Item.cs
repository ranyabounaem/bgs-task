using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.Items
{
    public enum ItemType { Top, Bottom }
    public abstract class Item : ScriptableObject
    {
        [SerializeField]
        protected Sprite _sprite;
        [SerializeField]
        protected string _name;
        [SerializeField]
        protected int _cost;
        [SerializeField]
        protected ItemType _type;

    }
}

