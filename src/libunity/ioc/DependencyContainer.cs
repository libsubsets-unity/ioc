using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace LibUnity.IOC {
  
  /* 
   * \class DependencyContainer
   *    
   * \brief dependency injection conatiner system class
   * \author Lee, Hyeon-gi
   */
  public class DependencyContainer<T> : IOCContainerBase, ServiceLocatorBase,
    DependencyInjectorBase where T : Attribute {
    
    /** 
     *  Register dependency instance
     *  
     *  \param dep instance
     */
    public void Register(object dep) {
      instances.Add(dep.GetType(), dep);
    }
    
    /** 
     * Dependency inject to target GameObject instance
     * 
     * \param go target injection instance
     */
    public void Inject(GameObject go) {
      foreach (var component in go.GetComponents<MonoBehaviour>()) {
        Inject(component);
      }
    }
    
    /** 
     * Dependency inject to target GameObject instance
     * 
     * \param instance injection instance
     */
    public void Inject(object instance) {
      Type type = instance.GetType();
      FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic |
        BindingFlags.Public | BindingFlags.Instance);

      foreach (FieldInfo field in fields) {
        if (Attribute.IsDefined(field, typeof(T))) {
          object dependency = Resolve(field.FieldType);
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
    public U Resolve<U>() {
      return (U)Resolve(typeof(U));
    }

    /** 
     * Find service instance specified type
     * 
     * \return service instance
     */
    public object Resolve(Type type) {
      return instances.Contains(type) ? instances[type] : null;
    }

    private Hashtable instances = new Hashtable();
  }
}