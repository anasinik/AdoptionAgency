namespace AdoptionAgency.Backend.Domain.Model.Post
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public Comment() { }
        public Comment(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
