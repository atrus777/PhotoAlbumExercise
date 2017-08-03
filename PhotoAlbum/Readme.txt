PhotoAlbum ReadMe
---------------------------------

General Notes:

PhotoAlbum is written in C# and the code for it and its unit tests can be viewed in Visual Studio.
PhotoAlbum is built targeting the .NET Framework version 4.6.2 and operates in the command prompt as a console application.
The Newtonsoft.Json NuGet package was used for deserializing JSON responses in this application.


How to run:

1. Copy the contents of the "Release" folder from the project, at "~/PhotoAlbum/PhotoAlbum/bin/" to your preferred location on your machine.
2. To run PhotoAlbum and just print all of the photos with no filtering, either double-click the "PhotoAlbum.exe" file, or open a command prompt,
    navigate to the location where the contents of the "Release" folder were copied to, and type in "PhotoAlbum" and press enter.
3. To filter the photos by album ID, a command-line parameter must be used.  Either a shortcut must be created for the "PhotoAlbum.exe" file,
    or the command-line parameter can be entered after "PhotoAlbum" when executing the program.  (Ex.: "PhotoAlbum 7" returns the photos with an album ID of 7)

	
Testing:

Visual Studio's built-in unit test project template was used for creating and running the unit tests.
The FakeItEasy NuGet package is referenced in the tests, in order to mock a couple of classes for testability.
The tests can be run if the solution at "~/PhotoAlbum/PhotoAlbum.sln" is loaded in Visual Studio.


Design Notes:

The solution was designed to be easier to test, and thus perhaps one could argue that the GetPhotos method in the ServiceCaller class
would belong more in the PhotoPrinter class, yet this would require more work for testing for this small example.  The way to mock up
result lists of fake photos then would be to create a factory for the HttpWebResponses, so for the sake of time on this example, I avoided this.
ServiceCaller ideally should just be talking to the service, and not REALLY care so much about photos themselves.

I also avoided going more than one level deep with dependencies to have to invert, so as not to have to use an IoC container in this example.