using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Assets.Code.UI.Infrastructure;
using Assets.Code.UI.Screens.MarketScreen;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class LoadGameState : GamePayloadState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly IScenesLoader _sceneLoader;

        private readonly UIManager _uiManager;

        public LoadGameState(IStateMachine stateMachine,
            IScenesLoader sceneLoader,
            UIManager uiManager)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiManager = uiManager;
        }

        public override void Enter(string sceneName)
        {
            _sceneLoader.LoadScene(sceneName, EnterBattleLoopState);
        }

        private void EnterBattleLoopState()
        {
            _uiManager.OpenScreen<MarketScreen>();

            _stateMachine.Enter<EnterGameState>();
        }
    }
}
