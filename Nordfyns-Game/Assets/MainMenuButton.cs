using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public int chapterSelected;
    public GameObject startMenu;
    public GameObject optionsMenu;

    // This method is called when the "Play Game" button is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("OutDoor");
    }

    // This method is called when a chapter is selected
    public void ChapterSelect()
    {
        GameManager.Instance.bossesDefeated = chapterSelected;
        PlayGame();
    }

    // This method is called when the chapter selection menu should be shown
    public void SelectChapterMenu()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackButton()
    {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
       
}
