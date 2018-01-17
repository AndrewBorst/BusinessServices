using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApi.Models
{
    public class ShipConfirm
    {
        public string ClientID { get; set; }
        public string OrderID { get; set; }
        public string TrackNum { get; set; } 
        public bool HasSent { get; set; }

    }
}
