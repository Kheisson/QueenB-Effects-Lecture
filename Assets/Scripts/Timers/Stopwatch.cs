using System;
using UnityEngine;

namespace Timers
{
    public class Stopwatch : ITimer
    {

    #region --- Fields ---

        private float Time { get; set; }
        private bool _isRunning;
        private readonly float _duration;
        private readonly Action _onFinishCallback;

    #endregion

    #region --- Constructor ---

        public Stopwatch(float time ,Action onFinishCallback)
        {
            _duration = time;
            _onFinishCallback = onFinishCallback;
        }

    #endregion

    #region --- Public methods ---

        public void Start()
        {
            Restart();
            Debug.Log("Stopwatch started");
        }
        
        public void Stop()
        {
            Time = _duration;
            _isRunning = false;
            Debug.Log("Stopwatch stopped");
        }
        
        public void Restart()
        {
            Time = _duration;
            _isRunning = true;
            Debug.Log("Stopwatch restarted");
        }

        public void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            Time -= UnityEngine.Time.deltaTime;
            if (Time <= 0)
            {
                StopwatchFinished();
            }
        }

    #endregion

    #region --- Private methods ---

        private void StopwatchFinished()
        {
            Stop();
            _onFinishCallback?.Invoke();
            Debug.Log("Stopwatch finished");
        }

    #endregion
    }
}