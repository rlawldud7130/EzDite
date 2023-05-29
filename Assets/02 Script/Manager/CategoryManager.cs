using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryManager : MonoBehaviour
{
    public string nextStageName;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("2. Main");
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene("2. Main");
    }

    public void Next_Stage()
    {
        SceneManager.LoadScene(nextStageName);
    }
}
