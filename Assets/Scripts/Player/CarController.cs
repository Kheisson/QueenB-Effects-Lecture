using UnityEngine;
namespace Player
{
    public class CarController : MonoBehaviour
    {

    #region --- Inspector ---

        [SerializeField] private float moveSpeed = 25f;
        [SerializeField] private float turnSpeed = 2f;

    #endregion
        
    #region --- Properties ---

        public bool IsCarStopped => _carRigidbody.velocity.magnitude < 0.1f;

    #endregion

    #region --- Fields ---

        private Rigidbody _carRigidbody;

    #endregion

    #region --- Unity Methods ---

        private void Start()
        {
            _carRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
        
            MoveAndRotateCar(verticalInput, horizontalInput);
        }

    #endregion

    #region --- Private Methods ---

        private void MoveAndRotateCar(float verticalInput, float horizontalInput)
        {
            var movement = transform.forward * (verticalInput * moveSpeed * Time.fixedDeltaTime);
            var rotation = Quaternion.Euler(Vector3.up * (horizontalInput * turnSpeed));

            _carRigidbody.MovePosition(_carRigidbody.position + movement);
            _carRigidbody.MoveRotation(_carRigidbody.rotation * rotation);
        }

    #endregion
    }
}
