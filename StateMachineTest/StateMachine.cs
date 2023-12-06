namespace StateMachineTest
{
    public enum State
    {
        None,
        FirstPress,
        FirstRelease,
        SecondPress
    }

    public class StateMachine
    {
        private System.Threading.Timer _timer;

        private State _state;

        public StateMachine()
        {
            _timer = new(_ => TimeOut());
            _state = State.None;
        }

        public void Press()
        {
            ResetTimer();
            switch (_state)
            {
                case State.None:
                    _state = State.FirstPress;
                    break;
                case State.FirstRelease:
                    _state = State.SecondPress;
                    break;
            }
        }

        public void Release()
        {
            ResetTimer();
            switch (_state)
            {
                case State.FirstPress:
                    _state = State.FirstRelease;
                    break;
                case State.SecondPress:
                    _state = State.None;
                    MessageBox.Show("Double Click!");
                    break;
            }
        }

        private void ResetTimer() => _timer.Change(600, Timeout.Infinite);

        private void TimeOut()
        {
            _timer.Change(-1, Timeout.Infinite);
            _state = State.None;
        }
    }
}
