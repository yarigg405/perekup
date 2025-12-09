/*


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public sealed class UIWindowManager : MonoBehaviour
{
    [Header("Roots by layer")]
    [SerializeField] private Transform _hudRoot;
    [SerializeField] private Transform _defaultRoot;
    [SerializeField] private Transform _modalRoot;
    [SerializeField] private Transform _popupRoot;

    [Header("Windows registry")]
    [SerializeField] private List<WindowEntry> _windows = new();

    private readonly Dictionary<Type, WindowEntry> _registry = new();
    private readonly Dictionary<Type, List<WindowViewBase>> _instances = new();

    // Presenter factory: на будущее под DI
    private readonly Dictionary<Type, Func<WindowViewBase, IWindowPresenter>> _presenterFactories = new();
    private readonly Dictionary<WindowViewBase, IWindowPresenter> _presentersByView = new();

    private void Awake()
    {
        BuildRegistry();
    }

    private void BuildRegistry()
    {
        _registry.Clear();

        foreach (var entry in _windows)
        {
            if (entry.Prefab == null) continue;

            var type = entry.Prefab.GetType();
            if (_registry.ContainsKey(type))
            {
                Debug.LogWarning($"UIWindowManager: duplicate entry for {type.Name}. Using first.");
                continue;
            }

            _registry[type] = entry;
            _instances[type] = new List<WindowViewBase>();
        }
    }

    // Регистрация презентера извне (composition root)
    public void RegisterPresenter<TView>(Func<TView, IWindowPresenter> factory)
        where TView : WindowViewBase
    {
        _presenterFactories[typeof(TView)] = view => factory((TView)view);
    }

    public TView Open<TView>(bool instant = false)
        where TView : WindowViewBase
    {
        var type = typeof(TView);
        if (!_registry.TryGetValue(type, out var entry))
        {
            Debug.LogError($"UIWindowManager: no prefab registered for {type.Name}");
            return null;
        }

        // если singleton и уже есть — просто показать
        if (entry.Singleton)
        {
            var existing = _instances[type].FirstOrDefault(v => v != null);
            if (existing != null)
            {
                existing.Show(instant);
                GetPresenter(existing)?.OnShow();
                return (TView)existing;
            }
        }

        var root = GetRoot(entry.Layer);
        var instance = Instantiate(entry.Prefab, root);
        instance.name = entry.Prefab.name;

        // слой на случай если в префабе другой
        // (в базовом классе _layer SerializeField, но мы подстрахуемся)
        SetLayerIfPossible(instance, entry.Layer);

        _instances[type].Add(instance);

        instance.OnRequestClose += () => Close(instance, instant);

        BindPresenterIfAny(instance);

        instance.Show(instant);
        GetPresenter(instance)?.OnShow();

        return (TView)instance;
    }

    public void Close<TView>(bool instant = false)
        where TView : WindowViewBase
    {
        var type = typeof(TView);
        if (!_instances.TryGetValue(type, out var list)) return;

        // закрываем все инстансы этого типа
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == null) { list.RemoveAt(i); continue; }
            Close(list[i], instant);
        }
    }

    public void Close(WindowViewBase view, bool instant = false)
    {
        if (view == null) return;

        GetPresenter(view)?.OnHide();
        view.Hide(instant);

        DisposePresenter(view);

        var type = view.GetType();
        if (_instances.TryGetValue(type, out var list))
            list.Remove(view);

        Destroy(view.gameObject);
    }

    public void Toggle<TView>(bool instant = false)
        where TView : WindowViewBase
    {
        if (IsOpen<TView>())
            Close<TView>(instant);
        else
            Open<TView>(instant);
    }

    public bool IsOpen<TView>() where TView : WindowViewBase
    {
        var type = typeof(TView);
        return _instances.TryGetValue(type, out var list) && list.Any(v => v != null);
    }

    public void CloseAll(bool keepHud = true, bool instant = false)
    {
        foreach (var pair in _instances.ToArray())
        {
            var type = pair.Key;
            var entry = _registry[type];

            if (keepHud && entry.Layer == UILayer.HUD)
                continue;

            CloseByType(type, instant);
        }
    }

    private void CloseByType(Type type, bool instant)
    {
        if (!_instances.TryGetValue(type, out var list)) return;

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == null) { list.RemoveAt(i); continue; }
            Close(list[i], instant);
        }
    }

    private Transform GetRoot(UILayer layer)
    {
        return layer switch
        {
            UILayer.HUD => _hudRoot != null ? _hudRoot : transform,
            UILayer.Modal => _modalRoot != null ? _modalRoot : transform,
            UILayer.Popup => _popupRoot != null ? _popupRoot : transform,
            _ => _defaultRoot != null ? _defaultRoot : transform
        };
    }

    private void BindPresenterIfAny(WindowViewBase view)
    {
        var type = view.GetType();
        if (_presenterFactories.TryGetValue(type, out var factory))
        {
            var presenter = factory(view);
            _presentersByView[view] = presenter;
            presenter.Initialize();
        }
    }

    private IWindowPresenter GetPresenter(WindowViewBase view)
        => view != null && _presentersByView.TryGetValue(view, out var p) ? p : null;

    private void DisposePresenter(WindowViewBase view)
    {
        if (view == null) return;

        if (_presentersByView.TryGetValue(view, out var presenter))
        {
            presenter.Dispose();
            _presentersByView.Remove(view);
        }
    }

    private void SetLayerIfPossible(WindowViewBase view, UILayer layer)
    {
        // если захочешь — можно в WindowViewBase сделать internal SetLayer(...)
        // тут оставлю пусто, т.к. _layer приватный SerializedField
    }
}



*/