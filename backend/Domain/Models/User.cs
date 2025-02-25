namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        // Навигационное свойство, которое будет хранить список топиков этого пользователя
        public List<Topic>? Topics { get; set; }
    }
}