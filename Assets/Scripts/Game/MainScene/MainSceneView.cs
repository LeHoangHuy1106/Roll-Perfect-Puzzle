using Extensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace MainScene
{
    public class MainSceneView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textNumberKey;
        [SerializeField] private GameObject openLoadingScene;
        [SerializeField] private GameObject closeLoadingScene;

        private void Awake()
        {
            textNumberKey.ThrowIfNull();
            openLoadingScene.SetActive(false);
            closeLoadingScene.SetActive(false);
            StartCoroutine(OpenScene());
        }
        public void SetTextNumberKey(int i)
        {
            textNumberKey.text = i.ToString();
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
