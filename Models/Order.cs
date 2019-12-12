using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int OrderNo { get; set; }
      
        [Required]
        [Column(TypeName ="nvarchar(5)")]
        public int TotalAmount { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string PaymentMethod { get; set; }
       /* [Required]
        [Column(TypeName ="nvarchar(6)")]
        public int PaymentId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]

        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public string Exp { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(3)")]

        public string CVV { get; set; }*/


       public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int FoodItemId { get; set; }
        [ForeignKey("FoodItemId") ]
        public FoodItem FoodItem { get; set; }
        public int OrderItemId { get; set; }
        [ForeignKey("OrderItemId")]
        public FoodItem OrderItem { get; set; }

    }
}
