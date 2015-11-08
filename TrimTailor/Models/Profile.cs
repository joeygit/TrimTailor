using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrimTailor.Models
{
    public class Profile
    {
        public Profile()
        {
        }
        //one to one relationship requires key and foreign key to be the same in the dependent class
        //"TrimUser" is the specified navigation property
        [Key]
        [ForeignKey("TrimUser")]
        public string TrimUserId { get; set; }

        public virtual TrimUser TrimUser { get; set; }
       
        public DateTime created_at { get; set; }

        [DisplayName("Last Updated At")]
        public DateTime updated_at { get; set; }
        [DisplayName("Birthday")]
        public DateTime? birthdate{ get; set; }
        [DisplayName("Waist Measurement")]
        public decimal? mes_waist { get; set; }
        [DisplayName("Midsection Measurement")]
        public decimal? mes_stomach { get; set; }
        [DisplayName("Shoulder Measurement")]
        public decimal? mes_shoulders { get; set; }
        [DisplayName("Neck Circumference")]
        public decimal? mes_neck { get; set; }
        [DisplayName("Chest Measurement")]
        public decimal? mes_chest { get; set; }
        [DisplayName("Torso Measurement")]
        public decimal? mes_torso { get; set; }
        [DisplayName("Inseam")]
        public decimal? mes_inseam { get; set; }
        [DisplayName("Right Arm length")]
        public decimal? mes_rightarm { get; set; }
        [DisplayName("Left Arm Length")]
        public decimal? mes_leftarm { get; set; }
        [DisplayName("Neck to Shoulder Length")]
        public decimal? mes_necktoshoulder { get; set; }
        [DisplayName("Height in Feet")]
        public decimal? mes_heightft { get; set; }
        [DisplayName("Height in Inches")]
        public decimal? mes_heightin { get; set; }
        [DisplayName("Weight in Pounds ")]
        public decimal? mes_weight { get; set; }
    }
}