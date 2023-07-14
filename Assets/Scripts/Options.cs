using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer audiomixer;

    public GameObject optionsUI;

    //pressed escape = game is paused
    public static bool pressedEscape = false;

    public void Awake()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pressedEscape)
            {
                //unfreeze the game and dont show menu gui
                Resume();
            }
            else
            {
                //freeze the game and show gui
                Pause();
            }
        }
    }

     public void Resume()
    {
        optionsUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        pressedEscape = false;
    }

     public void Pause()
    {
            optionsUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
            pressedEscape = true;
     }
    
    //control volum slider
    public void Volume(float volume)
    {
        audiomixer.SetFloat("Volume", volume);
    }

    //actually it is restart level but I left the name of the function as is
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

}