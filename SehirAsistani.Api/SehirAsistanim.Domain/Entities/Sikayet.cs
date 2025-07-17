using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;
using SehirAsistanim.Domain.Enums;

namespace SehirAsistanim.Domain.Entities
{
    public class Sikayet
    {
        [Key]
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string Baslik { get; set; }
        public int Aciklama { get; set; }
        public int SikayetTuruId { get; set; }
        public Geometry Konum { get; set; }
        public string FotoUrl { get; set; }
        public DateTime GonderilmeTarihi { get; set; }
        public DateTime CozulmeTarihi { get; set; }
        public sikayetdurumu Durum {  get; set; }
        public int DogrulanmaSayisi { get; set; }
        public double DuyguPuani {  get; set; }
        public bool Silindimi { get; set; }
        public int CozenBirimId { get; set; }

        [NotMapped]
        public object UserData
        {
            get => Konum?.UserData;
            set
            {
                if (Konum != null)
                    Konum.UserData = value;
            }
        }
    }
}
