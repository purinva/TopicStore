using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class TopicConfiguration
        : IEntityTypeConfiguration<Topic>
    {
        public void Configure(
            EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(t => t.Id);  // Указываем, что Id - это первичный ключ

            // Мягкое удаление
            builder.HasQueryFilter(t => !t.IsDeleted); // Фильтрация по IsDeleted для всех запросов
        }
    }
}