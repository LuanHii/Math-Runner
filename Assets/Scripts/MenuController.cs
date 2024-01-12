using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToPlay;
    public Animator mainMenuAnimator;
    public Animator howToPlayAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarCenaGame(string nomeDaCena)
    {
        SceneManager.LoadScene("Game");
    }

     public void CarregarCenaMenu(string nomeDaCena)
    {
        SceneManager.LoadScene("Menu");
    }

    public void PausarJogo()
    {
        Debug.Log("Pausado.");
    }

    public void ComoJogar(){
        mainMenuAnimator.SetTrigger("MainMenuExit");
        howToPlay.SetActive(true);
        howToPlayAnimator.SetTrigger("EnterAnimation");
    }

    public void VoltarMenu(){
        howToPlayAnimator.SetTrigger("ExitAnimation");
        mainMenuAnimator.SetTrigger("MainMenuEnter");

    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
