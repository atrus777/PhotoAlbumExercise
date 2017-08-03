using System;

namespace PhotoAlbum
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputAlbumId = args.Length != 1 ? null : args[0];
            if (!int.TryParse(inputAlbumId, out int tempAlbumId))
            {
                inputAlbumId = null;
                Console.WriteLine("A valid album ID parameter was not entered.  Displaying all photos.\n");
                // Added this WriteLine call just to ensure you see this first message in case the command prompt cuts it off
                // after displaying all the photo IDs and Titles.
                Console.WriteLine("Press any key to continue and view all photos.\n");
                Console.ReadLine();
            }
            

            // instantiate printer class
            var photoPrinter = new PhotoPrinter(new ServiceCaller());

            // call that class' DO STUFF method
            var outputString = photoPrinter.GetAlbumOutput(inputAlbumId);

            // print output
            Console.Write(outputString);
            Console.WriteLine("\nPress any key to end the program.");
            Console.ReadLine();
        }

        
    }
}
