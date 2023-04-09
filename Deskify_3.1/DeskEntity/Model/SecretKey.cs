using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeskEntity.Model
{
    [Table("secretKeys")]
    public class SecretKey
    {
        [Key]
        public int SecretId { get; set; }

        public string SecretKeyGen { get; set; }

        public string SecretKeyType { get; set;}
        public byte[] QRCode { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
