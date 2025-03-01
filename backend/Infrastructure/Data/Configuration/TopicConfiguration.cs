namespace Infrastructure.Data.Configuration
{
    public class TopicConfiguration
        : IEntityTypeConfiguration<Topic>
    {
        public void Configure(
            EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(t => t.TopicId);  // Указываем, что Id - это первичный ключ

            // Мягкое удаление
            builder.HasQueryFilter(t => !t.IsDeleted); // Фильтрация по IsDeleted для всех запросов
        }
    }
}