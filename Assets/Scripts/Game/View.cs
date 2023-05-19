using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class View : MonoBehaviour
{
    [SerializeField] private GameObject objectGreat;
    [SerializeField] private GameObject objectError;
    [SerializeField] private Image shape;
    [SerializeField] private Image lineShape;
    [SerializeField] private Image RepareShape;

    public IEnumerator ShowNotification(bool result)
    {
        yield return new WaitForSeconds(1f);
        if (result)
        {
            objectGreat.SetActive(true);
            yield return new WaitForSeconds(1f);
            objectGreat.SetActive(false);
        }
        else
        {
            objectError.SetActive(true);
            yield return new WaitForSeconds(1f);
            objectError.SetActive(false);
        }
        ReloadScene(0.2f);
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
        StartCoroutine(Reload(0.2f));
    }    
    public IEnumerator Reload(float time)
    {
        yield return new WaitForSeconds(time);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
