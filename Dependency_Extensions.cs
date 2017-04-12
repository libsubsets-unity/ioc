using System;
using libunity.ioc;

public static class Dependency_Extensions {
  private static dependency_container injector = null;

  public static void set_container(dependency_container container) {
    injector = container;
  }

  public static void register(this object that, object instance) {
    injector.register(instance);
  }

  public static void inject(this object that) {
    injector.injection(that);
  }

  public static T resolve<T>(this object that) {
    return injector.resolve<T>();
  }
}
