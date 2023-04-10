using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWorkaround : MonoBehaviour
{
    public GameObject menuScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 0;

            menuScreen.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
