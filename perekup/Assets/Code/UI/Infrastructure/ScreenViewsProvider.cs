using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;


namespace Assets.Code.UI.Infrastructure
{
    public sealed class ScreenViewsProvider
    {
        private readonly Dictionary<Type, UIScreenView> _cachedViews = new();

        private const string _prefabsPath = "UI/Screens/";

        public TView GetView<TView>() where TView : UIScreenView
        {
            var type = typeof(TView);
            if (!_cachedViews.ContainsKey(type) || _cachedViews[type] == null)
            {
                _cachedViews[type] = CreateView<TView>();
            }

            return (TView)_cachedViews[type];
        }

        private UIScreenView CreateView<TView>() where TView : UIScreenView
        {
            var type = typeof(TView);
            var prefab = Resources.Load<TView>(_prefabsPath + type.Name);
            var instance = GameObject.Instantiate(prefab);

            return instance;
        }
    }
}
