using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScenaMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject menuOpciones;
    
    public void OpenMenuOpciones()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void CloseMenuOpciones()
    {
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EmpearJuego()
    {
        SceneManager.LoadScene("DemoScene");
    }
}
