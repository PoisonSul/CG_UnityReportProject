using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button playButton;
    [SerializeField] SceneAsset targetScene;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(targetScene.name);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
