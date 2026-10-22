using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchStarter.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
}