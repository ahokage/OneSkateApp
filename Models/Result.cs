﻿namespace OneSkate.Models
{
    public class Result
    {
        public int Id { get; set; }
        public Racer Racer { get; set; }
        public int RacerId { get; set; }
        public Race Race { get; set; }
        public int RaceId { get; set; }
        public int Rank { get; set; }
    }
}
