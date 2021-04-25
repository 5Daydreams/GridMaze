using _Code.Toolbox.SimpleValues;
using UnityEngine;

namespace _Code.Observer
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private FloatValue _timeRemaining;
        [SerializeField] private VoidEvent _onTimerFinished;
        private bool _isRunning = false;

        private void FixedUpdate()
        {
            if (!_isRunning)
                return;
            _timeRemaining.Value -= Time.deltaTime;

            if (_timeRemaining.Value <= 0)
            {
                _isRunning = false;
                _onTimerFinished.Raise();
            }
        }

        public void StopTimer()
        {
            _isRunning = false;
        }

        public void ResumeTimer()
        {
            _isRunning = true;
        }
    }
}