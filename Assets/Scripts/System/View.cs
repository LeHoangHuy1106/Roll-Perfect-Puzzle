using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private GameObject objectGreat;
    [SerializeField] private GameObject objectError;

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
    }
}
