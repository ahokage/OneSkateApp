using OneSkate.Dtos;
using System.Collections.Generic;

namespace OneSkate.Models
{
    public class Racer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Club Club { get; set; }
        public int? ClubId { get; set; }
        public Race Race { get; set; }
        public int? RaceId { get; set; }

    }
}