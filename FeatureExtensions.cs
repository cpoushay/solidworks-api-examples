using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWAddIn.Features.Extensions
{

    public static class FeatureExtensions
    {

        public static Boolean IsSplitLine(this Feature feature)
        {
            return feature.GetTypeName().Equals(FeatureTypeNames.SPLIT_LINE);
        }

        public static Boolean IsSketch(this Feature feature)
        {
            return feature.GetTypeName().Equals(FeatureTypeNames.SKETCH);
        }
        public static List<Feature> GetSubFeatures(this Feature feature)
        {
            List<Feature> subFeatures = new List<Feature>();
            Feature subFeature = feature.GetFirstSubFeature();
            while(subFeature != null)
            {
                subFeatures.Add(subFeature);
                subFeature = subFeature.GetNextSubFeature();
            }
            return subFeatures;
        }

        public static void Supress(this Feature feature)
        {
            feature.SetSuppression2(0, 1, "");
        }

        public static void UnSupress(this Feature feature)
        {
            feature.SetSuppression2(2, 1, "");
        }
    }
}
