using System.Collections.Generic;
using LibSubsets.UnitTest;
using LibSubsets.IoC;

namespace LibSubsets.IoC.Test {
  class InjectionTest: TestCase {
    class TestSerivce {
    }

    class TestObject {
      public bool is_injected() {
        return service != null ? true : false;
      }

      [Dependency]
      private TestSerivce service = null;
    }

    [TestMethod]
    public void TestInjection() {
      TestObject obj = new TestObject();
      AssertFalse(obj.is_injected());
      container.Inject(obj);
      AssertTrue(obj.is_injected());
    }

    override protected void SetUp() {
      container = new DependencyContainer<Dependency>();
      container.Register(new TestSerivce());
    }

    override protected void TearDown() {
    }

    private DependencyContainer<Dependency> container;
  }
}
