using Estoque_App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque_App.Data.Configs
{
    public class MidiaConfig : IEntityTypeConfiguration<Midia>
    {
        public void Configure(EntityTypeBuilder<Midia> builder)
        {
            builder.HasKey(x => x.MidiaId);
        }
    }
}
