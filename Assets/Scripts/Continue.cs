using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            var scene = SceneManager.GetActiveScene();
            var indx = (scene.buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(indx);
        }
    }
}
