using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Menu menu;
    private void Awake()
    {
        menu.SetAction(LoadingScene);
    }

    public void LoadingScene(int i)
    {
        GameObject paramObject = new GameObject(nameof(Data));
        paramObject.tag = Constans.ParamsTag;
        Data data = paramObject.AddComponent<Data>();
        data.level = i;
        SceneManager.LoadScene("PlayScene");
    }

}
