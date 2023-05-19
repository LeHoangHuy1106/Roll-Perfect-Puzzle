using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "level", menuName = "Scriptable Objects/Level", order = 1)]
public class LevelScriptableObject : ScriptableObject
{
	public ConfigGame Root;
	public List<ConfigGame> Nodes = new List<ConfigGame>();
}
