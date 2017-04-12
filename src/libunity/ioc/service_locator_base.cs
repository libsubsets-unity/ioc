using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libunity.ioc {
  public interface service_locator_base {
    T resolve<T>();
    object resolve(Type type);
  }
}
