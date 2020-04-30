using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tweetbook.Contract;
using Tweetbook.Contract.Requests;
using Tweetbook.Contract.V1.Responses;
using Tweetbook.Domain;
using Tweetbook.Services;

namespace Tweetbook.Controllers
{
    public class PostsController : Controller
    {
        //Aca estaban los post mockeados . Se reemplazo por un Singleton
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPut(APIRoutes.Post.Update)]
        public IActionResult Update([FromRoute] Guid postId,[FromBody] UpdatePostRequest request)
        {
            var response = _postService.UpdatePost(new Post { Id = postId, Name = request.Name });
            if (!response)
                return NotFound();
            return Ok() ;
        }
        [HttpDelete(APIRoutes.Post.Delete)]
        public IActionResult Delete([FromRoute] Guid postId)
        {
            var deleted = _postService.DeletePost(postId);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
        [HttpGet(APIRoutes.Post.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }
        [HttpGet(APIRoutes.Post.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = _postService.GetPostById(postId);
            if (post == null)
                return NotFound();
            return Ok(post);
        }
        [HttpPost(APIRoutes.Post.Create)]
        public IActionResult Create([FromBodyAttribute] CreatePostRequest postRequest) {
            //Esto mapea lo que viene del request con mi clase del dominio
            //No deberíamos mezclar las versiones de los Contract con los clases de dominio
            var post = new Post{ Id = postRequest.Id };
            if (post.Id != null)
                post.Id = Guid.NewGuid();
            _postService.GetPosts().Add(post);
            //tenemos que especificarle un resource located
            var baseurl = $"{HttpContext.Request.Scheme}" + HttpContext.Request.Host.ToUriComponent();
            var locationUrl = baseurl + "/"+APIRoutes.Post.Get.Replace("{postId}",post.Id.ToString());
            var postResponse = new PostResponse { Id=post.Id };
            return Created(locationUrl, postResponse);
        }
    }
}