using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class ColorsController
    {
        
        [SerializeField] private List<Color> _availableColors;
        [SerializeField] private List<string> _colorsNames;
        
        private Dictionary<string, Color> _colorsAndColorsNames;

        
        public void InitializeDictionary()
        {
            _colorsAndColorsNames = new Dictionary<string, Color>();
            
            for (int i = 0; i < _availableColors.Count; i++)
            {
                _colorsAndColorsNames.Add(_colorsNames[i], _availableColors[i]);
            }
        }

        public Color GetChosenColor(string colorName)
        {
            _colorsAndColorsNames.TryGetValue(colorName, out var color);

            return color;
        }
        
        
        
    }
}