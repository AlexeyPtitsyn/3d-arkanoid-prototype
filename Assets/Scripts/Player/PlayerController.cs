using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Player
{

    public class PlayerController : MonoBehaviour
    {
        private PlayerControls _controls;

        private void Awake()
        {
            _controls = new PlayerControls();

            _controls.GameMap.LaunchBall.performed += OnLaunchBall;
        }

        private void Update()
        {
            var directionPlayer1 = _controls.GameMap.Player1Move.ReadValue<Vector2>();
            if(directionPlayer1 != Vector2.zero)
            {
                var camera1 = GameObject.Find("Player1Camera");
                camera1.transform.position = directionPlayer1 * Time.deltaTime;
            }

            var directionPlayer2 = _controls.GameMap.Player2Move.ReadValue<Vector2>();
            if (directionPlayer2 != Vector2.zero)
            {
                var camera2 = GameObject.Find("Player2Camera");
                camera2.transform.position = directionPlayer2 * Time.deltaTime;
            }
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