namespace OneSkate.Dtos
{
    public class RacerGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ClubDto Club { get; set; }
        public int? ClubId { get; set; }
        public RaceGetDto Race { get; set; }
        public int? RaceId { get; set;}

    }
}
