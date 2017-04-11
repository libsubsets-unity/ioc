using UnityEngine;
using libunity.ioc;

public class Foo : MonoBehaviour {
  public void Awake() {
    //dependencies.instance.injection(this);
    //dependencies.instance.injection<Logger>(this);
    Service_Locator.injection(this);
  }

  void Update () {
    if (logger != null)
      logger.debug("Update");
  }

  //[dependency_attribute]
  [Service]
  private Logger logger = null;
}
