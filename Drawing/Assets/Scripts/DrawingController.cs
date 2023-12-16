using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class DrawingController : MonoBehaviour
{

    [SerializeField] private Chalk _linePrefab;
    
    [SerializeField] private CursorController _cursorController;

    [SerializeField] private ColorsController _colorsController;

    [SerializeField] private SettingsKeeper _settingsKeeper;

    [SerializeField] private Canvas _parentCanvas;
    
    private Chalk _currentLine;
    private Color _SelectedColor;
    private LinesSorter _linesSorter;
    
    private bool IsChalkSelected;
    private bool IsDrawing;
    
    private readonly List<Chalk> _allLines = new List<Chalk>();
    private void Awake()
    {
        _colorsController.InitializeDictionary();
        MousePositionController.InitializeSettingsKeeper(_settingsKeeper);

        _linesSorter = new LinesSorter();

    }
       
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && !MousePositionController.IsMousePositionOutOfRange() && IsChalkSelected )
        {
            _currentLine = Instantiate(_linePrefab);
            _currentLine.ChangeColor(_SelectedColor);
            
            _currentLine.transform.SetParent(_parentCanvas.transform);
            _linesSorter.SetLineFirstOnScreen(_currentLine.gameObject);
            
            _allLines.Add(_currentLine);
            IsDrawing = true;
        }
   
        if (Input.GetMouseButtonUp(0))
        {
            IsDrawing = false;
        }
   
        if (IsDrawing)
        {
            var mousePositionInWorld = MousePositionController.ControlMousePositionInRange();
            _currentLine.DrawLine(mousePositionInWorld);
        }
    }
    
    
    public void ChooseChalk(string colorName)
    {
        if (!IsChalkSelected)
        {
            _cursorController.InstantiateCursor();
        }
        
        _SelectedColor = _colorsController.GetChosenColor(colorName);

        _cursorController.ChangeColor(_SelectedColor);
        IsChalkSelected = true;
        
    }

    
    public void RemoveAllLines()
    {
        foreach (var line in _allLines)
        {
            if (line != null)
            {
                Destroy(line.gameObject);
            }
        }
    }
    
}
