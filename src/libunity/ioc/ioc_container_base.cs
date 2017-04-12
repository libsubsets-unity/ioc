using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libunity.ioc {
  public interface ioc_container_base {
    void register(object instance);
  }
}
