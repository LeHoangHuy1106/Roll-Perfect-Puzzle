using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Menu
{
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private Button button;
        private Action<int> OnClick;
        private int id;
        private void Awake()
        {
            button.onClick.AddListener(OnButtonClick);
        }
        public void SetNumberLevel(int id, Action<int> OnClick)
        {
            this.OnClick = OnClick;
            this.id = id;
        }
        public void OnButtonClick()
        {
            OnClick.Invoke(id);
        }
    }
}
