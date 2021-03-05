using System;
using System.Collections.Generic;
using UberScan.Shared;

namespace UberScan.Models
{
    public class VolumeViewModel{
        public Manga Manga {get;set;}
        public Publisher Publisher {get;set;}
        public Author Author {get;set;}
        public FrTranslator Translator {get;set;}
        public Category Category {get;set;}
        public IEnumerable<Volume> Volumes {get;set;}
    }
}
