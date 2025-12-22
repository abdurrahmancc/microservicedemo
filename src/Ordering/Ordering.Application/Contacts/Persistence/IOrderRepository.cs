using EF.Core.Repository.Interface.Repository;
using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contacts.Persistence
{
    internal interface IOrderRepository: ICommonRepository<Order>
    {
    }
}
