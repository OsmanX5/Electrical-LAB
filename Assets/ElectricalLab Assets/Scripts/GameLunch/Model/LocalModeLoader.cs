using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalModeLoader : MonoBehaviour
{
    public string GameSceneName;

    public void LoadGameScene()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene(GameSceneName);
	}
}
