using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private int MENU_SCENE = 0;
    private int GAME_SCENE = 1;

    public void LoadGameScene()
    {
        LoadScene(GAME_SCENE);
    }

    public void LoadMenuScene()
    {
        LoadScene(MENU_SCENE);
    }

    private void LoadScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
