using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApi.Models
{
    public class ShipConfirm
    {
        [MaxLength(50)]
        public string clientID { get; set; }
        [MaxLength(50)]
        public string orderID { get; set; }
        [MaxLength(50)]
        public string trackNum { get; set; } 
        public bool hasSent { get; set; }

    }
}
