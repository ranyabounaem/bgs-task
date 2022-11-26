using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        
        private Rigidbody2D _rb;

        [Header("Movement")]
        [SerializeField] int _movementSpeed;
        bool _upPressed = false;
        bool _leftPressed = false;
        bool _downPressed = false;
        bool _rightPressed = false;

        // Preferably a setup method and called my game manager
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckForInput();
        }

        void CheckForInput()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _upPressed = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                _leftPressed = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _downPressed = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rightPressed = true;
            }

        }

        void ResetInput()
        {
            _upPressed = false;
            _leftPressed = false;
            _downPressed = false;
            _rightPressed = false;
        }

        private void FixedUpdate()
        {
            if (_upPressed)
            {
                _rb.AddForce(_movementSpeed * Vector2.up);
            }
            if (_leftPressed)
            {
                _rb.AddForce(_movementSpeed * Vector2.left);
            }
            if (_downPressed)
            {
                _rb.AddForce(_movementSpeed * Vector2.down);
            }
            if (_rightPressed)
            {
                _rb.AddForce(_movementSpeed * Vector2.right);
            }
            ResetInput();
        }
    }
}

