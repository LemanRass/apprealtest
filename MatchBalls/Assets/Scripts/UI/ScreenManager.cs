using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private static Dictionary<Type, BaseScreen> screens;

    private void Awake()
    {
        screens = new Dictionary<Type, BaseScreen>();
        foreach (var screen in GetComponentsInChildren<BaseScreen>())
            screens.Add(screen.GetType(), screen);
    }

    public static void Init()
    {
        foreach (var screen in screens.Values)
            screen.Init();
    }

    public static T Find<T>() where T : BaseScreen
    {
        return screens[typeof(T)] as T;
    }
}
