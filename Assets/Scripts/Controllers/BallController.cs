using UnityEngine;

namespace Controllers
{
    public delegate void CollisionEventHandler(Collision collision);

    public class BallController : MonoBehaviour
    {
        public event CollisionEventHandler OnCollision;

        private void OnCollisionEnter(Collision collision)
        {
            OnCollision?.Invoke(collision);
        }
    }
}
