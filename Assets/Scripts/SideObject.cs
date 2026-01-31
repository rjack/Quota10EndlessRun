using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SideObject : MonoBehaviour
{
   public List<SegmentGraphics> graphics;
}

[Serializable]
public class SegmentGraphics
{
   public GraphicType graphicType;
   [FormerlySerializedAs("gameObject")] public GameObject gO;
}

public enum GraphicType
{
   COL_CIRCLE_THIN,
   COL_CIRCLE_3WAY,
   COL_SQUARE,
   COL_MEDIEVAL,
   COL_SQUARE_BLOCKS
}