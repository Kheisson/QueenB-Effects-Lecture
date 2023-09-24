using UnityEngine;
namespace Collisions
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class CarCollisionDetection : MonoBehaviour
    {
    #region --- Inspector ---

        [SerializeField] private bool detectCollisions;
        
    #endregion
        
    #region --- Events ---

        public delegate void CollisionEventHandler(string gameObjectName, int layer);
        public static event CollisionEventHandler OnCarCollisionExit;
        public static event CollisionEventHandler OnCarCollisionEnter;

    #endregion

    #region --- Unity Events ---

        private void OnTriggerEnter(Collider other)
        {
            if (!detectCollisions) return;
            
            var otherGameObject = other.gameObject;
            OnCarCollisionEnter?.Invoke(otherGameObject.name, otherGameObject.layer);
            Debug.Log("TriggerEnter " + otherGameObject.name + " " + otherGameObject.layer);
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (!detectCollisions) return;

            var otherGameObject = other.gameObject;
            OnCarCollisionExit?.Invoke(otherGameObject.name, otherGameObject.layer);
            Debug.Log("TriggerExit " + otherGameObject.name + " " + otherGameObject.layer);
        }

    #endregion
    }
}

