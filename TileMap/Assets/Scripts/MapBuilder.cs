using System;
using System.Numerics;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{

    [SerializeField] private Grid _grid;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _terrainLayerMask;
    [SerializeField] private Vector2Int _mapSize;
    
    private ColorController _colorControllerOfCurrentTile;
    private bool[,] _availableCells;
    private GameObject _currentTile;
    private void Awake()
    {
        _availableCells = new bool[_mapSize.x, _mapSize.y];
        
    }

    public void StartPlacingTile(GameObject tilePrefab)
    {
        if (_currentTile != null)
        {
            Destroy(_currentTile);
        }
        
        _currentTile = Instantiate(tilePrefab);
        _colorControllerOfCurrentTile = _currentTile.GetComponent<ColorController>();
    }

    private void Update()
    {
       
        if (_currentTile != null)
        {
            MoveTile();
        }
    }

    private void MoveTile ()
    {
        
        var hitInfo = GetHitInfo();
        if (hitInfo == null)
        {
            return;
        }
        
        var cellPosition = _grid.WorldToCell(hitInfo.Value.point);
        
        _colorControllerOfCurrentTile.SetColor(IsCellAvailable(cellPosition));
        
        var worldPositionOfCell = _grid.CellToWorld(cellPosition);
        
        worldPositionOfCell.y = _currentTile.transform.localScale.y / 2;
        worldPositionOfCell.x += _currentTile.transform.localScale.x / 2;
        worldPositionOfCell.z += _currentTile.transform.localScale.z / 2;

        _currentTile.transform.position = worldPositionOfCell;
        
        if (Input.GetMouseButtonDown(0) && IsCellAvailable(cellPosition))
        {
            SetTileOnMap(cellPosition);   
        }

    }
    
    private RaycastHit? GetHitInfo()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var hitInfo, 50f, _terrainLayerMask))
        {
            return hitInfo;
        }
        
        return null;
    }
 
    
    private bool IsCellAvailable(Vector3Int index)
    {
        if (index.x >= _availableCells.GetLength(0) || 
            index.z >= _availableCells.GetLength(1) || index.x < 0 || index.z < 0)
        {
            return false;
        }
        
        Debug.Log( "index " + index);

        if (!_availableCells[index.x, index.z])
        {
            return true;
        }

        return false;
    }

    private void SetTileOnMap(Vector3Int index)
    {
        _colorControllerOfCurrentTile.ResetColor();
        _availableCells[index.x, index.z] = true;
        _currentTile = null;
        
    }
}
