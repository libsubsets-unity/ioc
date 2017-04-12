using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace libunity.ioc {
  public class dependency_container : ioc_container_base, service_locator_base,
    dependency_injector_base {

    public void register(object dep) {
      instances.Add(dep.GetType(), dep);
    }

    public void inject(GameObject go) {
      foreach (var component in go.GetComponents<MonoBehaviour>()) {
        inject(component);
      }
    }

    public void inject(object instance) {
      Type type = instance.GetType();
      FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic |
        BindingFlags.Public | BindingFlags.Instance);

      foreach (FieldInfo field in fields) {
        if (Attribute.IsDefined(field, typeof(dependency))) {
          object dependency = resolve(field.FieldType);
          if (dependency != null) {
            field.SetValue(instance, dependency);
          }
          else {
            throw new Exception(type.FullName + " Can't find dependeny " +
              field.FieldType.FullName);
          }
        }
      }
    }

    public T resolve<T>() {
      return (T)resolve(typeof(T));
    }

    public object resolve(Type type) {
      return instances.Contains(type) ? instances[type] : null;
    }

    private Hashtable instances = new Hashtable();
  }
}