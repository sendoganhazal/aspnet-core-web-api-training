using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure ( EntityTypeBuilder<Book> builder )
        {
            builder.HasData (
                new Book { Id = 1, Title = "Cinsiyet Belası", Price = 175 },
                new Book { Id = 2, Title = "Kadınsız İnkılap", Price = 175 },
                new Book { Id = 3, Title = "Tek Tanrılı Dinler Karşısında Kadın", Price = 175 },
                new Book { Id = 4, Title = "Toplumsal Cinsiyet ve Bilim", Price = 175 }
            );
        }
    }
}
