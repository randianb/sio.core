using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioModuleAttributeValue
    {
        public Guid Id { get; set; }
        public Guid AttributeSetId { get; set; }
        public string Specificulture { get; set; }
        public int DataType { get; set; }
        public string DefaultValue { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }

        public SioModuleAttributeSet SioModuleAttributeSet { get; set; }
    }
}
