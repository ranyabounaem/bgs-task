using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] int _movementSpeed = 20;

        Vector2 _movementInput = Vector2.zero;

        [Header("References")]
        Rigidbody2D _rb;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckForInput();
        }
        private void FixedUpdate()
        {
            _rb.AddForce(_movementInput * _movementSpeed);
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

        void ResetInput()
        {
            _movementInput = Vector2.zero;
        }

    }
}

