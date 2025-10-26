using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasCreditos : MonoBehaviour
{
    public void VolverAJugar()
    {
        SceneManager.LoadScene("DemoScene");

    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");

    }
}
