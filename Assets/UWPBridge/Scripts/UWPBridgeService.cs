// Copyright(c) 2017 Takahiro Miyaura

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
///     This class is a class that manage objects created by UWP project in Unity.
/// </summary>
public class UWPBridgeService : MonoBehaviour
{
    private static List<IUWPBridgeService> _serviceCollection;

    private static readonly object LockObject = new Object();

    public static void AddService<T>(IUWPBridgeService service) where T : IUWPBridgeService
    {
        lock (LockObject)
        {
            if (_serviceCollection == null)
                _serviceCollection = new List<IUWPBridgeService>();
            _serviceCollection.Add(service);
        }
    }

    /// <summary>
    ///     Acquires the specified object from the registered objects.
    /// </summary>
    /// <typeparam name="T">Type of the object to be acquired</typeparam>
    /// <returns>object</returns>
    public static T GetService<T>() where T : IUWPBridgeService
    {
        return _serviceCollection.OfType<T>().FirstOrDefault();
    }

    /// <summary>
    ///     Represents an object that can be registered in <see cref="UWPBridgeService" />.
    /// </summary>
    public interface IUWPBridgeService
    {
    }
}