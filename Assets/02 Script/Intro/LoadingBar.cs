using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public float loadingTime = 1.0f;

    private float t = 0.0f;

    private void Update()
    {
        LoadingBarUpdate();
    }

    private void LoadingBarUpdate()
    {
        t += 1 / loadingTime * Time.deltaTime;

        if(t >= 1.0f)
        {
            transform.GetComponent<Slider>().value = 1.0f;
            SceneManager.LoadScene("1. EnterImpo");
            return;
        }

        transform.GetComponent<Slider>().value = t;
    }
}