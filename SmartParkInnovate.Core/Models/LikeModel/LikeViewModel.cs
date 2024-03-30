using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.LikeModel
{
    public class LikeViewModel
    {
        [Required]
        public string WorkerUsername { get; set; } = null!;
    }
}
