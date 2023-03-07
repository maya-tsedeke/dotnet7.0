using System.ComponentModel.DataAnnotations;

namespace webapi.ApiModels.Order;

public record CreateOrderModel([Required(ErrorMessage = "Please Enter Your Order Name")]
    string OrderName);