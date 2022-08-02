using SolidWorks.Interop.sldworks;
using SWAddIn.Visitors.Drawing.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAddIn.Drawing.Visitors
{
    public class DrawingViewVisitor
    {
        DrawingDoc doc;
        IDrawingViewVisitorStrategy stategy;
        public DrawingViewVisitor(DrawingDoc doc, IDrawingViewVisitorStrategy stategy)
        {
            this.doc = doc;
            this.stategy = stategy;
        }
        public void Visit()
        {
            View view = doc.GetFirstView();

            while (view != null)
            {
                stategy.OnView(view);

                view = view.GetNextView();

            }
        }
    }
}
