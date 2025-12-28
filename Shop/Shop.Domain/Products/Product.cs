using Common.Domain;
using Common.Domain.Exeptions;
using Common.Domain.Utilities;
using Shop.Domain.Products.Services;
using Shop.Domain.Products.ValueObjects;
using System;

namespace Shop.Domain.Products
{
    public class Product:AggregateRoot
    {
        public string Title { get; private  set; }
        public string ImageName { get; private  set; }
        public string Description { get; private  set; }
        public long CategoryId { get; private  set; }
        public long SubCategoryId { get; private  set; }
        public long SecondarySubCategoryId { get; private  set; }
        public string Slug { get; private set; }
        public SeoData SeoData  { get; private  set; }

        // Navigation Properties
        public ICollection<ProductImage> ProductImages { get; private  set; }
        public ICollection<ProductSpecification> Specifications { get; private set; }
        private Product()
        {
            
        }
        public Product(string title, string imageName, string description, long categoryId, long subCategoryId,
            long secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService productDomainService)
        {
            Guard(title, slug, imageName, description, productDomainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public void Edit(string title, string imageName, string description, long categoryId, long subCategoryId,
            long secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService productDomainService)
        {
            Guard(title, slug, imageName, description, productDomainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public void AddImage(ProductImage productImage)
        {
            productImage.ProductId = Id;
            ProductImages.Add(productImage);
        }
        public void RemoveImage(ProductImage productImage)
        {
            ProductImages.Remove(productImage);
        }
        public void RemoveImage(long Id)
        {
           var productImage=ProductImages.FirstOrDefault(x => x.Id == Id);
            if (productImage != null)
            {
                ProductImages.Remove(productImage);
            }
        }
        public void SetSpecifications(List<ProductSpecification> productSpecifications)
        {
            productSpecifications.ForEach(ps => ps.ProductId = Id);
            Specifications = productSpecifications;
        }

        private void Guard(string title,string slug, string imageName, string description,
            IProductDomainService productDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            if (slug != Slug)
            {
                if (productDomainService.IsSlugExist(slug.ToSlug()))
                    throw new SlugIsDuplicatedExeption();
            }

        }

    }

}
