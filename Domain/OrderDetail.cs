using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class OrderDetail
    {
        //thêm Id riêng cho cột chi tiết hóa đơn tránh việc 3 thuộc tính làm khóa
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public int CurrentPrice { get; set; }
        public double SelectedNumber { get; set; }
        public int Total { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual StoreDetail StoreDetails { get; set; }
    }
}