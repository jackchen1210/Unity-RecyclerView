using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RecyclerView{

    [RequireComponent(typeof(ScrollRect))]

    public class RecyclerViewManager : MonoBehaviour
    {
        private ScrollRect scrollRect;
        private RectTransform rect;

        public bool IsInit { get; private set; }
        public RectTransform GetRect => rect;
        public GridViewAbstract GridView { get=> gridViewPrefab; set=> gridViewPrefab=value; }
        [SerializeField]private GridViewAbstract gridViewPrefab;
        private IViewModel viewModel;
        private ViewCalculator viewCalculator = new ViewCalculator();

        private void Awake()
        {
            scrollRect = GetComponent<ScrollRect>() ?? throw new NullReferenceException(nameof(scrollRect));
            rect = GetComponent<RectTransform>() ?? throw new NullReferenceException(nameof(rect));
        }
        private void Start()
        {
            this.gridViewPrefab = gridViewPrefab ?? throw new NullReferenceException(nameof(gridViewPrefab));
        }

        public void Init(IViewModel viewModel)
        {
            this.viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

            IsInit = true;

            //1. 建立所需物件
            //2. 初始化所有物件
        }

        public void Create()
        {
            if (!IsInit)
            {
                throw new NotInitException();
            }

            viewCalculator.ScrollRectHeight = rect.sizeDelta.y;
            viewCalculator.GridViewHeight = gridViewPrefab.GetRect.sizeDelta.y;
            viewCalculator.TotalItemAmount = viewModel.GetDatasAmount;
        }

        public int GetGridsSpawnAmount()
        {
            return viewCalculator.GridsSpawnAmount;
        }

    }

    public class NotInitException : UnityException
    {
        public override string Message => "Please Init First";
    }

}
