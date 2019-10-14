using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UtilityEditor : EditorWindow {
    [MenuItem("Play/PlayStartScene %h")]
    public static void PlayStartScene() {
        if (EditorSceneManager.GetActiveScene().isDirty) {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }

        EditorSceneManager.OpenScene("Assets/Scenes/IntroScene.unity");
        EditorApplication.isPlaying = true;
    }
}
