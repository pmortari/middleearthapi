using System;

namespace MiddleEarthAPI.Resources.DataTransferObjects.Response
{
    public class Book
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public DateTime OriginalReleaseDate { get; set; }

        public int Pages { get; set; }
    }
}