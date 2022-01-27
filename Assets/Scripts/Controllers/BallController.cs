// Ball controller. Does nothing - just passes events to GameManager.
// Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2022
using UnityEngine;

namespace Controllers
{
    public delegate void CollisionEventHandler(Collision collision);
    public delegate void TriggerEventHandler(Collider other);

    public class BallController : MonoBehaviour
    {
        public event CollisionEventHandler OnCollision;
        public event TriggerEventHandler OnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            OnTrigger?.Invoke(other);            
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnCollision?.Invoke(collision);
        }
    }
}
