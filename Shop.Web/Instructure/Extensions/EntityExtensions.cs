using Shop.Model.Models;
using Shop.Web.Models;

namespace Shop.Web.Instructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryView)
        {
            postCategory.ID = postCategoryView.ID;
            postCategory.Name = postCategoryView.Name;
            postCategory.Alias = postCategoryView.Alias;
            postCategory.Description = postCategoryView.Description;
            postCategory.ParentID = postCategoryView.ParentID;
            postCategory.DisplayOrder = postCategoryView.DisplayOrder;
            postCategory.Image = postCategoryView.Image;
            postCategory.HomeFlag = postCategoryView.HomeFlag;
            postCategory.CreatedDate = postCategoryView.CreatedDate;
            postCategory.CreatedBy = postCategoryView.CreatedBy;
            postCategory.UpdatedDate = postCategoryView.UpdatedDate;
            postCategory.Name = postCategoryView.Name;
            postCategory.MetaKeyword = postCategoryView.MetaKeyword;
            postCategory.MetaDescription = postCategoryView.MetaDescription;
            postCategory.Status = postCategoryView.Status;
        }
        public static void UpdatePost(this Post post, PostViewModel postView)
        {
            post.ID = postView.ID;
            post.Name = postView.Name;
            post.Alias = postView.Alias;
            post.Description = postView.Description;
            post.CategoryID = postView.CategoryID;
            post.Description = postView.Description;
            post.Content = postView.Content;
            post.Image = postView.Image;
            post.HomeFlag = postView.HomeFlag;
            post.CreatedDate = postView.CreatedDate;
            post.CreatedBy = postView.CreatedBy;
            post.UpdatedDate = postView.UpdatedDate;
            post.Name = postView.Name;
            post.MetaKeyword = postView.MetaKeyword;
            post.MetaDescription = postView.MetaDescription;
            post.Status = postView.Status;
            post.ViewCount = postView.ViewCount;
        }
    }
}