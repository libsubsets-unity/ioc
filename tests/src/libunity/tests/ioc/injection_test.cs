using System.Collections.Generic;
using LibUnity.Test;
using libunity.ioc;

namespace LibUnity.Tests.ioc {
  class injection_test: test_case {
    class test_service {
    }

    class test_object {
      public bool is_injected() {
        return service != null ? true : false;
      }

      [dependency]
      private test_service service = null;
    }

    public void test_injection() {
      test_object obj = new test_object();
      assert_false(obj.is_injected());
      container.inject(obj);
      assert_true(obj.is_injected());
    }

    override protected void set_up() {
      container = new dependency_container<dependency>();
      container.register(new test_service());
    }

    override protected void tear_down() {
    }

    private dependency_container<dependency> container;

    override public List<test_case> get_tests() {
      List<test_case> result = new List<test_case>();
      result.Add(create_test_case(typeof(injection_test), "test_injection"));
      return result;
    }
  }
}
