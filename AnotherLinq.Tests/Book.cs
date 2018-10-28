namespace AnotherLinq.Tests
{
    public class Book
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        public override bool Equals(object obj)
        {
            return Id == ((Book)obj).Id && Author == ((Book)obj).Author && Name == ((Book)obj).Author;
        }
    }
}
