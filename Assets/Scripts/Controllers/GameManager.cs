/**
 * <summary>This is the main game controller.</summary>
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Structs;

namespace Controllers
{
    [RequireComponent(typeof(PlayerController))]
    public class GameManager : MonoBehaviour
    {
        private PlayerController _playerController;

        [SerializeField, Tooltip("Wire up ball here")]
        private BallController _ball;

        [SerializeField, Tooltip("Who starts the game?")]
        private Players _initialBallOwner = Players.Player1;

        private Vector3 _ballMoveVector = Vector3.zero;

        [SerializeField, Range(.5f, 5f)]
        private float _ballMoveSpeed = 1f;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            _playerController.BallOwner = _initialBallOwner;
            _playerController.OnAlignBall += OnAlignBall;
            _playerController.OnLaunchBall += OnLaunchBall;
        }

        void OnAlignBall(Vector3 coords)
        {
            _ball.gameObject.transform.position = coords;
        }

        void OnLaunchBall()
        {
            switch (_playerController.BallOwner)
            {
                case Players.Player1:
                    _ballMoveVector.z = 1;
                    break;
                case Players.Player2:
                    _ballMoveVector.z = -1;
                    break;
            }

            StartCoroutine(BallMovementCoroutine());
        }

        IEnumerator BallMovementCoroutine()
        {
            while(true)
            {
                _ball.gameObject.transform.position += _ballMoveVector * _ballMoveSpeed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
