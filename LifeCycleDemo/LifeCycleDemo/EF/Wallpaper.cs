using System.ComponentModel.DataAnnotations;

namespace LifeCycleDemo.EF
{
    public class Wallpaper
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public byte[] ImagesBytes { get; set; }
    }
}
