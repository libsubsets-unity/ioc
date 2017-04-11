using UnityEngine;
using libunity.ioc;

public class Foo : MonoBehaviour {
  public void Awake() {
    Service_Dependency.injection(this);
  }

  void Update () {
    if (logger != null)
      logger.debug("Update");
  }

  [Inject]
  private Logger logger = null;
}
