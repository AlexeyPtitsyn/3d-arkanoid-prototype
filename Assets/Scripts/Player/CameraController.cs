using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public delegate void CollisionEventHandler(Collision collision);

    public class CameraController : MonoBehaviour
    {
        public event CollisionEventHandler OnCollision;

        private void OnCollisionEnter(Collision collision)
        {
            OnCollision?.Invoke(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            OnCollision?.Invoke(collision);
        }
    }
}