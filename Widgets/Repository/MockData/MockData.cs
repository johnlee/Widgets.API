using System.Collections.Generic;

namespace Widgets.Repository.MockData
{
    public static class MockData
    {
        public static List<User> Users = new List<User>()
        {
            new User
            {
                Id = 1,
                Firstname = "Adam",
                Lastname = "Apple",
                Email = "AdamApple@widgets.com"
            },
            new User
            {
                Id = 1,
                Firstname = "Bryan",
                Lastname = "Banana",
                Email = "BrianBanana@widgets.com"
            },
            new User
            {
                Id = 1,
                Firstname = "Chris",
                Lastname = "Carrot",
                Email = "ChrisCarrot@widgets.com"
            },
            new User
            {
                Id = 1,
                Firstname = "David",
                Lastname = "Donuts",
                Email = "DavidDonuts@widgets.com"
            },
            new User
            {
                Id = 1,
                Firstname = "Eddie",
                Lastname = "Edamane",
                Email = "EddieEdamane@widgets.com"
            }
        };

        public static List<Category> Categories = new List<Category>()
        {
            new Category
            {
                Id = 1,
                Name = "Donic"
            },
            new Category
            {
                Id = 2,
                Name = "Crasfisalla"
            },
            new Category
            {
                Id = 3,
                Name = "Commodo"
            }
        };


        public static List<Widget> Widgets = new List<Widget>()
        {
            new Widget
            {
                Id = 100,
                Name = "Lorax",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Price = 18.99m,
                Category = Categories[2]
            },
            new Widget
            {
                Id = 105,
                Name = "Soccis",
                Description = "Mauris pulvinar turpis eu sollicitudin rhoncus. Nulla nec risus sit amet nisl tristique tempor. Quisque semper aliquet metus, vel tempus magna rutrum at.",
                Price = 19.99m,
                Category = Categories[2]
            },
            new Widget
            {
                Id = 110,
                Name = "Maurez",
                Description = "Cras fringilla commodo fringilla. Cras arcu dolor, laoreet eget lectus at, vehicula condimentum diam.",
                Price = 22.33m,
                Category = Categories[1]
            },
            new Widget
            {
                Id = 115,
                Name = "Proin",
                Description = "Nam a aliquet ligula, vel faucibus nulla. Nulla in gravida metus. Integer sit amet turpis elit.",
                Price = 28.99m,
                Category = Categories[0]
            },
            new Widget
            {
                Id = 120,
                Name = "Fauzer",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Price = 33.19m,
                Category = Categories[1]
            },
            new Widget
            {
                Id = 130,
                Name = "Jordanized",
                Description = "Lroin pellentesque neque ante, in elementum est tristique non. Fusce consectetur pellentesque ex eget aliquet. Nullam velit lectus, pretium ac malesuada a, gravida eget velit.",
                Price = 58.21m,
                Category = Categories[2]
            },
            new Widget
            {
                Id = 135,
                Name = "Shizraz",
                Description = "Nam metus purus, feugiat eu velit non, dapibus interdum odio. Donec semper non nisi id sagittis. Nulla facilisi. Mauris fringilla pellentesque massa tempus commodo.",
                Price = 78.99m,
                Category = Categories[0]
            },
            new Widget
            {
                Id = 140,
                Name = "Sevaneth",
                Description = "Ut accumsan velit vitae nisi aliquam, eu maximus odio pharetra. Curabitur pharetra tempor mi, et laoreet libero blandit vel. ",
                Price = 77.99m,
                Category = Categories[1]
            },
            new Widget
            {
                Id = 150,
                Name = "Shoel",
                Description = "Praesent vestibulum libero in malesuada aliquet. Maecenas justo magna, placerat aliquet viverra vitae, malesuada vitae turpis. Ut in consectetur justo.",
                Price = 99.99m,
                Category = Categories[2]
            }
        };

        public static List<Order> Orders = new List<Order>()
        {
            new Order
            {
                Id = 1,
                Buyer = Users[0],
                Widget = Widgets[0],
                Quantity = 10,
                Total = 456.32m
            },
            new Order
            {
                Id = 2,
                Buyer = Users[1],
                Widget = Widgets[1],
                Quantity = 4,
                Total = 236.92m
            },
            new Order
            {
                Id = 3,
                Buyer = Users[2],
                Widget = Widgets[2],
                Quantity = 10,
                Total = 456.32m
            },
            new Order
            {
                Id = 4,
                Buyer = Users[0],
                Widget = Widgets[3],
                Quantity = 52,
                Total = 1322.12m
            },
            new Order
            {
                Id = 5,
                Buyer = Users[3],
                Widget = Widgets[5],
                Quantity = 9,
                Total = 176.55m
            }
        };
    }
}