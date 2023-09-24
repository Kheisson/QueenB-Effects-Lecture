using Effects;
using Timers;
using UnityEngine;

namespace Collisions
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class CollisionActor : MonoBehaviour
    {
        #region --- Inspector ---

        [SerializeField] private BaseEffect collisionEffect;
        [SerializeField] private bool useDelay;
        [SerializeField] private float delayTime = 1.5f;
        [SerializeField, Tooltip("0 will disable upward explosion effect")] private float upwardForceMultiplier = 10f;

        #endregion


        #region --- Fields ---

        private ITimer _stopwatch;
        private Rigidbody _rigidbody;
        
        #endregion


        #region --- Unity Events ---

        private void Start()
        {
            if (useDelay)
            {
                _stopwatch = TimerManager.Instance.CreateTimer(delayTime, () =>
                {
                    collisionEffect.StartEffect(transform);
                });
            }
            
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }

            _stopwatch?.Stop();
            Explode();
        }

    #endregion

    #region --- Private Methods ---

        private void Explode()
        {
            if (useDelay)
            {
                _stopwatch.Start();
            }
            else
            {
                collisionEffect.StartEffect(transform);
            }
            
            _rigidbody.AddForce(Vector3.one * upwardForceMultiplier, ForceMode.Impulse);
        }

    #endregion
    }
}