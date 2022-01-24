using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string playGameLevel;

    public void PlayGame()
    {
        // Application.LoadLevel (playGameLevel);
        SceneManager.LoadScene("Endless_Run");
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(10f);
       

    }


}

