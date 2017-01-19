﻿using System;
using System.Linq.Expressions;

namespace CustomerPayments.Data.Repositories
{
  public static class Utilities
  {
    public static Expression<Func<T, bool>> BuildLambdaForFindByKey<T>(int id) {
      var item = Expression.Parameter(typeof(T), "entity");
      var prop = Expression.Property(item, "Id");
      var value = Expression.Constant(id);
      var equal = Expression.Equal(prop, value);
      var lambda = Expression.Lambda<Func<T, bool>>(equal, item);
      return lambda;
    }
  }
}