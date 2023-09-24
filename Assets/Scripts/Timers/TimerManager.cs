using System;
using System.Collections.Generic;
using UnityEngine;

namespace Timers
{
    public class TimerManager : MonoBehaviour
    {
    #region --- Singleton ---
        public static TimerManager Instance { get; private set; }

    #endregion

    #region --- Fields ---

        private readonly HashSet<ITimer> _timers = new HashSet<ITimer>();

    #endregion

    #region --- Unity Methods ---

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
        
        private void Update()
        {
            foreach (var timer in _timers)
            {
                timer.Update();
            }
        }

    #endregion

    #region --- Public Methods ---

        public ITimer CreateTimer(float time, Action onFinishCallback)
        {
            var stopwatch = new Stopwatch(time, onFinishCallback);
            AddTimer(stopwatch);
            return stopwatch;
        }

    #endregion

    #region --- Private Methods ---

        private void AddTimer(ITimer timer)
        {
            _timers.Add(timer);
        }

    #endregion
    }
}