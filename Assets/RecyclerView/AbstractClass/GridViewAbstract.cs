using System;
using UnityEngine;

namespace RecyclerView
{
    [DisallowMultipleComponent]
    public abstract class GridViewAbstract : MonoBehaviour
    {
        public abstract RectTransform GetRect { get; }
    }

}
