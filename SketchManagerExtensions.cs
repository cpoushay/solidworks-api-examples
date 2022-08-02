using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWAddIn.Sketching.Extensions
{
    public static class SketchManagerExtensions
    {

        public static SketchSegment CreateCircleByRadius(this SketchManager sketchMgr, double[] center, double rad)
        {
            return sketchMgr.CreateCircleByRadius(center[0], center[1], center[2], rad);
        }

        public static SketchSegment CreateLine(this SketchManager sketchMgr, double[] start, double[] end)
        {
            return sketchMgr.CreateLine(start[0], start[1], start[2], end[0], end[1], end[2]);
        }
    }
}
