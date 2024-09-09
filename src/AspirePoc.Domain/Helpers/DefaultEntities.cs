using AspirePoc.Core.Entities;

namespace AspirePoc.Core.Helpers
{
    public static class DefaultEntities
    {
        public static readonly List<Category> DefaultCategories = [new() { Id = 1, Name = "Romance" }, new() { Id = 2, Name = "Horror" }, new() { Id = 3, Name = "Adventure" }];
        public static readonly List<Book> DefaultBooks = [
            new() { Id = 1, Tittle = "It Ends with Us", AuthorName = "Colleen Hoover", CategoryId = 1, ReleaseDate = new DateTime(2016,01,01),Description = "It Ends with Us is a romance novel by Colleen Hoover, published by Atria Books on August 2, 2016. Based on the relationship between her mother and father, Hoover described it as 'the hardest book I've ever written'", Guid = new Guid("499bb563-61af-4d2a-8efe-8e3524341e82"),},
            new() { Id = 2, Tittle = "The Hunger Games", AuthorName = "Suzanne Collins", CategoryId = 3, ReleaseDate = new DateTime(2008,01,01),Description = "The Hunger Games is a 2008 dystopian young adult novel by the American writer Suzanne Collins. It is written in the perspective of 16-year-old Katniss Everdeen, who lives in the future, post-apocalyptic nation of Panem in North America", Guid = new Guid("c27eef8d-5d90-4f2f-835b-6fe0cee02857"),  },
        ];
    }
}
