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
        Application.OpenURL("https://docs.google.com/document/d/1SyO7DjQJscdXMUsuRROa0wt-U3ad5mETM2DFsP9pTvk/edit?usp=sharing");
    }
}