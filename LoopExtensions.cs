using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWAddIn.Entities.Extensions
{
    public static class LoopExtensions
    {
        public static HashSet<Face2> getAdjacentFaces(this Loop2 loop)
        {
            HashSet<Face2> faces = new HashSet<Face2>();
            foreach (Edge edge in loop.GetEdges())
            {
                var adjacentFaces = edge.GetTwoAdjacentFaces2();
                if (adjacentFaces != null)
                {
                    foreach (Face2 f in adjacentFaces)
                    {
                        if (f != null)
                        {
                            faces.Add(f);

                        }
                    }
                }
            }
            return faces;
        }
        public static void selectAllEdges(this Loop2 loop)
        {

            foreach (Edge e in loop.GetEdges())
            {
                e.Select(e, true);
            }
        }

        public static void deSelectAllEdges(this Loop2 loop)
        {

            foreach (Edge e in loop.GetEdges())
            {
                e.DeSelect()
            }
        }
    }
}
