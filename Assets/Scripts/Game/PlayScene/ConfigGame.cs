using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class ColorPen
    {

        public bool isActive;
        public enumColor color;
        public Vector2 position;
        public float rotation;
        public Vector2 size;
        public Direction direction;
        public int key;
    }

    [CreateAssetMenu(fileName = "level", menuName = "Scriptable Objects/Level", order = 1)]
    public class ConfigGame : ScriptableObject
    {
        // level stats
        public int index;
        public Sprite shape;
        public Sprite lineShape;
        public Sprite answerShape;
        public string[] keyAnswers;
        public int numberColor;
        public List<ColorPen> colorPens;

    }

}