using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using RecyclerView;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using System.Linq;

namespace Tests
{
    public partial class RecyclerViewPlayTest
    {

        [OneTimeSetUp]
        public void RecyclerView_CreateObject()
        {
        }

        [UnityTest]
        public IEnumerator RecyclerView_IsExist_ReturnTrue()
        {
            CreateManager();
            yield return new WaitForSeconds(0.1f);
            var recyclerView = GameObject.FindObjectOfType<RecyclerViewManager>();
            Assert.NotNull(recyclerView);
        }

        private RecyclerViewManager CreateManager()
        {

           var gameobject = new GameObject();
            gameobject.AddComponent<ScrollRect>();
            var mgr = gameobject.AddComponent<RecyclerViewManager>();
            mgr.GridView = new GameObject().AddComponent<FakeGridView>();
            return mgr;
        }

        [UnityTest]
        public IEnumerator RecyclerView_Init_Success()
        {
            yield return null;
            var mgr = CreateManager();
                mgr.Init(new FakeViewModel(CreateFakeDatas(0)));
            Assert.IsTrue(mgr.IsInit);
        }

        [UnityTest]
        public IEnumerator RecyclerView_NoInitAndCreate_throw_Exception()
        {
            yield return null;
            var mgr = CreateManager();
            Assert.Catch<NotInitException>(()=> {
                mgr.Create();
            });
        }
        [UnityTest]
        public IEnumerator RecyclerView_NoInitArgs_throw_Exception()
        {
            yield return null;
            var mgr = CreateManager();
            Assert.Catch<ArgumentException>(() => {
                mgr.Init(null);
            });
        }

        [UnityTest]
        public IEnumerator RecyclerView_InitAndCreate_Return_Expect_Grid_Object_Amount_In_Verticle_Mode()
        {
            yield return null;
            var amount = 10;
            var gridSizeDelta = new Vector2(100,100);
            var fakeModel = new FakeViewModel(CreateFakeDatas(amount));
            var mgr = CreateManager();
            var mgrRect = mgr.GetRect;
            var viewCalculator = new ViewCalculator();
            viewCalculator.ScrollRectHeight = mgrRect.sizeDelta.y;
            viewCalculator.GridViewHeight = gridSizeDelta.y;
            viewCalculator.TotalItemAmount = amount;

            mgr.Init(fakeModel);
            mgr.Create();
            Assert.AreEqual(viewCalculator.GridsSpawnAmount, mgr.GetGridsSpawnAmount());
        }

        private IEnumerable<FakeData> CreateFakeDatas(int amount)
        {
            return Enumerable.Range(0, amount).Select(_ => new FakeData());
        }
    }
}
