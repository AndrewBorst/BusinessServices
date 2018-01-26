using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApi.Models
{
    public class OrderHeader
    {
        public string clientID { get; set; }
        public string orderID { get; set; }
        public string dcNum { get; set; }
        public string busAddr1 { get; set; }
        public string busAddr2 { get; set; }
        public string busCity { get; set; }
        public string busCountry { get; set; }
        public string busName { get; set; }
        public string busState { get; set; }
        public string busZip { get; set; }
        public string contTel { get; set; }
        public string deptNum { get; set; }
        public string orderType { get; set; }
        public string ordNum { get; set; }
        public string paymentType { get; set; }
        public string poNum { get; set; }
        public string reqShipDate { get; set; }
        public string reqDeliveryDate { get; set; }
        public string rsaFlag { get; set; }
        public string rushFlag { get; set; }
        public string shipAddr1 { get; set; }
        public string shipAddr2 { get; set; }
        public string shipCity { get; set; }
        public string shipCountry { get; set; }
        public string shipName { get; set; }
        public string shipState { get; set; }
        public string shipZip { get; set; }
        public string salesOrdNum { get; set; }
        public string serviceLevel { get; set; }
        public string shipToCustNum { get; set; }
        public string soldToCustNum { get; set; }
        public string storeName { get; set; }
        public string storeNum { get; set; }
        public string totalPrice { get; set; }
        public string readyForWMS { get; set; }
        public string sentToWMS { get; set; }
        public string createDate { get; set; }

    }
}
