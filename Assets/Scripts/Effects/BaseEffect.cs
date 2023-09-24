using UnityEngine;
namespace Effects
{
    public abstract class BaseEffect : MonoBehaviour
    {
        public abstract void StartEffect(Transform spawnPosition = null);
        public abstract void StopEffect();
    }
}
