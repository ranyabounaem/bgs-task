using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Items;

namespace BGS.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] int _movementSpeed = 20;

        Vector2 _movementInput = Vector2.zero;

        [Header("References")]
        Rigidbody2D _rb;
        Animator _anim;
        Equipment _equipment;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            _equipment = GetComponent<Equipment>();
        }

        private void Update()
        {
            CheckForInput();
            UpdateAnimLayers();
        }
        private void FixedUpdate()
        {   
            _rb.AddForce(_movementInput * _movementSpeed);
            if (_movementInput.magnitude > 0)
            {
                
            }
            ResetInput();
        }

        void CheckForInput()
        {
            if (Input.GetKey(KeyCode.W))
                _movementInput.y = 1;
            if (Input.GetKey(KeyCode.A))
                _movementInput.x = -1;
            if (Input.GetKey(KeyCode.S))
                _movementInput.y = -1;
            if (Input.GetKey(KeyCode.D))
                _movementInput.x = 1;

        }

        void UpdateAnimLayers()
        {
            if (_movementInput.magnitude > 0)
            {
                _anim.SetFloat("x", _movementInput.x);
                _anim.SetFloat("y", _movementInput.y);
                _anim.SetLayerWeight(_anim.GetLayerIndex("Idle"), 0);
                _anim.SetLayerWeight(_anim.GetLayerIndex("Walk"), 1);
                _equipment.UpdatePlayerDirection(_movementInput);
                _equipment.SetAnimatorLayer("Walk");
            }
            else
            {
                _anim.SetLayerWeight(_anim.GetLayerIndex("Idle"), 1);
                _anim.SetLayerWeight(_anim.GetLayerIndex("Walk"), 0);
                _equipment.SetAnimatorLayer("Idle");
            }
        }

        void ResetInput()
        {
            _movementInput = Vector2.zero;

        }

    }
}

