using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] Menu menu;
        [SerializeField] MenuView menuView;
        [SerializeField] Button btnBack;
        private void Awake()
        {
            
            btnBack.onClick.AddListener(Back);
            menu.SetAction(LoadingScene);
        }

        public void LoadingScene(int i)
        {
            GameObject paramObject = new GameObject(nameof(Data));
            paramObject.tag = Constans.ParamsTag;
            Data data = paramObject.AddComponent<Data>();
            data.level = i;
            SceneManager.LoadScene(Constans.PlayScene);
        }
        private void Back()
        {
            StartCoroutine(ChangeScene(Constans.MainScene));
        }
        private IEnumerator ChangeScene(string nameScene)
        {
            menuView.CloseScene();
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene(nameScene);
        }

    }
}
