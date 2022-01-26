using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEditor;
using Structs;
using Controllers;

namespace Player
{
    public delegate void LaunchBall();
    public delegate void AlignBall(Vector3 coords);

    public class PlayerController : MonoBehaviour
    {
        public event LaunchBall OnLaunchBall;
        public event AlignBall OnAlignBall;

        [SerializeField, Tooltip("Attach camera 1 here")]
        private Camera _player1Camera;

        [SerializeField, Tooltip("Tie camera 2 here")]
        private Camera _player2Camera;

        [SerializeField, Range(1, 10)]
        private float _moveSpeed = 2f;

        [SerializeField, Range(1.001f, 2), Tooltip("How fast the player will be slown down.")]
        private float _inertiaFactor = 1.05f;

        [SerializeField, Range(1.5f, 4f), Tooltip("Force, that moves player out of the wall.")]
        private float _outForce = 1.5f;

        public Players? BallOwner = null;

        private PlayerControls _controls;

        private Vector2 _player1Speed = new Vector2(0, 0);
        private Vector2 _player2Speed = new Vector2(0, 0);

        private GameManager _gameManager;

        private void Awake()
        {
            _controls = new PlayerControls();

            _controls.GameMap.LaunchBall.performed += OnLaunchButtonPress;

            if(_player1Camera is null || _player2Camera is null)
            {
                Debug.LogError("Player cameras are not set. Set them.");
                EditorApplication.isPlaying = false;
            }

            _player1Camera.GetComponent<CameraController>().OnCollision += OnCamera1Collision;
            _player2Camera.GetComponent<CameraController>().OnCollision += OnCamera2Collision;

            _gameManager = GetComponent<GameManager>();
        }

        /**
         * <summary>Prevent Player 1 from escape</summary>
         */
        private void OnCamera1Collision(Collision collision)
        {
            if (collision.gameObject == _gameManager.Ball.gameObject) return;

            foreach (ContactPoint contact in collision.contacts)
            {
                _player1Speed = contact.normal * _outForce;
            }
        }

        /**
         * <summary>Prevent Player 2 from escape</summary>
         */
        private void OnCamera2Collision(Collision collision)
        {
            if (collision.gameObject == _gameManager.Ball.gameObject) return;

            foreach (ContactPoint contact in collision.contacts)
            {
                _player2Speed = contact.normal * _outForce;
            }
        }

        /**
         * <summary>Transform joystick/keyboard controls force to vector3</summary>
         * <param name="axis">Vecto2 input axis.</param>
         * <returns>Vector3 of camera movement direction</returns>
         */
        private Vector3 AxisToPlayer(Vector2 axis)
        {
            return new Vector3(axis.x, axis.y, 0);
        }

        /**
         * <summary>Align ball if it is in player's hands</summary>
         * <param name="coords">Coordinates of the ball</param>
         */
        private void AlignBall(Vector3 coords)
        {
            OnAlignBall?.Invoke(coords);
        }

        /**
         * <summary>Move cameras while update</summary>
         */
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

            if(BallOwner == Players.Player1)
            {
                var pos = _player1Camera.transform.position;
                AlignBall(new Vector3(pos.x, pos.y, pos.z + 1));
            }

            var directionPlayer2 = _controls.GameMap.Player2Move.ReadValue<Vector2>();
            if (directionPlayer2 != Vector2.zero)
            {
                directionPlayer2.x *= -1; // Reverse X.
                _player2Speed += directionPlayer2;
                _player2Speed = Vector2.ClampMagnitude(_player2Speed, _moveSpeed);
            }
            _player2Camera.transform.position += AxisToPlayer(_player2Speed) * _moveSpeed * Time.deltaTime;
            _player2Speed /= _inertiaFactor;

            if (BallOwner == Players.Player2)
            {
                var pos = _player2Camera.transform.position;
                AlignBall(new Vector3(pos.x, pos.y, pos.z - 1));
            }
        }

        private void Update()
        {
            MoveCameras();
        }

        private void OnLaunchButtonPress(CallbackContext context)
        {
            if(BallOwner is null)
            {
                return;
            }

            OnLaunchBall?.Invoke();
            BallOwner = null;
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
