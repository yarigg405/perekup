using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.SaveLoad;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;


namespace Assets.Code.Tempo
{
    internal sealed class InitSceneLoader : MonoBehaviour
    {
        private GameSettingsContainer _settings;

        [Inject]
        private void Construct(GameSettingsContainer settings)
        {
            _settings = settings;
        }

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            if (_settings == null)
                SceneManager.LoadScene(SceneNames.InitScene);
        }
    }
}