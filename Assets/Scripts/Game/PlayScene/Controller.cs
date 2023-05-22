using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public enum enumColor { red, green, blue, pink, yellow }
    public enum Direction { positiveXAxis, negativeXAxis, positiveYAxis, negativeYAxis }

    public class Controller : MonoBehaviour
    {
        [SerializeField] private GameObject objectQuestion;



        [SerializeField] private Transform prepareTranform;
        [SerializeField] private Transform answersTranform;
        [SerializeField] private Transform PensGroupTranform;
        [SerializeField] private Transform ShapeUnavailableTranform;
        [SerializeField] private Transform canvasTranform;

        [SerializeField] private List<Pen> inkColors;
        [SerializeField] private List<GameObject> pens;

        [SerializeField] private Model model;
        [SerializeField] private View view;

        private string[] correctAnswer;
        private string keyAnswer;
        private GameObject objectCorrectAnswer;
        private ConfigGame configGame;
        private int count;
        private int level;


        private void ReadData(int level)
        {
            view.ChangeShape(configGame.shape);
            view.ChangeLineShape(configGame.lineShape);
            
            count = configGame.numberColor;
            for (int i = 0; i < configGame.colorPens.Count; i++)
            {
                if (configGame.colorPens[i].isActive)
                {
                    inkColors[i].SetDirection(configGame.colorPens[i].direction);
                    // postion parameter
                    inkColors[i].transform.localPosition = configGame.colorPens[i].position;
                    // rotation angle parameter
                    inkColors[i].transform.localRotation = Quaternion.Euler(0f, 0f, configGame.colorPens[i].rotation);
                    // size parameter
                    inkColors[i].SetSize(configGame.colorPens[i].size);
                }
                else
                {
                    inkColors[i].transform.SetParent(ShapeUnavailableTranform);
                    inkColors[i] = null;
                    pens[i] = null;
                }
            }



        }

        private void Awake()
        {
            if (GameObject.FindGameObjectWithTag(Constans.ParamsTag)!=null)
            {
                GameObject data = GameObject.FindGameObjectWithTag(Constans.ParamsTag);
                level = data.GetComponent<Data>().level;
                Destroy(data);
            }
            else
            {
                level = Mathf.Clamp(PlayerPrefs.GetInt("level"), 0, model.numberOfScene - 1);
            }
            configGame = model.Level(level);
            correctAnswer = configGame.keyAnswers;
            for (int i = 0; i <= correctAnswer[0].Length - 1; i++)
            {
                inkColors[(int)(correctAnswer[0][i] - '0')].SetParentTranform(ShapeUnavailableTranform);
                inkColors[(int)(correctAnswer[0][i] - '0')].SetParentTranform(answersTranform);
            }
            view.SetTextLevel("Level " + level);
            ReadData(level);


            foreach (GameObject i in pens)
            {
                if (i != null)
                    i.SetActive(false);
            }
            objectCorrectAnswer = Instantiate(objectQuestion);
            objectCorrectAnswer.name = "Object Correct Answer";
            objectCorrectAnswer.transform.SetParent(canvasTranform);
            objectCorrectAnswer.transform.localScale = Vector2.one * 0.5f;
            objectCorrectAnswer.transform.localPosition = new Vector2(0, 700);

            foreach (Pen i in inkColors)
            {
                if (i != null)
                {
                    i.PosTarget = i.transform.localPosition;
                    i.SetPostionPen();
                    i.SetPositionStart();
                    i.SetParentTranform(prepareTranform);

                }
            }
            foreach (GameObject i in pens)
            {
                if (i != null)
                {
                    i.SetActive(true);
                    i.transform.SetParent(PensGroupTranform);
                    i.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
            }
        }

        public void ChooseIndex(int i)
        {
            inkColors[i].Choose(answersTranform);
            keyAnswer = keyAnswer + inkColors[i].GetIndex();
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
                    SaveLevel(configGame.index + 1);
                    return;
                }
            }
            StartCoroutine(view.ShowNotification(false));
        }

        private void SaveLevel(int level)
        {
            if (level > PlayerPrefs.GetInt("level"))
            {
                PlayerPrefs.SetInt("level", level);
            }
        }

    }

}