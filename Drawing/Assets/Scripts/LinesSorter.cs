using UnityEngine;

namespace DefaultNamespace
{
    public class LinesSorter
    {
        private int _sortingOrder;

        public void SetLineFirstOnScreen(GameObject currentLine)
        {
            var renderer = currentLine.gameObject.GetComponent<Renderer>();

            renderer.sortingOrder = _sortingOrder;
            _sortingOrder++;
        }
    }
}