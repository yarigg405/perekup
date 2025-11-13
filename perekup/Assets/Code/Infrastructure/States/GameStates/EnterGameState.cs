using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class EnterGameState : GameState
    {
        private readonly IStateMachine _stateMachine;


        public EnterGameState(
            IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {           
            PlacePlayer();
          //  AudioManager.Instance.PlayMusic("music");
            _stateMachine.Enter<GameLoopState>();
        }

        private void PlacePlayer()
        {
            
        }
    }
}
