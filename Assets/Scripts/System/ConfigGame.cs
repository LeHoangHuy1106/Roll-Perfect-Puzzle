using System.Collections.Generic;
using UnityEngine;


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
[System.Serializable]
public class ConfigGame
{
    // level stats
    public int index;
    public bool block;
    public Sprite shape;
    public Sprite lineShape;
    public string[] keyAnswers;
    public List<ColorPen> colorPens;

}
