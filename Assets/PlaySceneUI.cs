using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneUI : MonoBehaviour
{ 
public void Play()
    {
        PlayerVariables.isPlaying = true;
      
    }


    public void QuitScene()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
