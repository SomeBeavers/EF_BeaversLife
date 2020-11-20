using System;

namespace CoreLib_Common.Model
{
    public class AnimalClub
    {
        public int AnimalId { get; set; }
        public int ClubId { get; set; }

        public Animal Animal { get; set; }
        public Club Club { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}