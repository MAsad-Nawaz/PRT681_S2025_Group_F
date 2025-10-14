using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class Input
    {
        public int PickupBatchNO { get; set; }
        public int UserNO { get; set; }
        public string UserID { get; set;}
        public int IDX{ get; set; }
        public string Floor { get; set; }
        public string Row { get; set; }
        public string ItemID { get; set; }
        public string WarehouseID { get; set; }
        public int LineNo { get; set; }
        public int PickingTicketNo { get; set; }
        public int BaleNo { get; set; }
        public string SKU { get; set; }
        public string PickingLocation { get; set; }
        public string LastPickedItem { get; set; }
        public string ItemType { get; set; }
        public int TotalPickupBatchQty { get; set; }
        public string CustomerID { get; set; }
        public string CustomerPO { get; set; }
        public string ShipVia { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime printedDate { get; set; }
        public string pickItemStatus { get; set; }
        public string TrackingNo { get; set; }
        public string TotalShipmentCount { get; set; }
        public string ConfirmShipmentCount { get; set; }
        public string PackingSlipNo { get; set; }
        public string LocationID { get; set; }
        public bool Redbin { get; set; }
        public int ForceFully { get; set; }
        public bool IsReceiveItemEnable { get; set; }
        public bool Greenbin { get; set; }
        public int PackingID { get; set; }

    }
}