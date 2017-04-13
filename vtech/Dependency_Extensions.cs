using System;
using libunity.ioc;

public static class Dependency_Extensions {
  private static dependency_container container = null;

  public static void set_container(dependency_container instance) {
    container = instance;
  }

  public static void inject(this object that) {
    container.inject(that);
  }

  public static T resolve<T>(this object that) {
    return container.resolve<T>();
  }
}
