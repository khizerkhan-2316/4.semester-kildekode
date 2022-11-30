using MusicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreMVC.Controllers
{
    public class Exercise01Controller : Controller
    {
        // GET: Exercise01
        public ActionResult Index()
        {
            Book book = new Book("A Hard Day's Write: The stories behind every beatles song", 150, "Book.jpeg", "Steve turner", "It books(2005)",2005, "2323223123");
            MusicCD musicCD = new MusicCD("Abbey Road (Remastered)", 128, "Album.jpeg", "Beatles", "label beatles", 2550);


            musicCD.AddTrack("Come Together");
            musicCD.AddTrack("Something");
            musicCD.AddTrack("Maxwells's Silver Hammer");
            musicCD.AddTrack("Oh! Darling");
            musicCD.AddTrack("Octopus Garden");
            musicCD.AddTrack("I want you (she's so heavy)");
            musicCD.AddTrack("Sun King");
            musicCD.AddTrack("The End");
            musicCD.AddTrack("Polytheme Pam");
            musicCD.AddTrack("Because");
            musicCD.AddTrack("Her Majesty");


            musicCD.AddTrack(new Track("Come Together", "00:02:28"));
            musicCD.AddTrack(new Track("Something", "00:02:28"));
            musicCD.AddTrack(new Track("Maxwells's Silver Hammer", "00:02:28"));
            musicCD.AddTrack(new Track("Oh! Darling", "00:02:28"));
            musicCD.AddTrack(new Track("Octopus Garden", "00:02:28"));
            musicCD.AddTrack(new Track("I want you (she's so heavy)", "00:02:28"));
            musicCD.AddTrack(new Track("Sun King", "00:02:28"));
            musicCD.AddTrack(new Track("Polytheme Pam", "00:02:28"));
            musicCD.AddTrack(new Track("Because", "00:02:28"));
            musicCD.AddTrack(new Track("Her Majesty", "00:02:28"));
            musicCD.AddTrack(new Track("Yesterdays Worries", "00:02:28"));


            ViewBag.Book = book;
            ViewBag.MusicCD = musicCD;


            Book book1 = new Book("A Hard Day's Write: The stories behind every beatles song", 150, "Book.jpeg", "Steve turner", "It books(2005)", 2005, "2323223123");
            MusicCD musicCD1 = new MusicCD("Abbey Road (Remastered)", 128, "Album.jpeg", "Beatles", "label beatles", 2550);


            musicCD1.AddTrack("Come Together");
            musicCD1.AddTrack("Something");
            musicCD1.AddTrack("Maxwells's Silver Hammer");
            musicCD1.AddTrack("Oh! Darling");
            musicCD1.AddTrack("Octopus Garden");
            musicCD1.AddTrack("I want you (she's so heavy)");
            musicCD1.AddTrack("Sun King");
            musicCD1.AddTrack("The End");
            musicCD1.AddTrack("Polytheme Pam");
            musicCD1.AddTrack("Because");
            musicCD1.AddTrack("Her Majesty");


            musicCD1.AddTrack(new Track("Come Together", "00:02:28"));
            musicCD1.AddTrack(new Track("Something", "00:02:28"));
            musicCD1.AddTrack(new Track("Maxwells's Silver Hammer", "00:02:28"));
            musicCD1.AddTrack(new Track("Oh! Darling", "00:02:28"));
            musicCD1.AddTrack(new Track("Octopus Garden", "00:02:28"));
            musicCD1.AddTrack(new Track("I want you (she's so heavy)", "00:02:28"));
            musicCD1.AddTrack(new Track("Sun King", "00:02:28"));
            musicCD1.AddTrack(new Track("Polytheme Pam", "00:02:28"));
            musicCD1.AddTrack(new Track("Because", "00:02:28"));
            musicCD1.AddTrack(new Track("Her Majesty", "00:02:28"));
            musicCD1.AddTrack(new Track("Yesterdays Worries", "00:02:28"));

            ViewBag.Book1 = book1;
            ViewBag.MusicCD1 = musicCD1;


            return View();
        }
    }
}