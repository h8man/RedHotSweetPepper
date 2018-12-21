using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private bool stop;
    private TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }
    public void Stop()
    {
        stop = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            score.text = "Score:" + (int)(Time.timeSinceLevelLoad * 10);
        }
    }
}
