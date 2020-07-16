using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;


//show gameover screen
//display seconds survived
//on space, restart game

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player> ().OnPlayerDeath += onGameover;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(0);
            }
        }
    }

    void onGameover(){
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }

}
