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

        [SerializeField]
        private Vector3 _ballMoveVector = Vector3.zero;

        [SerializeField, Range(.1f, 5f), Tooltip("Ball acceleration after hitting a block.")]
        private float _hitAcceleration = .5f;

        [SerializeField, Range(1f, 5f), Tooltip("Maximum ball acceleration after hitting a series of blocks.")]
        private float _hitAccelerationLimit = 5f;

        private float _hitCurrentAcceleration = 1f;

        [SerializeField, Range(.5f, 5f)]
        private float _ballMoveSpeed = 1f;

        [SerializeField, Tooltip("Number of player lives")]
        private int _lives = 3;

        [SerializeField]
        private GameObject _player1Gates;

        [SerializeField]
        private GameObject _player2Gates;

        private int _blocksCount = 0;
        private List<GameObject> _levels = new List<GameObject>();
        private int? _levelNumber;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            _playerController.BallOwner = _initialBallOwner;
            _playerController.OnAlignBall += OnAlignBall;
            _playerController.OnLaunchBall += OnLaunchBall;

            Ball.OnCollision += OnBallCollision;
            Ball.OnTrigger += OnBallTrigger;

            InitLevels();
            if(_levelNumber is null)
            {
                Debug.LogWarning("No levels found. Unable to continue.");
                GameOver();
            }
            InitLevel();
        }

        bool InitLevels()
        {
            Debug.Log("Init levels...");
            var levelContainer = GameObject.Find("Levels");
            int count = 0;
            foreach(Transform child in levelContainer.transform)
            {
                count++;
                _levels.Add(child.gameObject);
            }

            if(count > 0)
            {
                Debug.Log($"...found {count} levels.");
                _levelNumber = 0;
                return true;
            }
            _levelNumber = null;
            return false;
        }

        void OnCompleteLevel()
        {
            _levelNumber++;
            if(_levelNumber >= _levels.Count)
            {
                Debug.Log("Players passed all levels.");
                GameOver();
                return;
            }

            InitLevel();
        }

        void MoveAwayAllLevels()
        {
            foreach(var level in _levels)
            {
                level.transform.position = new Vector3(100, 100, 100);
            }
        }

        void InitLevel()
        {
            MoveAwayAllLevels();

            var level = _levels[(int)_levelNumber];

            Debug.Log($"Entering {level.name}...");

            level.transform.position = Vector3.zero;

            _blocksCount = 0;
            StopCoroutine(BallMovementCoroutine());
            _playerController.BallOwner = Players.Player1;
            _hitCurrentAcceleration = 1f;
            _ballMoveVector = Vector3.zero;

            List<GameObject> blocks = new List<GameObject>();
            foreach(Transform child in level.transform)
            {
                if(child.name == "Blocks")
                {
                    foreach(Transform block in child)
                    {
                        _blocksCount++;
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
            _hitCurrentAcceleration = 1f;

            _lives--;
            if(_lives <= 0)
            {
                GameOver();
            }
        }

        void GameOver()
        {
            StopCoroutine(BallMovementCoroutine());
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
                _hitCurrentAcceleration += _hitAcceleration;

                Destroy(collision.gameObject);
                _blocksCount--;
                if(_blocksCount <= 0)
                {
                    OnCompleteLevel();
                    return;
                }
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
                if (_hitCurrentAcceleration >= _hitAccelerationLimit)
                {
                    _hitCurrentAcceleration = _hitAccelerationLimit;
                }

                _ballMoveVector = _ballMoveVector.normalized;
                Ball.gameObject.transform.position += _ballMoveVector * _hitCurrentAcceleration * _ballMoveSpeed * Time.deltaTime;
                yield return null;
            }
        }
    }
}
