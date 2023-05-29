using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeToIntro : MonoBehaviour
{
    public void StartApp()
    {
        SceneManager.LoadScene("0. Intro 2");
    }
}
