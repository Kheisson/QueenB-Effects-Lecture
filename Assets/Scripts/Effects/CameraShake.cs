using Cinemachine;
using Collisions;
using Player;
using UnityEngine;
namespace Effects
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraShake : BaseEffect
    {
        #region --- Constants ---
        
        private const float SHAKE_INTENSITY = 1f;
        
        #endregion
        
        #region --- Fields ---

        private bool _isOutsideCourseBounds;
        private CinemachineVirtualCamera _virtualCamera;
        private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;
        private CarController _carController;
        
        #endregion


        #region --- Properties ---

        private bool ShouldPlayEffect => !_carController.IsCarStopped && _isOutsideCourseBounds;

        #endregion


        #region --- Unity Methods ---

        private void Awake()
        {
            CarCollisionDetection.OnCarCollisionEnter += HandleCarCollisionEnter;
            CarCollisionDetection.OnCarCollisionExit += HandleCarCollisionExit;
        }

        private void Start()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _virtualCameraNoise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _carController = _virtualCamera.Follow.GetComponent<CarController>();
        }

        private void OnDestroy()
        {
            CarCollisionDetection.OnCarCollisionEnter -= HandleCarCollisionEnter;
            CarCollisionDetection.OnCarCollisionExit -= HandleCarCollisionExit;
        }

        private void LateUpdate()
        {
            if (ShouldPlayEffect)
            {
                StartEffect();
            }
            else
            {
                StopEffect();
            }
        }

        #endregion


        #region --- Private Methods ---

        private void HandleCarCollisionEnter(string gameObjectName, int layer)
        {
            _isOutsideCourseBounds = false;
        }
    
        private void HandleCarCollisionExit(string gameObjectName, int layer)
        {
            _isOutsideCourseBounds = true;
        }
    
        private void StartEffect()
        {
            _virtualCameraNoise.m_AmplitudeGain = SHAKE_INTENSITY;
        }

        #endregion


        #region --- Public Methods ---

        public override void StartEffect(Transform spawnPosition = null) { }
    
        public override void StopEffect()
        {
            _virtualCameraNoise.m_AmplitudeGain = 0f;
        }

        #endregion
    }
}
