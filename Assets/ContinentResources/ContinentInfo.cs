using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewContinentInfo", menuName = "Continent Info", order = 0)]
public class ContinentInfo : ScriptableObject
{
    public string continentName;
    public string description;
    public Sprite image;
}

