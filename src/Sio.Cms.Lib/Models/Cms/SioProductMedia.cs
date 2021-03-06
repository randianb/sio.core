using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioProductMedia
    {
        public int MediaId { get; set; }
        public int ProductId { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SioMedia SioMedia { get; set; }
        public SioProduct SioProduct { get; set; }
    }
}
