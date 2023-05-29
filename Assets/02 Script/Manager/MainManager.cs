using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Text dday;
    public Text kg;

    private void Start()
    {
        var impo = EzDite.ImpoManager.Instance;
        dday.text = "목표치 까지 " + impo.goal.Item1.ToString() + "일";
        kg.text = (impo.goal.Item2 - impo.weight).ToString() + "kg";
    }

    public void Category1()
    {
        SceneManager.LoadScene("3-1. 식단추천");
    }

    public void Category2()
    {
        SceneManager.LoadScene("4. 식단기록");
    }

    public void Category3()
    {
        SceneManager.LoadScene("5. 운동추천");
    }

    public void Profile()
    {
        SceneManager.LoadScene("6. 프로필");
    }
}
