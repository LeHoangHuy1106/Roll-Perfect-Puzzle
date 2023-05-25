using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Menu
{
    public class MenuView : MonoBehaviour
    {

        [SerializeField] private GameObject openLoadingScene;
        [SerializeField] private GameObject closeLoadingScene;
        private void Awake()
        {
            StartCoroutine(OpenScene());
        }
        private IEnumerator OpenScene()
        {
            openLoadingScene.SetActive(true);
            yield return new WaitForSeconds(1f);
            openLoadingScene.SetActive(false);
        }
        public void CloseScene()
        {
            closeLoadingScene.SetActive(true);
        }

    }
}
