using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadBtn : SaiMonoBehaviour
{
    // Use string name to load scene
    public void LoadLevelByName(string nameLevelToLoad)
    {
        SceneManager.LoadScene(nameLevelToLoad);
        Time.timeScale = 1.0f;
    }
}
