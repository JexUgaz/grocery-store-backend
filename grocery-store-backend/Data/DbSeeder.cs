using System;
using grocery_store_backend.Domain.Models;

namespace grocery_store_backend.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Categories.Any() || context.Products.Any()) return;

        var categories = new List<Category>
            {
                new() { Id = Guid.NewGuid(), Name = "Fruits", Image = "/categories/fruits.webp" },
                new() { Id = Guid.NewGuid(), Name = "Vegetables", Image = "/categories/vegetables.webp" },
                new() { Id = Guid.NewGuid(), Name = "Pantry Staples", Image = "/categories/pantry-staples.webp" },
                new() { Id = Guid.NewGuid(), Name = "Cleaning Products", Image = "/categories/cleaning-products.webp" }
            };

        context.Categories.AddRange(categories);
        context.SaveChanges();

        var fruitsCategoryId = categories.First(c => c.Name == "Fruits").Id;
        var perKg = "per kg";

        var fruits = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Bananas",
                PriceOriginal = 1.2m,
                Currency = "USD",
                QuantityInfo = perKg,
                Stock = 0,
                CategoryId = fruitsCategoryId,
                Images =
                [
                    new() { Id = Guid.NewGuid(), Url = "/fruits/bananas.webp", IsMain = true }
                ]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Red Apples",
                PriceOriginal = 2.5m,
                PriceOffer = 2.0m,
                Currency = "USD",
                QuantityInfo = perKg,
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/apples.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Grapes (seedless)",
                PriceOriginal = 3.2m,
                PriceOffer = 2.88m,
                Currency = "USD",
                QuantityInfo = perKg,
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/grapes.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Strawberries (local)",
                PriceOriginal = 4.0m,
                PriceOffer = 3.5m,
                Currency = "USD",
                QuantityInfo = "250 g punnet",
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/strawberries.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Oranges",
                PriceOriginal = 2.0m,
                Currency = "USD",
                QuantityInfo = perKg,
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/oranges.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pineapple",
                PriceOriginal = 3.5m,
                PriceOffer = 2.99m,
                Currency = "USD",
                QuantityInfo = "each",
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/pineapple.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mango (ripe)",
                PriceOriginal = 1.8m,
                Currency = "USD",
                QuantityInfo = "each",
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/mango.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Blueberries (organic)",
                PriceOriginal = 4.5m,
                PriceOffer = 3.99m,
                Currency = "USD",
                QuantityInfo = "125 g punnet",
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/blueberries.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Kiwi",
                PriceOriginal = 2.2m,
                Currency = "USD",
                QuantityInfo = perKg,
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/kiwi.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Avocado (Hass)",
                PriceOriginal = 2.8m,
                PriceOffer = 2.4m,
                Currency = "USD",
                QuantityInfo = "each",
                Stock = 10,
                CategoryId = fruitsCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/fruits/avocado.webp", IsMain = true }
                }
            },
        };

        context.Products.AddRange(fruits);
        context.SaveChanges();

        var pantryCategoryId = categories.First(c => c.Name == "Pantry Staples").Id;

        var pantryStaples = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Organic Rolled Oats",
                PriceOriginal = 4.5m,
                PriceOffer = 3.99m,
                Currency = "USD",
                QuantityInfo = "1 kg bag",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/organic-rolled-oats.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Rice",
                PriceOriginal = 3.8m,
                Currency = "USD",
                QuantityInfo = "1 kg bag",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/rice.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Red Lentils",
                PriceOriginal = 2.2m,
                PriceOffer = 1.99m,
                Currency = "USD",
                QuantityInfo = "500 g pack",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/red-lentils.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "All-purpose Flour",
                PriceOriginal = 2.5m,
                PriceOffer = 1.99m,
                Currency = "USD",
                QuantityInfo = "1 kg bag",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/all-purpose-flour.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pasta Fusilli",
                PriceOriginal = 1.8m,
                Currency = "USD",
                QuantityInfo = "500 g pack",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/pasta-fusilli.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tomato Sauce (jar)",
                PriceOriginal = 1.2m,
                PriceOffer = 0.99m,
                Currency = "USD",
                QuantityInfo = "400 g jar",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/tomato-sauce.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Peanut Butter",
                PriceOriginal = 3.0m,
                PriceOffer = 2.5m,
                Currency = "USD",
                QuantityInfo = "350 g jar",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/peanut-butter.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Canned Tuna (in water)",
                PriceOriginal = 1.6m,
                Currency = "USD",
                QuantityInfo = "160 g can",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/canned-tuna.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Vegetable Stock Cube",
                PriceOriginal = 0.8m,
                PriceOffer = 0.66m,
                Currency = "USD",
                QuantityInfo = "10 cubes (≈ 100 g)",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/vegetable-stock-cube.webp", IsMain = true }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Salt (iodized)",
                PriceOriginal = 0.5m,
                Currency = "USD",
                QuantityInfo = "500 g pack",
                Stock = 10,
                CategoryId = pantryCategoryId,
                Images =
                {
                    new() { Id = Guid.NewGuid(), Url = "/pantry-staples/salt-iodized.webp", IsMain = true }
                }
            },
        };

        context.Products.AddRange(pantryStaples);
        context.SaveChanges();

        var vegetablesCategoryId = categories.First(c => c.Name == "Vegetables").Id;

        var vegetables = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Carrots (bunch)",
                PriceOriginal = 1.2m,
                Currency = "USD",
                QuantityInfo = "bunch (≈ 500 g)",
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/carrots.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Broccoli",
                PriceOriginal = 1.8m,
                PriceOffer = 1.5m,
                Currency = "USD",
                QuantityInfo = "head (≈ 300 g)",
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/broccoli.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tomatoes (vine)",
                PriceOriginal = 2.5m,
                PriceOffer = 2.25m,
                Currency = "USD",
                QuantityInfo = perKg,
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/tomatoes.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Cucumber",
                PriceOriginal = 1.5m,
                Currency = "USD",
                QuantityInfo = "each",
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/cucumber.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Bell Peppers (mixed)",
                PriceOriginal = 3.0m,
                PriceOffer = 2.7m,
                Currency = "USD",
                QuantityInfo = perKg,
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/bell-peppers.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Spinach (fresh pack)",
                PriceOriginal = 2.2m,
                PriceOffer = 1.99m,
                Currency = "USD",
                QuantityInfo = "250 g pack",
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/spinach.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Cauliflower",
                PriceOriginal = 2.8m,
                Currency = "USD",
                QuantityInfo = "head",
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/cauliflower.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Zucchini",
                PriceOriginal = 2.0m,
                Currency = "USD",
                QuantityInfo = perKg,
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/zucchini.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Sweet Corn (ears)",
                PriceOriginal = 1.6m,
                Currency = "USD",
                QuantityInfo = "each ear",
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/sweet-corn.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Lettuce (romaine)",
                PriceOriginal = 1.5m,
                PriceOffer = 1.35m,
                Currency = "USD",
                QuantityInfo = "head",
                Stock = 10,
                CategoryId = vegetablesCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/vegetables/lettuce.webp", IsMain = true } }
            },
        };

        context.Products.AddRange(vegetables);
        context.SaveChanges();

        var cleaningCategoryId = categories.First(c => c.Name == "Cleaning Products").Id;

        var cleaningProducts = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "All-purpose Cleaner (spray)",
                PriceOriginal = 3.8m,
                PriceOffer = 3.3m,
                Currency = "USD",
                QuantityInfo = "500 ml bottle",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/all-purpose-cleaner.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Dishwashing Liquid",
                PriceOriginal = 2.5m,
                PriceOffer = 2.0m,
                Currency = "USD",
                QuantityInfo = "750 ml bottle",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/dishwashing-liquid.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Laundry Detergent (powder)",
                PriceOriginal = 5.0m,
                PriceOffer = 4.25m,
                Currency = "USD",
                QuantityInfo = "1 kg pack",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/laundry-detergent.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Glass Cleaner",
                PriceOriginal = 3.2m,
                Currency = "USD",
                QuantityInfo = "500 ml bottle",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/glass-cleaner.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Bleach (liquid)",
                PriceOriginal = 1.8m,
                PriceOffer = 1.5m,
                Currency = "USD",
                QuantityInfo = "1 L bottle",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/bleach.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Disinfectant Wipes (canister)",
                PriceOriginal = 4.0m,
                Currency = "USD",
                QuantityInfo = "100 wipes",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/disinfectant-wipes.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Toilet Cleaner",
                PriceOriginal = 2.8m,
                PriceOffer = 2.5m,
                Currency = "USD",
                QuantityInfo = "750 ml bottle",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/toilet-cleaner.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Fabric Softener",
                PriceOriginal = 3.6m,
                PriceOffer = 3.2m,
                Currency = "USD",
                QuantityInfo = "1 L bottle",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/fabric-softener.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Air Freshener Spray",
                PriceOriginal = 2.0m,
                Currency = "USD",
                QuantityInfo = "300 ml can",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/air-freshener-spray.webp", IsMain = true } }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Sponges (multi pack)",
                PriceOriginal = 1.5m,
                PriceOffer = 1.2m,
                Currency = "USD",
                QuantityInfo = "pack of 6",
                Stock = 10,
                CategoryId = cleaningCategoryId,
                Images = { new() { Id = Guid.NewGuid(), Url = "/cleaning-products/sponges.webp", IsMain = true } }
            },
        };

        context.Products.AddRange(cleaningProducts);
        context.SaveChanges();

    }

}
