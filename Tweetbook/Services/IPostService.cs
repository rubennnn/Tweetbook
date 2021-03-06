﻿using System;
using System.Collections.Generic;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();
        Post GetPostById(Guid postId);

        bool UpdatePost(Post postToUpdate);
        bool DeletePost(Guid postToDelete);

    }
}
