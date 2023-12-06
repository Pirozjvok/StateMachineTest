namespace StateMachineTest
{
    public partial class Form1 : Form
    {
        private StateMachine _stateMachine;

        public Form1()
        {
            _stateMachine = new StateMachine();
            InitializeComponent();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _stateMachine.Release();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _stateMachine.Press();
        }
    }
}