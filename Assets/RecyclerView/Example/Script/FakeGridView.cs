using UnityEngine;
using UnityEngine.UI;

namespace RecyclerView
{
    public class FakeGridView : GridViewAbstract
    {
        public override RectTransform GetRect => rectTransform;

        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            if(rectTransform == null)
            {
                rectTransform = gameObject.AddComponent<RectTransform>();
            }
        }

        public void SetRectSize(Vector3 sizeDelta)
        {
            rectTransform.sizeDelta = sizeDelta;
        }
    }
}
