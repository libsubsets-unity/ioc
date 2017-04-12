using UnityEngine;

namespace libunity.ioc {
  public interface dependency_injector_base {
    void inject(object instance);
    void inject(GameObject go);
  }
}
