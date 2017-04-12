using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace libunity.ioc {
  public class dependency_container {
    public void register(object dep) {
      instances.Add(dep.GetType(), dep);
    }

    public void clear() {
      instances.Clear();
    }

    public void injection(GameObject go) {
      foreach (var component in go.GetComponents<MonoBehaviour>()) {
        inject_dependencies(component);
      }
    }

    public void injection(object instance) {
      inject_dependencies(instance);
    }

    public void injection<T>(object instance) {
      Type objType = instance.GetType();
      FieldInfo[] fields = objType.GetFields(BindingFlags.NonPublic | 
        BindingFlags.Public | BindingFlags.Instance);

      foreach (FieldInfo field in fields) {
        if (Attribute.IsDefined(field, typeof(dependency))) {
          object dep = get(field.FieldType);
          if (dep != null && dep.GetType() == typeof(T))
            field.SetValue(instance, dep);
          else
            throw new Exception(objType.FullName + " Can't find dependeny " +
              field.FieldType.FullName);
        }
      }
    }

    private void inject_dependencies(object instance) {
      Type objType = instance.GetType();
      FieldInfo[] fields = objType.GetFields(BindingFlags.NonPublic | 
        BindingFlags.Public | BindingFlags.Instance);

      foreach (FieldInfo field in fields) {
        if (Attribute.IsDefined(field, typeof(dependency))) {
          object dep = get(field.FieldType);
          if (dep != null)
            field.SetValue(instance, dep);
          else
            throw new Exception(objType.FullName + " Can't find dependeny " +
              field.FieldType.FullName);
        }
      }
    }

    public T resolve<T>() {
      object instance = get(typeof(T));
      return instance == null ? default(T) : (T)instance;
    }

    private object get(Type type) {
      if (instances.Contains(type))
        return instances[type];
      return null;
    }

    private Hashtable instances = new Hashtable();
  }
}