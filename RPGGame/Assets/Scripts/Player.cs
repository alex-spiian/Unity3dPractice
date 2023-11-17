using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Outline _outline;
    public bool IsPlayerHighlited;
    private const float WIDTH_OF_OUTLINE_HIGHLITED_PLAYER = 2;

 

    public void HighlightPlayer()
    {
        _outline.OutlineWidth = WIDTH_OF_OUTLINE_HIGHLITED_PLAYER;
        IsPlayerHighlited = true;
    }
}
