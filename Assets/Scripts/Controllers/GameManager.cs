/**
 * <summary>This is the main game controller.</summary>
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Controllers
{
    [RequireComponent(typeof(PlayerController))]
    public class GameManager : MonoBehaviour
    {
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }
        
        void Start()
        {

        }

        void Update()
        {

        }
    }
}
