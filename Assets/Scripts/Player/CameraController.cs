// Certain player controller. Does nothing - just passes events to general
// player controller.
// Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2022
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
