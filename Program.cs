using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var NameAndAge = Artists.Where(art => art.Hometown == "Mount Vernon").ToList();
            Console.WriteLine("Mt. Vernon artist name and age: " + NameAndAge[0].RealName + " " + NameAndAge[0].Age);
            //Who is the youngest artist in our collection of artists?
            int minAge = Artists.Min(b => b.Age);
            var youngest = Artists.Where(art => art.Age == minAge).ToList();
            Console.WriteLine("Youngest artist Name and Age: " + youngest[0].RealName + " " + youngest[0].Age);
            
            //Display all artists with 'William' somewhere in their real name
            List<Artist> Williams = Artists.Where(art => art.RealName.Contains("William")).ToList();
            foreach(var name in Williams)
            {
                Console.WriteLine("My full name is: " + name.RealName);
            }
            // Display all groups with names less than 8 characters in length.

            List<Group> shortnames = Groups.Where(name => name.GroupName.Length < 8).ToList();
            foreach(var name in shortnames)
            {
                Console.WriteLine("This group's name is shorter than 8 characters: " + name.GroupName);
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> atlanta = Artists.Where(art => art.Hometown == "Atlanta").ToList();
            List<Artist> OldestAtlantans = atlanta.OrderByDescending(person => person.Age).Take(3).ToList();
            foreach(var guy in OldestAtlantans)
            {
                Console.WriteLine("Yo I'm an atlantan old-head: " + guy.ArtistName);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
