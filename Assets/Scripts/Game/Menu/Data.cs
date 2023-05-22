using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int level { get; set; }
    private void Start()
    {
        DontDestroyOnLoad(gameObject); 
    }
}
