using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace MainScene
{
    public class MainSceneController : MonoBehaviour
    {

        [SerializeField] private MainSceneView mainSceneView;

        [SerializeField] private Button btnPlayGame;
        [SerializeField] private Button btnBuyKey;
        [SerializeField] private Button btnMenu;


        private int numberKey;
        private int maxLevel;

        private void CheckObjectNull()
        {
            btnBuyKey.ThrowIfNull();
            btnPlayGame.ThrowIfNull();
            btnMenu.ThrowIfNull();
        }
        private void AddEvenButton()
        {
            btnBuyKey.onClick.AddListener(AddKey);
            btnPlayGame.onClick.AddListener(PlayGame);
            btnMenu.onClick.AddListener(SelectLevel);
        }
        private void GetData()
        {
            numberKey = PlayerPrefs.GetInt(Constans.Key);
            maxLevel = PlayerPrefs.GetInt(Constans.MaxLevel);
        }
        private void Awake()
        {
            CheckObjectNull();
            GetData();
            AddEvenButton();
        }

        /*--- UI function ---*/
        private void PlayGame()
        {
            StartCoroutine(ChangeScene(Constans.PlayScene));
        }
        private void SelectLevel()
        {
            StartCoroutine(ChangeScene(Constans.MenuScene));
        }    
        private  IEnumerator ChangeScene(string nameScene)
        {
            mainSceneView.CloseScene();
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene(nameScene);
        }
        private void AddKey()
        {
            numberKey += 1;
            PlayerPrefs.SetInt(Constans.Key, numberKey);
            mainSceneView.SetTextNumberKey(numberKey);
        }






    }
}