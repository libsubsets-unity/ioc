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

      [dependency_attribute]
      private service service = null;
    }

    public void test_injection() {
      test_object obj = new test_object();
      assert_true(obj.get_service() == null);
      depend.injection(obj);
      assert_false(obj.get_service() == null);
    }

    override protected void set_up() {
      service service = new service();
      depend.register(service);
    }

    override protected void tear_down() {
      depend.clear_all();
    }

    private dependencies depend = new dependencies();

    override public List<test_case> get_tests() {
      List<test_case> result = new List<test_case>();
      result.Add(create_test_case(typeof(injection_test), "test_injection"));
      return result;
    }
  }
}
