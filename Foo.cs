using UnityEngine;
using libunity.ioc;

public class Foo : MonoBehaviour {
  public void Start() {
    this.inject();
  }

  void Update () {
    if (logger != null)
      logger.debug("Update");
  }

  [Inject]
  private Logger logger;
  [Inject]
  private Camera camera;
  [Inject]
  private Dependency_Containor container;
}
