using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                string path = "Prefabs/" + typeof(T).Name;
                GameObject prefabFound = Resources.Load(path) as GameObject;

                if (prefabFound != null)
                {
                    _instance = Instantiate(prefabFound).GetComponent<T>();
                }
                else
                {
                    GameObject gameObject = new GameObject(typeof(T).Name);
                    _instance = gameObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this as T;
        }
        // DontDestroyOnLoad(gameObject);
    }

}
