using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum enumColor { red, blue, green, yellow}

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject objectQuestion;



    [SerializeField] private Transform prepareTranform;
    [SerializeField] private Transform answersTranform;
    [SerializeField] private Transform PensGroupTranform;

    [SerializeField] private Transform canvas;
    [SerializeField] private Pen[] inkColor;
    [SerializeField] private GameObject[] pens;

    [SerializeField] private Model model;
    [SerializeField] private View view;

    private string[] correctAnswer;
    private string keyAnswer;
    private GameObject objectCorrectAnswer;
    private int count;



    private void Awake()
    {
        foreach (GameObject i in pens)
        {
            i.SetActive(false);
        }
        correctAnswer = model.correctAnswer;
        objectCorrectAnswer = Instantiate(objectQuestion);
        objectCorrectAnswer.name = "Object Correct Answer";
        objectCorrectAnswer.transform.SetParent(canvas);
        objectCorrectAnswer.transform.localScale = Vector2.one * 0.5f;
        objectCorrectAnswer.transform.localPosition = new Vector2(0, 600);
        count = inkColor.Length;

        foreach (Pen i in inkColor)
        {
            i.PosTarget = i.transform.localPosition;
            i.SetPositionStart();
            i.SetParentTranform(prepareTranform);
        }
        foreach (GameObject i in pens)
        {
            i.SetActive(true);
            i.transform.SetParent(PensGroupTranform);
            i.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    public void ChooseIndex(int i)
    {
        inkColor[i].Choose(answersTranform);
        keyAnswer = keyAnswer + inkColor[i].GetIndex();
        count--;
        if (count <= 0)
        {
            CheckResult();
        }

    }
    private void CheckResult()
    {
        foreach (string key in correctAnswer)
        {
            if (key.Equals(keyAnswer))
            {
                StartCoroutine(view.ShowNotification(true));
                return;
            }
        }
        StartCoroutine(view.ShowNotification(false));
    }

}
