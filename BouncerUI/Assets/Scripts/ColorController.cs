using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ColorController
{
    public Color[] AvailableColors;
    public string[] ColorNames;

    private Dictionary<Color, string> _colorNameDictionary = new Dictionary<Color, string>();

    public Color GetRandomColor()
    
    {
        return AvailableColors[Random.Range(0, AvailableColors.Length)];
    }

    public string GetColorName(Color color)
    {
        _colorNameDictionary.TryGetValue(color, out string colorName);

        return colorName;
    }

    public void CreateDictionaryColorName()
    {
        for (int i = 0; i < AvailableColors.Length; i++)
        {
            _colorNameDictionary.Add(AvailableColors[i], ColorNames[i]);
        }
    }


}