using UnityEngine;

namespace libunity.ioc {
  public class dependency_setter : MonoBehaviour {
    public void Awake() {
      set_dependencies();
    }

    public void set_dependencies() {
      foreach (var component in GetComponentsInChildren<MonoBehaviour>(true)) {
        dependencies.instance.injection(component);
      }
    }
  }
}
