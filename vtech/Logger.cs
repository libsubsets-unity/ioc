using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour {
  public void debug(string message) {
    Debug.Log("Logger:" + message);
  }
}
