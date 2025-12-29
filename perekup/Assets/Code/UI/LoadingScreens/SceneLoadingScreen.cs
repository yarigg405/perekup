//using DG.Tweening;
using UnityEngine;


namespace Assets.Code.UI.LoadingScreens
{
    public sealed class SceneLoadingScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        [Header("Animation")]
        [SerializeField] private float _inDuration;
        [SerializeField] private float _outDuration;
        //[SerializeField] private Ease _inEase;
        //[SerializeField] private Ease _outEase;


        public void Show()
        {
           // DOTween.Kill(this);

            _canvasGroup.alpha = 1;
            gameObject.SetActive(true);
            //var seq = DOTween.Sequence(this).SetUpdate(false)
            //    .Append(_canvasGroup.DOFade(1f, _inDuration).SetEase(_inEase));
        }

        public void Hide()
        {
           // DOTween.Kill(this);
            _canvasGroup.alpha = 0;
            gameObject.SetActive(false);

            //var seq = DOTween.Sequence(this).SetUpdate(false)
            //    .Append(_canvasGroup.DOFade(0f, _outDuration).SetEase(_outEase))
            //    .AppendCallback(() => gameObject.SetActive(false));
        }
    }
}
