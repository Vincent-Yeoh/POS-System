using CommunityToolkit.Mvvm.Messaging.Messages;
using MangoMartDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangoMartDbService.Messages
{
    public class ProductBatch : ValueChangedMessage<List<Product>>
    {
        public ProductBatch(List<Product> value) : base(value)
        {
        }
    }
}
