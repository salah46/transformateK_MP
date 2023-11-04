namespace transformatek_MP.Models

{
    public class Results
    {
        //this is the ID
        public string Result_Id{get;set;}
        public string Mesuretype { get; set; }
        public List<float> Values { get; set; } //convert to json??
        public string Agent_ID { get; set; }
        public string  Point_ID { get; set; }
        public DateTime Date { get; set; }







    }
}