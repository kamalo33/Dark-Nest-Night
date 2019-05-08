using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject title;
    public GameObject mainMenu;
    public GameObject options;


	void Start ()
    {

        options.SetActive(false);
	}
	
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        mainMenu.SetActive(false);
        title.SetActive(false);
    }

    public void OptionMenu()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);

    }

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }

    public void LoadGame()
    {

    }

    public void SoundOn()
    {

    }
    public void SoundOff()
    {

    }
    public void Volume()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit game done");
    }


}
