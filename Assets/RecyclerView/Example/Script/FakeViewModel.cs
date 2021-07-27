using System.Collections.Generic;
namespace RecyclerView
{
    public class FakeViewModel : ViewModel<FakeData>
    {
        public override IEnumerable<FakeData> GetDatas { get; }

        public FakeViewModel(IEnumerable<FakeData> fakeData)
        {
            GetDatas = fakeData;
        }
    }
}
