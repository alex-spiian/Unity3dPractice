using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Color _redColor;
    [SerializeField] private Color _greenColor;
    [SerializeField] private Color _defaultColor;

    private List<Renderer> _renderers;
    private void Awake()
    {
        _renderers = GetComponentsInChildren<Renderer>().ToList();

    }

    public void SetColor(bool isCellAvailable)
    {

        if (!isCellAvailable)
        {
            foreach (var rendererOfCurrentTile in _renderers)
            {
                rendererOfCurrentTile.material.color = _redColor;
            }
        }

        else
        {
            foreach (var rendererOfCurrentTile in _renderers)
            {
                rendererOfCurrentTile.material.color = _greenColor;
            }
        }
        
    }
    
    public void ResetColor()
    {
        foreach (var rendererOfCurrentTile in _renderers)
        {
            rendererOfCurrentTile.material.color = _defaultColor;
        }
    }
}