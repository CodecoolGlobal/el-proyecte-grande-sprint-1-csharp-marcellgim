using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.LocationDTOs
{
    public class LocationDto
    {
        private const int MinZipValue = 1000;
        private const int MaxZipValue = 9999;
        private const int MaxStringLength = 100;

        [Required]
        public int Id { get; set; }
        [Required]
        [Range(minimum: MinZipValue, maximum: MaxZipValue)]
        public int Zip { get; set; }
        [Required]
        [StringLength(maximumLength:MaxStringLength)]
        public string? Country { get; set; }
        [Required]
        [StringLength(maximumLength:MaxStringLength)]
        public string? City { get; set; }
        [Required]
        [StringLength(maximumLength:MaxStringLength)]
        public string? Address { get; set; }

        public override string ToString() => $"{Zip} {Country} {City} {Address}";
    }
}
