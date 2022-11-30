using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreMVC.Models
{
    public class MusicCD : Product
    {

        public string Artist;
        public string Label;
        public short Released;
        public List<string> Tracks;
        public List<Track> TrackList;


        public MusicCD(string title, decimal price, string imageUrl, string artist, string label, short released) : base(title, price, imageUrl)
        {
            Artist = artist;
            Label = label;
            Released = released;
            Tracks = new List<string>();
            TrackList = new List<Track>();
        }

        public MusicCD(string artist, string title, decimal price, short released): base(title, price)
        {
            this.Artist = artist;
            this.Released = released;
            this.Tracks = new List<string>();
            this.TrackList = new List<Track>();
        }

        public void AddTrack(string track)
        {
            this.Tracks.Add(track);
          
        }

        public void AddTrack(Track track)
        {
            this.TrackList.Add(track);
        }

        public TimeSpan GetPlayingTime()
        {
            TimeSpan time = TimeSpan.Zero;

            TrackList.ForEach((Track track) =>
            {
                TimeSpan timespan = TimeSpan.Parse(track.Length);

                time += timespan;
            });

            return time;
        }
    }
}