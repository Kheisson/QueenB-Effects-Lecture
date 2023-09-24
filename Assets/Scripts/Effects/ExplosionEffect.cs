using UnityEngine;
using UnityEngine.VFX;

namespace Effects
{
    public class ExplosionEffect : BaseEffect
    {
        #region --- Inspector ---

        [SerializeField] private VisualEffect visualEffect;

        #endregion


        #region --- Fields ---

        private VisualEffect _visualEffectInstance;

        #endregion


        #region --- Public methods ---

        public override void StartEffect(Transform spawnPosition = null)
        {
            if (spawnPosition == null)
            {
                Debug.LogWarning($"{nameof(ExplosionEffect)}: Spawn position is null");
                return;
            }

            if (_visualEffectInstance == null)
            {
                _visualEffectInstance = Instantiate(visualEffect, spawnPosition.position, Quaternion.identity);
            }
            else
            {
                _visualEffectInstance.transform.position = spawnPosition.position;
            }

            _visualEffectInstance.Play();
        }
        
        public override void StopEffect() { }

        #endregion
    }
}