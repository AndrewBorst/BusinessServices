using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApi.Models
{
    public class OrderHeader
    {
        public OrderHeader(){
            OrderDetail = new List<OrderDetail>();

            this.createDate = DateTime.Now;
            this.readyForWMS = true;
            this.sentToWMS = false;
        }
        [MaxLength(50)]
        public string clientID { get; set; }
        [MaxLength(50)]
        public string orderID { get; set; }
        [MaxLength(50)]
        public string dcNum { get; set; }
        [MaxLength(50)]
        public string busAddr1 { get; set; }
        [MaxLength(50)]
        public string busAddr2 { get; set; }
        [MaxLength(50)]
        public string busCity { get; set; }
        [MaxLength(50)]
        public string busCountry { get; set; }
        [MaxLength(50)]
        public string busName { get; set; }
        [MaxLength(50)]
        public string busState { get; set; }
        [MaxLength(50)]
        public string busZip { get; set; }
        [MaxLength(50)]
        public string contTel { get; set; }
        [MaxLength(50)]
        public string deptNum { get; set; }
        [MaxLength(50)]
        public string orderType { get; set; }
        [MaxLength(50)]
        public string ordNum { get; set; }
        [MaxLength(50)]
        public string paymentType { get; set; }
        [MaxLength(50)]
        public string poNum { get; set; }
        [MaxLength(50)]
        public string reqShipDate { get; set; }
        [MaxLength(50)]
        public string reqDeliveryDate { get; set; }
        [MaxLength(50)]
        public string rsaFlag { get; set; }
        [MaxLength(50)]
        public string rushFlag { get; set; }
        [MaxLength(50)]
        public string shipAddr1 { get; set; }
        [MaxLength(50)]
        public string shipAddr2 { get; set; }
        [MaxLength(50)]
        public string shipCity { get; set; }
        [MaxLength(50)]
        public string shipCountry { get; set; }
        [MaxLength(50)]
        public string shipName { get; set; }
        [MaxLength(50)]
        public string shipState { get; set; }
        [MaxLength(50)]
        public string shipZip { get; set; }
        [MaxLength(50)]
        public string salesOrdNum { get; set; }
        [MaxLength(50)]
        public string serviceLevel { get; set; }
        [MaxLength(50)]
        public string shipToCustNum { get; set; }
        [MaxLength(50)]
        public string soldToCustNum { get; set; }
        [MaxLength(50)]
        public string storeName { get; set; }
        [MaxLength(50)]
        public string storeNum { get; set; }
        [MaxLength(50)]
        public string totalPrice { get; set; }
        public bool readyForWMS { get; }
        public bool sentToWMS { get; }
        private DateTime createDate { get; set; }
        private DateTime changeDate { get; set; }   
        public ICollection<OrderDetail> OrderDetail {get; set; }

    }
    public class OrderDetail
    {
        [MaxLength(50)]
        public string clientID { get; set; }
        [MaxLength(50)]
        public string orderID { get; set; }
        [MaxLength(50)]
        public string orderLine { get; set; }
    }
}
