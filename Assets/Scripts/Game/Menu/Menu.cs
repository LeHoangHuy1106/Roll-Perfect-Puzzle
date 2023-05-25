using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] int numberOfLevel;
        [SerializeField] GameObject buttonOpen;
        [SerializeField] GameObject buttonClose;
        [SerializeField] Transform parentButton;

        private Action<int> action;

        private int levelCurr = 0;

        public void SetAction(Action<int> action)
        {
            this.action = action;
        }
        private void Awake()
        {

            levelCurr = PlayerPrefs.GetInt("level");

            for (int i = 0; i <= numberOfLevel; i++)
            {


                if (i > levelCurr)
                {

                    GameObject t = Instantiate(buttonClose);
                    t.GetComponent<LevelItem>().SetNumberLevel(i, action);
                    t.transform.SetParent(parentButton);
                    t.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = i.ToString();
                    t.GetComponent<Button>().interactable = false;
                }
                else
                {
                    GameObject t = Instantiate(buttonOpen);
                    t.GetComponent<LevelItem>().SetNumberLevel(i, action);
                    t.transform.SetParent(parentButton);
                    t.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = i.ToString();

                }
            }
        }
    }

}