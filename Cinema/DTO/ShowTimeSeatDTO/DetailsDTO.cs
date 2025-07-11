namespace CinemaAPI.DTO.ShowTimeSeatDTO
{
    public class DetailsDTO
    {
        //معلومات المقعد 
        public int SeatId { get; set; }
        public string SeatName { get; set; }
        public bool IsReserved { get; set; }
        public int TheaterId { get; set; }
        //معلومات الفلم
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime ShowStart { get; set; }
        

    }
}
