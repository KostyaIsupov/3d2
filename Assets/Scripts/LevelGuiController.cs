using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGuiController : MonoBehaviour
{
    public Text timerText;
    public float seconds;
    public float minutes;
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void ChangePauseMenuActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        pausePanel.SetActive(active);
    }

    IEnumerator Timer()
    {
        while (true)
        {
            seconds += 1;
            if(seconds >= 60)
            {
                seconds = 0;
                minutes += 1;
            }
            timerText.text = minutes.ToString() + ":" + seconds.ToString();
            yield return new WaitForSeconds(1);
        }
    }
}