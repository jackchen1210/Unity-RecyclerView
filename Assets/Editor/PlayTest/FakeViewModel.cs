using System.Collections.Generic;
using RecyclerView;

namespace Tests
{
    public partial class RecyclerViewPlayTest
    {
        private class FakeViewModel : ViewModel<FakeData>
        {
            public override IEnumerable<FakeData> GetDatas { get; }

            public FakeViewModel(IEnumerable<FakeData> fakeData)
            {
                GetDatas = fakeData;
            }
        }
    }
}
