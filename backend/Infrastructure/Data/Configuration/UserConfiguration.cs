using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(
            EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);  // Указываем, что Id - это первичный ключ

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .HasMany(u => u.Topics)  // Один User может иметь много Topics
                .WithOne()   // Каждый Topic связан с одним User (не указываем навигационное свойство в Topic, так как оно в UserId)
                .HasForeignKey(t => t.UserId); // Указываем внешний ключ в Topic
        }
    }
}