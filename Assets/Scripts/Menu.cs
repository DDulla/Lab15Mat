using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Load2DScene()
    {
        SceneManager.LoadScene("Game2D");
    }

    public void Load3DScene()
    {
        SceneManager.LoadScene("Game3D");
    }
}

