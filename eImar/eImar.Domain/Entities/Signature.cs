namespace eImar.Domain.Entities
{
    public class Signature
    {
        public int Id { get; set; }
        public int? DocumentRef { get; set; }
        public Document? Document { get; set; }
    }
}
