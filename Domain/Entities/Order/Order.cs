﻿using Domain.Common;

namespace Domain.Entities.Order;

public class Order : BaseEntity
{
    public string OrderName { get; set; }

    #region Navigation Properties

    public User.User User { get; set; }
    public int UserId { get; set; }

    #endregion
}