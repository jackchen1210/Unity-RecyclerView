using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public partial class RecyclerViewPlayTest
    {
        private class FakeGridView : IGridView
        {
            public RectTransform GetRect => rectTransform;

            private GameObject gameObject;
            private RectTransform rectTransform;

            public FakeGridView()
            {
                gameObject = new GameObject();
                rectTransform = gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<Image>();
            }

            public void SetRectSize(Vector3 sizeDelta)
            {
                rectTransform.sizeDelta = sizeDelta;
            }
        }
    }
}
