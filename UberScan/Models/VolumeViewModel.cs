using System;
using System.Collections.Generic;
using UberScan.Shared;

namespace UberScan.Models
{
    public class VolumeViewModel{
        public Manga Manga {get;set;}
        public IEnumerable<Volume> Volumes {get;set;}
    }
}
