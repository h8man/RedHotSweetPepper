using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public GameObject panel;
    public GameObject score;
    public UnityEvent winConditionFire;

    // Start is called before the first frame update
    void Awake()
    {
    }

    public void WinCondition()
    {
        panel.gameObject.SetActive(true);
        score.SendMessage("Stop", true);
        winConditionFire?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Next();
        }
    }

    public void Next()
    {
        var scene = SceneManager.GetActiveScene();
        var indx = (scene.buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(indx);
    }

    public void Reset()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
