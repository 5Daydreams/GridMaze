using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewSceneTransition", menuName = "CustomScriptables/SceneTransition")]
public class SceneTransition : ScriptableObject
{
    [SerializeField] private string _targetScene;
    [SerializeField] private bool _onlyTransition;
    
    public void ChangeScene()
    {
        if (_onlyTransition)
        {
            if (SceneManager.GetActiveScene().name == _targetScene)
                Debug.LogError("Error: this is a transition-only scene");
        }
        SceneManager.LoadScene(_targetScene);
    }
}
