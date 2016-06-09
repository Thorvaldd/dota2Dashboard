using SQLite.Net.Attributes;

namespace WebApiRepository.Models
{
    [Table("Heroes")]
    public class Heroes
    {
        [Column(name: "id"), AutoIncrement]
        public int Id { get; set; }

        [Column(name:"name")]
        public string Name { get; set; }

        [Column(name:"valveheroname")]
        public string ValveHeroName { get; set; }

        public virtual HeroesImages HeroImage { get; set; }
    }
}
