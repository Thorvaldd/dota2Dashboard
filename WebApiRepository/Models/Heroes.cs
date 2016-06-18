using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRepository.Models
{
    [Table("Heroes")]
    public class Heroes
    {
        [Column(name: "Id")]
        public int Id { get; set; }

        [Column(name:"Name")]
        public string Name { get; set; }

        [Column(name:"ValveHeroName")]
        public string ValveHeroName { get; set; }

        public virtual HeroesImages HeroImage { get; set; }
    }
}
