using Assets.Code.UI.Infrastructure;
using UnityEngine;
using VContainer;


namespace Assets.Code.UI.Setup
{
    internal class UiStarter : MonoBehaviour
    {
        [Inject] private readonly UIManager _uiManager;

        private void Start()
        {
           // _uiManager.
        }
    }
}
