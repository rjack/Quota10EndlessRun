using System;
using System.Collections.Generic;
using UnityEngine;

public class SideObject : MonoBehaviour
{
   public List<SegmentGraphics> graphics;
}

[Serializable]
public class SegmentGraphics
{
   public GraphicType graphicType;
   public GameObject gameObject;
}

public enum GraphicType
{
   COL_CIRCLE_THIN,
   COL_CIRCLE_3WAY,
   COL_SQUARE,
   COL_MEDIEVAL
}