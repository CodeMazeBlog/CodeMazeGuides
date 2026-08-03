using MockAsynchronousMethods.Repository.DbModels;
using System;
using System.Collections.Generic;

namespace MockAsynchronousMethods.Tests.Mock
{
    public static class FakeDb
    {
        public static List<ArticleDbModel> Articles = new List<ArticleDbModel>()
        {
            new ArticleDbModel
            {
                Id = 1,
                Title = "First Article",
                LastUpdate = DateTime.Now
            },
            new ArticleDbModel
            {
                Id = 2,
                Title = "Second title",
                LastUpdate = DateTime.Now
            },
            new ArticleDbModel
            {
                Id = 3,
                Title = "Third title",
                LastUpdate = DateTime.Now
            }
        };
    }
}
