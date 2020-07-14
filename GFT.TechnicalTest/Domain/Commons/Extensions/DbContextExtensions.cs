using GFT.TechnicalTest.Resources;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GFT.TechnicalTest.Domain.Extensions
{
    public static class DbContextExtensions
    {
        #region Tagging
        public static IQueryable<TModel> TagAsQuery<TModel>(this IQueryable<TModel> query, string tagName)
        {
            var tagValue = MessageManager.GetTag(tagName);
            return query.TagWith(tagValue);
        }
        #endregion
    }
}
