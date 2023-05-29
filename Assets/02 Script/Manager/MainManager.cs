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
        dday.text = "��ǥġ ���� " + impo.goal.Item1.ToString() + "��";
        kg.text = (impo.goal.Item2 - impo.weight).ToString() + "kg";
    }

    public void Category1()
    {
        SceneManager.LoadScene("3-1. �Ĵ���õ");
    }

    public void Category2()
    {
        SceneManager.LoadScene("4. �Ĵܱ��");
    }

    public void Category3()
    {
        SceneManager.LoadScene("5. ���õ");
    }

    public void Profile()
    {
        SceneManager.LoadScene("6. ������");
    }
}
