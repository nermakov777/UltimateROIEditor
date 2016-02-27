using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateROIEditor
{
    public class UltimateSet
    {
        public string Label;
        public string ImagePath;
        public string ZonesPath;
        public UltimateSet(string label, string imagePath, string zonesPath)
        {
            Label = label;
            ImagePath = imagePath;
            ZonesPath = zonesPath;
        }
    }
}
