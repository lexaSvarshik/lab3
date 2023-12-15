using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int levelIndex){
        LevelController.ChangeLevelNum(levelIndex);
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
