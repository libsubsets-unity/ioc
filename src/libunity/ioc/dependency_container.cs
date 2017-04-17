using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace libunity.ioc {
  
  /* 
   * \class dependency_container
   *    
   * \brief dependency injection conatiner system class
   * \author Lee, Hyeon-gi
   */
  public class dependency_container<T> : ioc_container_base, service_locator_base,
    dependency_injector_base where T : Attribute {
    
    /** 
     *  Register dependency instance
     *  
     *  \param dep instance
     */
    public void register(object dep) {
      instances.Add(dep.GetType(), dep);
    }
    
    /** 
     * Dependency inject to target GameObject instance
     * 
     * \param go target injection instance
     */
    public void inject(GameObject go) {
      foreach (var component in go.GetComponents<MonoBehaviour>()) {
        inject(component);
      }
    }
    
    /** 
     * Dependency inject to target GameObject instance
     * 
     * \param instance injection instance
     */
    public void inject(object instance) {
      Type type = instance.GetType();
      FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic |
        BindingFlags.Public | BindingFlags.Instance);

      foreach (FieldInfo field in fields) {
        if (Attribute.IsDefined(field, typeof(T))) {
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
    
    /** 
     * Find service instance specified type
     * 
     * \return service instance
     */
    public U resolve<U>() {
      return (U)resolve(typeof(U));
    }

    /** 
     * Find service instance specified type
     * 
     * \return service instance
     */
    public object resolve(Type type) {
      return instances.Contains(type) ? instances[type] : null;
    }

    private Hashtable instances = new Hashtable();
  }
}