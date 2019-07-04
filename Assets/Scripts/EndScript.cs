using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public void restartgame()
    {
        SceneManager.LoadScene("WorldGen");
    }

    public void exittosurvey()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSc893lsZKRh8H-2YyBl92bI4i0E2UiZ8-HpUzf0hVQVwIRyUw/viewform?usp=sf_link");
    }
}