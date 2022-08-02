using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWAddIn.Feature.Visitors
{

    public class FeatureVisitor
    {
        private IFeatureVisitorStrategy strategy;


        public FeatureVisitor(IFeatureVisitorStrategy strategy)
        {
            this.strategy = strategy;
        }

        public static void VisitFeatures(IModelDoc2 doc, IFeatureVisitorStrategy strategy)
        {

            FeatureVisitor visitor = new FeatureVisitor(strategy);
            visitor.Visit(doc.FirstFeature());


        }
        public static void VisitFeatures(Feature firstFeat, IFeatureVisitorStrategy strategy)
        {

            FeatureVisitor visitor = new FeatureVisitor(strategy);
            visitor.Visit(firstFeat);


        }
        private void Visit(Feature feature)
        {
            Feature feature = feature;

            while (feature != null)
            {
                
                strategy.ActOnFeature(feature);
                
                VisitSubFeatures(feature);

                feature = feature.GetNextFeature();

            }
        }


        private void VisitSubFeatures(Feature feature)
        {
            Feature subFeature = feature.GetFirstSubFeature();
            while (subFeature != null)
            {
                strategy.ActOnFeature(subFeature);
                VisitSubFeatures(subFeature);
                subFeature = subFeature.GetNextSubFeature();

            }
        }
    }
}
