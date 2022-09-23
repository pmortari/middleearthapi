using System;
using System.Collections.Generic;

namespace MiddleEarthAPI.Resources.DataTransferObjects.Response
{
    public record DetailedBook
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public DateTime OriginalReleaseDate { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        public IList<BookWriter> Authors { get; set; }
    }
}