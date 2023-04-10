using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScript : MonoBehaviour
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
            SceneManager.LoadScene("MainScreen");
            Time.timeScale = 1;
        }
    }
}
