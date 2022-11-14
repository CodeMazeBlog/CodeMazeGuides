using LinkedList.CustomImplementation;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly CustomLinkedList<int> _customLinkedList = new();

        [TestInitialize]
        public void StartUp()
        {
            _customLinkedList.AddFirst(3);
            _customLinkedList.AddFirst(2);
            _customLinkedList.AddFirst(1);

            _customLinkedList.AddLast(4);
            _customLinkedList.AddLast(5);
            _customLinkedList.AddLast(6);
            _customLinkedList.AddLast(7);
            _customLinkedList.AddLast(8);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _customLinkedList.Clear();
        }

        #region Empty LinkedList
        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenInsertAnElementUsingAddFirstWithValue()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.AddFirst(1);

            Assert.IsTrue(customLinkedList.Any());
            Assert.AreEqual(customLinkedList.Count, 1);
            Assert.AreEqual(customLinkedList.First?.Value, 1);
            Assert.IsNull(customLinkedList.First?.Next);
            Assert.IsNull(customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenInsertAnElementUsingAddFirstWithNode()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.AddFirst(new Node<int>(1));

            Assert.IsTrue(customLinkedList.Any());
            Assert.AreEqual(customLinkedList.Count, 1);
            Assert.AreEqual(customLinkedList.First?.Value, 1);
            Assert.IsNull(customLinkedList.First?.Next);
            Assert.IsNull(customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenInsertAnElementUsingAddLastWithValue()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.AddLast(1);

            Assert.IsTrue(customLinkedList.Any());
            Assert.AreEqual(customLinkedList.Count, 1);
            Assert.AreEqual(customLinkedList.First?.Value, 1);
            Assert.IsNull(customLinkedList.First?.Next);
            Assert.IsNull(customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenInsertAnElementUsingAddLastWithNode()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.AddLast(new Node<int>(1));

            Assert.IsTrue(customLinkedList.Any());
            Assert.AreEqual(customLinkedList.Count, 1);
            Assert.AreEqual(customLinkedList.First?.Value, 1);
            Assert.IsNull(customLinkedList.First?.Next);
            Assert.IsNull(customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenInsertAnElementUsingAddAfterWithValue()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.AddAfter(1, 3);

            Assert.IsTrue(customLinkedList.Any());
            Assert.AreEqual(customLinkedList.Count, 1);
            Assert.AreEqual(customLinkedList.First?.Value, 1);
            Assert.IsNull(customLinkedList.First?.Next);
            Assert.IsNull(customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenInsertAnElementUsingAddAfterWithNode()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.AddAfter(new Node<int>(1), 3);

            Assert.IsTrue(customLinkedList.Any());
            Assert.AreEqual(customLinkedList.Count, 1);
            Assert.AreEqual(customLinkedList.First?.Value, 1);
            Assert.IsNull(customLinkedList.First?.Next);
            Assert.IsNull(customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenInsertAnElementUsingAddBeforeWithValue()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.AddBefore(1, 3);

            Assert.IsTrue(customLinkedList.Any());
            Assert.AreEqual(customLinkedList.Count, 1);
            Assert.AreEqual(customLinkedList.First?.Value, 1);
            Assert.IsNull(customLinkedList.First?.Next);
            Assert.IsNull(customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenInsertAnElementUsingAddBeforeWithNode()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.AddBefore(new Node<int>(1), 3);

            Assert.IsTrue(customLinkedList.Any());
            Assert.AreEqual(customLinkedList.Count, 1);
            Assert.AreEqual(customLinkedList.First?.Value, 1);
            Assert.IsNull(customLinkedList.First?.Next);
            Assert.IsNull(customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenGetTheLastNode()
        {
            var customLinkedList = new CustomLinkedList<int>();

            var node = customLinkedList.GetLastNode();

            Assert.IsNull(node);
            Assert.IsFalse(customLinkedList.Any());
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenFindASpecificValue()
        {
            var customLinkedList = new CustomLinkedList<int>();

            var node = customLinkedList.Find(3);

            Assert.IsNull(node);
            Assert.IsFalse(customLinkedList.Any());
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenRemoveAnElement()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.Remove(3);

            Assert.IsFalse(customLinkedList.Any());
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenRemoveTheFirstElement()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.RemoveFirst();

            Assert.IsFalse(customLinkedList.Any());
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenRemoveTheLastElement()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.RemoveLast();

            Assert.IsFalse(customLinkedList.Any());
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenItIsEmpty_ThenClearTheList()
        {
            var customLinkedList = new CustomLinkedList<int>();

            customLinkedList.Clear();

            Assert.IsFalse(customLinkedList.Any());
        }
        #endregion

        #region FilledLinkedList
        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenInsertAnElementUsingAddFirstValue()
        {
            _customLinkedList.AddFirst(1);

            Assert.IsTrue(_customLinkedList.Any());
            Assert.AreEqual(_customLinkedList.First?.Value, 1);
            Assert.IsNotNull(_customLinkedList.First?.Next);
            Assert.IsNull(_customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenInsertAnElementUsingAddFirstNode()
        {
            _customLinkedList.AddFirst(new Node<int>(1));

            Assert.IsTrue(_customLinkedList.Any());
            Assert.AreEqual(_customLinkedList.First?.Value, 1);
            Assert.IsNotNull(_customLinkedList.First?.Next);
            Assert.IsNull(_customLinkedList.First?.Prev);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenInsertAnElementUsingAddLastWithValue()
        {
            _customLinkedList.AddLast(1);

            Assert.IsTrue(_customLinkedList.Any());
            Assert.AreEqual(_customLinkedList.Last()?.Value, 1);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenInsertAnElementUsingAddLastWithNode()
        {
            _customLinkedList.AddLast(new Node<int>(1));

            Assert.IsTrue(_customLinkedList.Any());
            Assert.AreEqual(_customLinkedList.Last()?.Value, 1);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenInsertAnElementUsingAddAfterWithValue()
        {
            _customLinkedList.AddAfter(1, 3);

            Assert.IsTrue(_customLinkedList.Any());

            var node = _customLinkedList.Find(3);
            Assert.AreEqual(node?.Next?.Value, 1);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenInsertAnElementUsingAddAfterWithNode()
        {
            _customLinkedList.AddAfter(new Node<int>(1), 3);

            Assert.IsTrue(_customLinkedList.Any());

            var node = _customLinkedList.Find(3);
            Assert.AreEqual(node?.Next?.Value, 1);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenInsertAnElementUsingAddBeforeWithValue()
        {
            _customLinkedList.AddBefore(1, 3);

            Assert.IsTrue(_customLinkedList.Any());

            var node = _customLinkedList.Find(3);
            Assert.AreEqual(node?.Prev?.Value, 1);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenInsertAnElementUsingAddBeforeWithNode()
        {
            _customLinkedList.AddBefore(new Node<int>(1), 3);

            Assert.IsTrue(_customLinkedList.Any());

            var node = _customLinkedList.Find(3);
            Assert.AreEqual(node?.Prev?.Value, 1);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenGetTheLastNode()
        {
            _customLinkedList.AddLast(9);

            var node = _customLinkedList.GetLastNode();

            Assert.IsNotNull(node);
            Assert.AreEqual(node.Value, 9);
            Assert.IsTrue(_customLinkedList.Any());
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenFindASpecificValue()
        {
            var node = _customLinkedList.Find(3);

            Assert.IsNotNull(node);
            Assert.IsTrue(_customLinkedList.Any());
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenRemoveAnElement()
        {
            _customLinkedList.Remove(3);

            var node = _customLinkedList.Find(3);

            Assert.IsTrue(_customLinkedList.Any());
            Assert.IsNull(node);

        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenRemoveTheFirstElement()
        {
            var node = _customLinkedList.First;

            _customLinkedList.RemoveFirst();

            Assert.IsTrue(_customLinkedList.Any());
            Assert.AreEqual(_customLinkedList?.First?.Value, node?.Next?.Value);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenRemoveTheLastElement()
        {
            var value = _customLinkedList.Last()?.Prev?.Value;

            _customLinkedList.RemoveLast();

            Assert.IsTrue(_customLinkedList.Any());
            Assert.AreEqual(_customLinkedList?.Last()?.Value, value);
        }

        [TestMethod]
        public void GivenACustomLinkedList_WhenFilled_ThenClearTheList()
        {
            _customLinkedList.Clear();

            Assert.IsFalse(_customLinkedList.Any());
        } 
        #endregion


    }
}
