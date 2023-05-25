using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Game
{
    public class View : MonoBehaviour
    {
        [SerializeField] private GameObject objectGreat;
        [SerializeField] private GameObject objectError;
        [SerializeField] private GameObject objectFireWorks;
        [SerializeField] private GameObject openLoadingScene;
        [SerializeField] private GameObject closeLoadingScene;

        [SerializeField] private Image shape;
        [SerializeField] private Image lineShape;
        [SerializeField] private Image RepareShape;

        [SerializeField] private GameObject panelShowWin;
        [SerializeField] private Image imagePanelShape;
        [SerializeField] private Image imagePanelMiniShape;
        [SerializeField] private TextMeshProUGUI textLevel;


        private void Awake()
        {
            openLoadingScene.SetActive(false);
            closeLoadingScene.SetActive(false);
            objectError.SetActive(false);
            objectGreat.SetActive(false);
            objectFireWorks.SetActive(false);
            panelShowWin.SetActive(false);
            StartCoroutine(OpenLoadingScene());
        }
        public void SetSpritePanelShape(Sprite spritePanelShape)
        {
            imagePanelShape.sprite = spritePanelShape;
            imagePanelMiniShape.sprite = spritePanelShape;
        }
        public void SetTextLevel(string text)
        {
            textLevel.text = text;
        }
        private IEnumerator OpenLoadingScene()
        {
            openLoadingScene.SetActive(true);
            yield return new WaitForSeconds(1f);
            openLoadingScene.SetActive(false);
        }
        public IEnumerator ShowNotification(bool result)
        {
            yield return new WaitForSeconds(1f);
            if (result)
            {
                objectGreat.SetActive(true);
                yield return new WaitForSeconds(2f);
                objectGreat.SetActive(false);
                StartCoroutine(ShowPanelWin());
            }
            else
            {
                objectError.SetActive(true);
                yield return new WaitForSeconds(2f);
                objectError.SetActive(false);
                ReloadScene(1f);
            }


        }
        private IEnumerator ShowPanelWin()
        {
            panelShowWin.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            objectFireWorks.SetActive(true);
        }

        public void ChangeShape(Sprite sprite)
        {
            shape.sprite = sprite;
            RepareShape.sprite = sprite;
        }
        public void ChangeLineShape(Sprite sprite)
        {
            lineShape.sprite = sprite;
        }
        public void ReloadScene(float time)
        {
            StartCoroutine(Reload(time));
        }
        public IEnumerator Reload(float time)
        {
            closeLoadingScene.SetActive(true);
            yield return new WaitForSeconds(time);
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        public void LoadSceneMenu()
        {
            StartCoroutine(LoadingSceneMenu(1f));
        }
        private IEnumerator LoadingSceneMenu(float time)
        {
            closeLoadingScene.SetActive(true);
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene("MenuScene");
        }
    }
}
