using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRepository.Models
{
    [Table(name: "HeroesImages")]
    public class HeroesImages
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column("smallimage")]
        public byte[] Blob { get; set; }

     
        public int HeroId { get; set; }

        public virtual Heroes Heroes { get; set; }
    }
}
