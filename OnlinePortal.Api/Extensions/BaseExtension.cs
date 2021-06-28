using OnlineShoppingDbContext.Entities;
using OnlineShoppingDbContext.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Extensions
{
    /// <summary>
    /// The class that contains extension methods 
    /// </summary>
    public static class BaseExtension
    {
        /// <summary>
        /// Prefix of Product identifier
        /// </summary>
        private const string ProductPrefix = "PR";
       

        /// <summary>
        /// Method to Update Created Date and Time
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void SetCreatedTime(this BaseEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Method to Update Updated Date and Time
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void SetUpdatedTime(this BaseEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Method to Update Deleted Date and Time
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isRestore"></param>
        public static void SetArchivedTime(this BaseEntity entity, bool isRestore = false)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.ArchivedAt = isRestore ? null : (Nullable<DateTime>)DateTime.Now; // sets the Archived date and time according to restoration

        }

        /// <summary>
        /// Ensure the Identifier
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="identifier"></param>
        public static void EnsureId(this BaseEntity entity, int identifier)
        {
            if (string.IsNullOrEmpty(entity.Identifier))
                entity.Identifier = GetPrefix(entity) + string.Format("{0:D7}", identifier);// Pad the Identifier
        }

        /// <summary>
        /// Get Prefix
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static string GetPrefix(BaseEntity entity)
        {
            if (entity is Product)
                return ProductPrefix;
           

            return string.Empty;
        }
    }
}
