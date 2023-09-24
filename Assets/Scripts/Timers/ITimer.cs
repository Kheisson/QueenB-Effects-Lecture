namespace Timers
{
    public interface ITimer
    {
        void Start();
        void Stop();
        void Restart();
        void Update();
    }
}