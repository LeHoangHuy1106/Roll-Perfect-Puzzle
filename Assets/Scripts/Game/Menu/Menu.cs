using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] int numberOfLevel;
    [SerializeField] GameObject button;
    [SerializeField] Transform parentButton;

    private Action<int> action;

    private int levelCurr = 0;

    public void SetAction(Action<int> action)
    {
        this.action = action;
    }
    private void Update()
    {
        Debug.Log("levelcurr:" + levelCurr);
    }
    private void Awake()
    {

        levelCurr = PlayerPrefs.GetInt("level");

        for (int i = 0; i <= numberOfLevel; i++)
        {
            GameObject t = Instantiate(button);
            t.GetComponent<LevelItem>().SetNumberLevel(i, action);
            t.transform.SetParent(parentButton);
            t.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = i.ToString();

            if (i > levelCurr)
            {
                t.GetComponent<Button>().interactable = false;
            }
        }





    }
}
