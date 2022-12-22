using UnityEngine;

namespace LibSubsets.IoC {
  public interface DependencyInjectorBase {
    void Inject(object instance);
    void Inject(GameObject go);
  }
}
