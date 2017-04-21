using UnityEngine;

namespace LibUnity.IOC {
  public interface DependencyInjectorBase {
    void Inject(object instance);
    void Inject(GameObject go);
  }
}
