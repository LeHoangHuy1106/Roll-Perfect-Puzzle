using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Model : MonoBehaviour
    {
        [SerializeField] public int numberOfScene;
        [SerializeField] private List<ConfigGame> levels;
        public ConfigGame Level(int level) => Instantiate(levels[level]);

    }
}
