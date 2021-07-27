using System;
using UnityEngine;

namespace RecyclerView
{
    public class ViewCalculator
    {
        public float ScrollRectHeight { get; set; }

        public float GridViewHeight { get; set; }
        public int GridsSpawnAmount { get;private set; }
        public int TotalItemAmount { get; set; }

        public void Calculate()
        {
            var result = 0;
            if (GridViewHeight != 0)
            {
                result =(int)Mathf.Round(ScrollRectHeight / GridViewHeight);

                if (ScrollRectHeight % GridViewHeight != 0)
                {
                    result += 1;
                }

                if (result > TotalItemAmount)
                {
                    result = TotalItemAmount;
                }
            }
            GridsSpawnAmount = result;
        }
    }
}