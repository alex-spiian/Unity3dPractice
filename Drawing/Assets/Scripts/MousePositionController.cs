using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace DefaultNamespace
{
    public static class MousePositionController
    {
        private static SettingsKeeper _settingsKeeper;

        public static void InitializeSettingsKeeper(SettingsKeeper settingsKeeper)
        {
            _settingsKeeper = settingsKeeper;
        }
        public static UnityEngine.Vector3 GetMousePositionInWorld()
        {
            var mousePosition = Input.mousePosition;
        
            var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 10;

            return worldPosition;
        }
        
        
        public static UnityEngine.Vector3 ControlMousePositionInRange()
        {

            var mousePositionInWorld = MousePositionController.GetMousePositionInWorld();

            if (mousePositionInWorld.x >= _settingsKeeper.RightBorder)
            {
                mousePositionInWorld.x = _settingsKeeper.RightBorder;
            }
        
            if (mousePositionInWorld.x <= _settingsKeeper.LeftBorder)
            {
                mousePositionInWorld.x = _settingsKeeper.LeftBorder;
            }
        
            if (mousePositionInWorld.y <= _settingsKeeper.UpperBorder)
            {
                mousePositionInWorld.y = _settingsKeeper.UpperBorder;
            }
        
            if (mousePositionInWorld.y >= _settingsKeeper.LowerBorder)
            {
                mousePositionInWorld.y = _settingsKeeper.LowerBorder;
            }

            return mousePositionInWorld;
        }
        
        
        public static bool IsMousePositionOutOfRange()
        {

            var mousePositionInWorld = GetMousePositionInWorld();
        
            if (mousePositionInWorld.x > _settingsKeeper.RightBorder || mousePositionInWorld.x < _settingsKeeper.LeftBorder
                                                                     || mousePositionInWorld.y > _settingsKeeper.LowerBorder || mousePositionInWorld.y < _settingsKeeper.UpperBorder)
            {
                return true;
            }
        
            return false;
        }
    }
}