using BpRobotics.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BpRobotics.Core.Model.ProductDTOs;

namespace BpRobotics.Core.Extensions
{
    public static class ProductExtensions
    {
        public static Product ToProductEntity(this ProductViewDto productView)
        {
            return new Product
            {
                ID = productView.Id,
                Name = productView.Name,
                ImageFileName = productView.ImageFileName,
                ServiceInterval = productView.ServiceInterval,
                Warranty = productView.Warranty,
                ShortDescription = productView.ShortDescription,
                LongDescription = productView.LongDescription
            };
        }

        public static Product ToProductEntity(this ProductCreateDto productView)
        {
            return new Product
            {
                Name = productView.Name,
                ImageFileName = productView.ImageFileName,
                ServiceInterval = productView.ServiceInterval,
                Warranty = productView.Warranty,
                ShortDescription = productView.ShortDescription,
                LongDescription = productView.LongDescription
            };
        }

        public static ProductViewDto ToProductViewDto(this Product productEntity)
        {
            return new ProductViewDto
            {
                Id = productEntity.ID,
                Name = productEntity.Name,
                ImageFileName = productEntity.ImageFileName,
                Warranty = productEntity.Warranty,
                ServiceInterval = productEntity.ServiceInterval,
                ShortDescription = productEntity.ShortDescription,
                LongDescription = productEntity.LongDescription
            };
        }

        public static List<ProductViewDto> ToListProductViewDto(this List<Product> productEntities)
        {
            List<ProductViewDto> result = new List<ProductViewDto>();
            foreach (var productEntity in productEntities)
            {
                result.Add(ToProductViewDto(productEntity));
            }
            return result;
        }

        public static ProductCreateDto ToProductCreateDto(this Product productEntity)
        {
            return new ProductCreateDto
            {
                Name = productEntity.Name,
                ImageFileName = productEntity.ImageFileName,
                Warranty = productEntity.Warranty,
                ServiceInterval = productEntity.ServiceInterval,
                ShortDescription = productEntity.ShortDescription,
                LongDescription = productEntity.LongDescription
            };
        }
    }
}
