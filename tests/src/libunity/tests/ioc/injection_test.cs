using System.Collections.Generic;
using libunity.test;
using libunity.ioc;

namespace libunity.tests.ioc {
  class injection_test: test_case {
    class service {
    }

    class test_object {
      public service get_service() {
        return service;
      }

      [dependency]
      private service service = null;
    }

    public void test_injection() {
      test_object obj = new test_object();
      assert_true(obj.get_service() == null);
      container.injection(obj);
      assert_false(obj.get_service() == null);
    }

    override protected void set_up() {
      service service = new service();
      container = new dependency_container();
      container.register(service);
    }

    override protected void tear_down() {
      container.clear();
    }

    private dependency_container container;

    override public List<test_case> get_tests() {
      List<test_case> result = new List<test_case>();
      result.Add(create_test_case(typeof(injection_test), "test_injection"));
      return result;
    }
  }
}
