using System;

namespace LibSubsets.IoC {
  public interface ServiceLocatorBase {
    T Resolve<T>();
    object Resolve(Type type);
  }
}
