﻿using CAAS.Data.Query.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAAS.EFCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CAAS.Data.Query.EFCoreQueryHandlers
{
  public class GetIsUserAnAuthorEFQH : EFQHBase, IQueryHandlerAsync<GetIsUserAnAuthorQuery, bool>
  {
    public GetIsUserAnAuthorEFQH(BlogDbContext context) : base(context)
    {
    }

    public async Task<bool> HandleAsync(GetIsUserAnAuthorQuery query)
    {
      var author = await _context.Authors.AsNoTracking().Where(a => a.ApplicationUserId == query.Id).FirstOrDefaultAsync();

      return author != null;
    }
  }
}
