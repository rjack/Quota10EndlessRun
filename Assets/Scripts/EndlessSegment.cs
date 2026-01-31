using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EndlessSegment : MonoBehaviour
{
  [Header("Init")]
  [SerializeField] private List<SideObject> objects;
  [SerializeField] private GraphicType type;
  private void Update()
  {
    if (Keyboard.current.kKey.wasPressedThisFrame)
    {
      ActivateObjects(type);
    }
    
  }

  private void ActivateObjects(GraphicType graphicType)
  {
    foreach (var obj in objects)
    {
      foreach (var graph in obj.graphics)
      {
        graph.gameObject.SetActive(graph.graphicType == graphicType);
      }
    }
    
    
  }
}

