namespace WebApiRepository.ViewModels
{
    public class HeroesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ValveName { get; set; }

        public byte[] HeroImage { get; set; }
        public string Base64Image { get; set; }

        public string CloudinaryUrl { get; set; }

    }
}