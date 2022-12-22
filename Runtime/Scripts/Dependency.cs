using System;

namespace LibSubsets.IoC {
  [AttributeUsage(AttributeTargets.Field)]
  public class Dependency : Attribute {
    public Dependency() {
    }
  }
}