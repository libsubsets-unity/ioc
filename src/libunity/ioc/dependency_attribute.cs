using System;

namespace libunity.ioc {
  [AttributeUsage(AttributeTargets.Field)]
  public class dependency_attribute : Attribute {
    public dependency_attribute() {
    }
  }
}