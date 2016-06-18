using System.ComponentModel.DataAnnotations.Schema;
namespace WebApiRepository.Models
{
    [Table(name: "HeroesImages")]
    public class HeroesImages
    {
        [Column(name: "Id")]
        public int Id { get; set; }

        [Column("cloudinaryUrl")]
        public string SmaillImageCloudinaryUrl { get; set; }
     
        [Column("HeroId")]
        public int HeroId { get; set; }

        public virtual Heroes Heroes { get; set; }
    }
}
