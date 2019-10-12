using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;
    public static T Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(T)) as T;
            if (instance == null)
            {
                instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }
}

public class Singleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
