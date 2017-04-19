using System;

namespace LibUnity.IOC {
  public interface ServiceLocatorBase {
    T Resolve<T>();
    object Resolve(Type type);
  }
}
