using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.Items
{
    public enum ItemType { Top, Bottom }
    public abstract class Item : ScriptableObject
    {
        public Sprite Sprite => _sprite;
        public ItemType Type => _type;
        public int Cost => _cost;
        [SerializeField]
        protected Sprite _sprite;
        [SerializeField]
        protected string _name;
        [SerializeField]
        protected int _cost;
        [SerializeField]
        protected ItemType _type;

        public List<AnimationClip> Clips = new List<AnimationClip>(8);

    }
}

