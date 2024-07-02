namespace AdoptionAgency.Backend.Domain.Model.Post
{
    public class Picture
    {
        public int Id { get; set; }
        public string Path { get; set; } = default!;
        public Picture(int id, string path)
        {
            Id = id;
            Path = path;
        }
    }
}
