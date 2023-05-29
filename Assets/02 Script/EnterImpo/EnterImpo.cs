using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnterImpo : MonoBehaviour
{
    public GameObject impo;
    public GameObject goal;

    public Text text;
    public InputField input;
    public Text bmi;
    public Text bmiResult;
    public Image bmiResultBox;
    public InputField goalImpo1;
    public InputField goalImpo2;

    private int page = 0;
    private string[] textList = new string[3] { "나이를 입력하세요.", "오늘의 키를 입력하세요.", "오늘의 몸무게를 입력하세요." };
    private string[] inputFieldTextList = new string[3] { "00살", "00cm", "00kg" };
    private (string, Color32)[] bmiImpo = new (string, Color32)[4] { ("저체중", new Color32(241, 255, 131, 255)), ("정상", new Color32(131, 255, 141, 255)), ("과체중", new Color32(255, 231, 131, 255)), ("비만", new Color32(255, 131, 131, 255)) };

    private void Start()
    {
        impo.SetActive(true);
        goal.SetActive(false);

        if(EzDite.ImpoManager.Instance.age == 0)
        {
            page = 0;
            SetText();
        }
        else
        {
            page = 1;
            SetText();
        }
    }

    public void ClickButton()
    {
        if (input.text == null)
            return;

        if (page == 1)
        {
            EzDite.ImpoManager.Instance.height = int.Parse(input.text);
        }
        else if(page == 2)
        {
            EzDite.ImpoManager.Instance.weight = int.Parse(input.text);
            EzDite.ImpoManager.Instance.bmi = EzDite.ImpoManager.Instance.weight / Mathf.Pow(EzDite.ImpoManager.Instance.height / 100, 2);
            if (EzDite.ImpoManager.Instance.goal != (0, 0.0f))
            {
                SceneManager.LoadScene("2. Main");
            }
            else
            {
                SetGoal();
            }
        }
        else if(page == 3)
        {
            if (goalImpo1.text != null && goalImpo2.text != null)
            {
                EzDite.ImpoManager.Instance.goal = (int.Parse(goalImpo2.text), float.Parse(goalImpo1.text));
                SceneManager.LoadScene("2. Main");
            }
        }

        page++;
        if(page <= 2)
            SetText();
    }

    private void SetGoal()
    {
        impo.SetActive(false);
        goal.SetActive(true);

        float bminum = Mathf.Floor(EzDite.ImpoManager.Instance.bmi * 10) / 10;
        int bmiSet = bminum < 20 ? 0 : (bminum <= 24 ? 1 : (bminum <= 29 ? 2 : 3));
        bmi.text = "나의 Bmi: " + bminum.ToString();
        bmiResult.text = bmiImpo[bmiSet].Item1;
        bmiResultBox.color = bmiImpo[bmiSet].Item2;
    }

    private void SetText()
    { 
        text.text = textList[page];
        input.text = string.Empty;
        input.placeholder.GetComponent<Text>().text = inputFieldTextList[page];
    }
}
