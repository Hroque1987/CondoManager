using Owners.Contracts.Responses;
using SharedKernel.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Owners.Application.Queries.GetOwnerById;

public interface IGetOwnerById
{
    Task<Result<OwnerResponse>> Execute(Guid id);
}
