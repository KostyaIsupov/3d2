using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public string sceneName;

    public GameObject winPanel;
    public Sprite Star_Hasnt;
    public Sprite Star_Has;
    public Image[] stars = new Image[3];
    public Text levelTimeText;
    public Text panelTimeText;
    public Text panelCoinsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winPanel.SetActive(true);
            MoveScript moveScript = collision.gameObject.GetComponent<MoveScript>();
            Time.timeScale = 0f;
            int coinsCount = Convert.ToInt32(moveScript.coinsCount.text);
            panelTimeText.text = levelTimeText.text;
            panelCoinsText.text = moveScript.coinsCount.text;
            if (coinsCount >= moveScript.allCoins / 2)
            {
                stars[1].sprite = Star_Has;
            }
            if (coinsCount == moveScript.allCoins)
            {
                stars[2].sprite = Star_Has;
            }
        }
    }
}
