using Shop.Model.Models;
using Shop.Service;
using Shop.Web.Instructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Web.API
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) :
        base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;
                 if (ModelState.IsValid)
                 {
                     request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     var list = _postCategoryService.GetAll();
                     _postCategoryService.Save();

                     response = request.CreateResponse(HttpStatusCode.OK, list);
                 }
                 return response;
             });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return createHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, category);
                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return createHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return createHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, category);
                }
                return response;
            });
        }
    }
}