using System.Collections.Generic;
using System.Linq;

namespace RecyclerView
{
    public abstract class ViewModel<T> : IViewModel
    {
        public virtual int GetDatasAmount => GetDatas.Count();

        public abstract IEnumerable<T> GetDatas { get; }
    }
}