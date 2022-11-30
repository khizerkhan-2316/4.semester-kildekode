using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreMVC.Models
{
    public class Track
    {

        public string Title;
        public string Composer;
        public string Length;

        public Track(string title, string length)
        {
            Title = title;
            Length = length;
        }   
    }
}