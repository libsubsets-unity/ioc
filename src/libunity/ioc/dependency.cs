using System;

namespace libunity.ioc {
  [AttributeUsage(AttributeTargets.Field)]
  public class dependency : Attribute {
    public dependency() {
    }
  }
}