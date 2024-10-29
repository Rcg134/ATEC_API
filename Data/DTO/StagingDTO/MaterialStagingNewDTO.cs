using System.ComponentModel.DataAnnotations;

namespace ATEC_API.Data.DTO.StagingDTO
{
    public class MaterialStagingNewDTO
    {
        [Required]
        public string Sid { get; set; }
        [Required]
        public string MaterialId { get; set; }
        [Required]
        public string Serial { get; set; }
        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public int MaterialType { get; set; }
        [Required]
        public int Usercode { get; set; }
    }
}
