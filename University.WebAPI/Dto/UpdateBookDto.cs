﻿using University.WebAPI.Models;

namespace University.WebAPI.Dto
{
    public class UpdateBookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public StatusOfBook StatusOfBook { get; set; }
    }
}
