using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRepository.Models
{
    [Table(name:"GameItems")]
    public class GameItems
    {
        public int Id { get; set; }

        public int Cost { get; set; }
        [StringLength(300)]
        public string LocalizedName { get; set; }

        [StringLength(300)]
        public string DotaBuffItemName { get; set; }

        public bool IsRecipe { get; set; }

    }
}
