namespace Cars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {

        public int Id { get; set; }

        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmissionTypes TransmissionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double Price { get; set; }


        [Required]
        public int DealerId { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }


        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
