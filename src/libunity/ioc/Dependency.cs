using System;

namespace LibUnity.IOC {
  [AttributeUsage(AttributeTargets.Field)]
  public class Dependency : Attribute {
    public Dependency() {
    }
  }
}