using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Object {
    private static T instance;

    public static T Instance {
        get {
            if (instance != null)
                return instance;

            // null이면 scene에서 찾아보고
            instance = FindObjectOfType<T>();
            if (instance != null)
                return instance;

            // 그럼에도 없으면 새로 생성한다.
            instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
            DontDestroyOnLoad(instance);

            return instance;
        }
    }
}
