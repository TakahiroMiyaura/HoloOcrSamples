// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
///     This class is a class that manage objects created by UWP project in Unity.
/// </summary>
public class UWPBridgeService
{
    private List<IUWPBridgeService> _serviceCollection;

    private static readonly object LockObject = new Object();

    private static UWPBridgeService _instance;

    public static UWPBridgeService Instance
    {
        get
        {
            if (_instance == null)
                lock (LockObject)
                {
                    if (_instance == null)
                        _instance = new UWPBridgeService();
                }

            return _instance;
        }
    }

    public void AddService<T>(IUWPBridgeService service) where T : IUWPBridgeService
    {
        lock (LockObject)
        {
            _serviceCollection.Add(service);
        }
    }

    private UWPBridgeService()
    {
        _serviceCollection = new List<IUWPBridgeService>();
    }

    /// <summary>
    ///     Acquires the specified object from the registered objects.
    /// </summary>
    /// <typeparam name="T">Type of the object to be acquired</typeparam>
    /// <returns>object</returns>
    public T GetService<T>() where T : IUWPBridgeService
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