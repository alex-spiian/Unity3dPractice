using UnityEngine;

public static class RayFromCamera
{
    public static RaycastHit? Ray(float rayLenght)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, rayLenght))
        {
            return hitInfo;
        }
        return null;
    }
}
