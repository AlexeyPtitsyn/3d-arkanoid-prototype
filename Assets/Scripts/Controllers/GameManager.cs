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

        [SerializeField, Tooltip("Wire up the ball here")]
        public BallController Ball;

        [SerializeField, Tooltip("Who starts the game?")]
        private Players _initialBallOwner = Players.Player1;

        private Vector3 _ballMoveVector = Vector3.zero;

        [SerializeField, Range(.5f, 5f)]
        private float _ballMoveSpeed = 1f;

        [SerializeField, Tooltip("Number of player lives")]
        private int _lives = 3;

        [SerializeField]
        private GameObject _player1Gates;

        [SerializeField]
        private GameObject _player2Gates;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            _playerController.BallOwner = _initialBallOwner;
            _playerController.OnAlignBall += OnAlignBall;
            _playerController.OnLaunchBall += OnLaunchBall;

            Ball.OnCollision += OnBallCollision;
            Ball.OnTrigger += OnBallTrigger;

            InitLevel();
        }

        void InitLevel()
        {
            // TODO: improve this, so there can be many levels.
            var level = GameObject.Find("Well");

            List<GameObject> blocks = new List<GameObject>();
            foreach(Transform child in level.transform)
            {
                if(child.name == "Blocks")
                {
                    foreach(Transform block in child)
                    {
                        blocks.Add(block.gameObject);
                    }
                }
            }

            foreach (GameObject block in blocks)
            {
                block.transform.rotation = GiveMeRandomEuler();
            }
        }

        Quaternion GiveMeRandomEuler()
        {
            return Quaternion.Euler(
                Random.Range(0, 5),
                Random.Range(0, 5),
                Random.Range(0, 5)
            );
        }

        void LoseHealth(Players blame)
        {
            StopCoroutine(BallMovementCoroutine());

            Debug.Log($"{blame}, unfortunately, lost ball.");

            _ballMoveVector = Vector3.zero;
            _playerController.BallOwner = blame;

            _lives--;
            if(_lives <= 0)
            {
                GameOver();
            }
        }

        void GameOver()
        {
            Debug.Log("Game over.");
            UnityEditor.EditorApplication.isPlaying = false;
        }

        void OnBallTrigger(Collider other)
        {
            if(other.gameObject == _player1Gates)
            {
                LoseHealth(Players.Player1);
            }

            if(other.gameObject == _player2Gates)
            {
                LoseHealth(Players.Player2);
            }
        }

        void OnBallCollision(Collision collision)
        {
            _ballMoveVector = Vector3.Reflect(_ballMoveVector, collision.contacts[0].normal);

            if (collision.gameObject.tag == "Block")
            {
                Destroy(collision.gameObject);
                // TODO: reduce list.
            }
        }

        void OnAlignBall(Vector3 coords)
        {
            Ball.gameObject.transform.position = coords;
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
                Ball.gameObject.transform.position += _ballMoveVector * _ballMoveSpeed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
