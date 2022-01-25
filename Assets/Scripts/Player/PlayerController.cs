using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Camera _player1Camera;

        [SerializeField]
        private Camera _player2Camera;

        [SerializeField, Range(1, 10)]
        private float _moveSpeed = 2f;

        [SerializeField, Range(1.001f, 2), Tooltip("How fast the player will be slown down.")]
        private float _inertiaFactor = 1.05f;

        private PlayerControls _controls;

        private Vector2 _player1Speed = new Vector2(0, 0);
        private Vector2 _player2Speed = new Vector2(0, 0);

        private void Awake()
        {
            _controls = new PlayerControls();

            _controls.GameMap.LaunchBall.performed += OnLaunchBall;

            if(!_player1Camera || !_player2Camera)
            {
                Debug.LogError("Player cameras are not set. Set them.");
            }
        }

        private Vector3 AxisToPlayer(Vector2 axis)
        {
            return new Vector3(axis.x, axis.y, 0);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision!");
        }

        private void MoveCameras()
        {
            var directionPlayer1 = _controls.GameMap.Player1Move.ReadValue<Vector2>();
            if (directionPlayer1 != Vector2.zero)
            {
                _player1Speed += directionPlayer1;
                _player1Speed = Vector2.ClampMagnitude(_player1Speed, _moveSpeed);
            }
            _player1Camera.transform.position += AxisToPlayer(_player1Speed) * _moveSpeed * Time.deltaTime;
            _player1Speed /= _inertiaFactor;

            var directionPlayer2 = _controls.GameMap.Player2Move.ReadValue<Vector2>();
            if (directionPlayer2 != Vector2.zero)
            {
                directionPlayer2.x *= -1; // Reverse X.
                _player2Speed += directionPlayer2;
                _player2Speed = Vector2.ClampMagnitude(_player2Speed, _moveSpeed);
            }
            _player2Camera.transform.position += AxisToPlayer(_player2Speed) * _moveSpeed * Time.deltaTime;
            _player2Speed /= _inertiaFactor;
        }

        private void Update()
        {
            MoveCameras();
        }

        private void OnLaunchBall(CallbackContext context)
        {
            Debug.Log("Will launch ball.");
        }

        private void OnDestroy()
        {
            _controls.Dispose();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }
    }
}
