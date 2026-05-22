using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.DTOs.Sport;
using GestionZapatillas.DTOs.Size;
using GestionZapatillas.DTOs.SportShoe;
using GestionZapatillas.IoC;
using GestionZapatillas.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GestionZapatillas.Consola
{
    internal class Program
    {
        static readonly IServiceProvider _provider = DependencyInjectionContainer.Configure();

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=== Sport Shoes Management ===");
                Console.WriteLine("1. Brands");
                Console.WriteLine("2. Sports");
                Console.WriteLine("3. Sizes");
                Console.WriteLine("4. SportShoes");
                Console.WriteLine("5. Reports");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1": BrandsMenu(); break;
                    case "2": SportsMenu(); break;
                    case "3": SizesMenu(); break;
                    case "4": SportShoesMenu(); break;
                    case "5": ReportsMenu(); break;
                    case "0": return;
                }
            } while (true);
        }

       
        static void ShowErrors(IEnumerable<string> errors)
        {
            foreach (var err in errors)
                Console.WriteLine($"  - {err}");
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

      

        static void BrandsMenu()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IBrandService>();
            do
            {
                Console.Clear();
                Console.WriteLine("=== Brands Manager ===");
                Console.WriteLine("1. List Brands");
                Console.WriteLine("2. Add Brand");
                Console.WriteLine("3. Update Brand");
                Console.WriteLine("4. Delete Brand");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1": ListBrands(service); break;
                    case "2": AddBrand(service); break;
                    case "3": UpdateBrand(service); break;
                    case "4": DeleteBrand(service); break;
                    case "0": return;
                }
            } while (true);
        }

    
        static void PrintBrands(IBrandService service)
        {
            var result = service.GetAll();
            foreach (var b in result.Value!)
                Console.WriteLine($"ID:{b.BrandId,4} Name:{b.BrandName,-20} Country:{b.Country}");
        }

        static void ListBrands(IBrandService service)
        {
            Console.Clear();
            Console.WriteLine("=== Brand List ===");
            PrintBrands(service);
            Pause();
        }

        static void AddBrand(IBrandService service)
        {
            Console.Clear();
            Console.WriteLine("=== Add Brand ===");
            Console.Write("Brand Name: ");
            var name = Console.ReadLine() ?? "";
            Console.Write("Country: ");
            var country = Console.ReadLine() ?? "";

            var dto = new BrandCreateDto { BrandName = name, Country = country };
            var result = service.Add(dto);
            if (result.IsSuccess)
                Console.WriteLine("Brand added successfully!");
            else
                ShowErrors(result.Errors);
            Pause();
        }

        static void UpdateBrand(IBrandService service)
        {
            Console.Clear();
            Console.WriteLine("=== Update Brand ===");
            PrintBrands(service);
            Console.Write("\nSelect Brand ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var dtoResult = service.GetForUpdate(id);
            if (dtoResult.IsFailure)
            {
                ShowErrors(dtoResult.Errors);
                Pause();
                return;
            }
            var dto = dtoResult.Value!;

            Console.Write($"New Name ({dto.BrandName}): ");
            var name = Console.ReadLine();
            Console.Write($"New Country ({dto.Country}): ");
            var country = Console.ReadLine();

            dto.BrandName = string.IsNullOrWhiteSpace(name) ? dto.BrandName : name;
            dto.Country = string.IsNullOrWhiteSpace(country) ? dto.Country : country;

            var result = service.Update(dto);
            if (result.IsSuccess) Console.WriteLine("Brand updated successfully!");
            else ShowErrors(result.Errors);
            Pause();
        }

        static void DeleteBrand(IBrandService service)
        {
            Console.Clear();
            Console.WriteLine("=== Delete Brand ===");
            PrintBrands(service);
            Console.Write("\nSelect Brand ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var brandResult = service.GetById(id);
            if (brandResult.IsFailure)
            {
                ShowErrors(brandResult.Errors);
                Pause();
                return;
            }

            Console.Write($"Are you sure to delete '{brandResult.Value!.BrandName}' (y/n)? ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                var result = service.Delete(id);
                if (result.IsSuccess) Console.WriteLine("Brand deleted successfully!");
                else ShowErrors(result.Errors);
            }
            Pause();
        }

      

        static void SportsMenu()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISportService>();
            do
            {
                Console.Clear();
                Console.WriteLine("=== Sports Manager ===");
                Console.WriteLine("1. List Sports");
                Console.WriteLine("2. Add Sport");
                Console.WriteLine("3. Update Sport");
                Console.WriteLine("4. Delete Sport");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1": ListSports(service); break;
                    case "2": AddSport(service); break;
                    case "3": UpdateSport(service); break;
                    case "4": DeleteSport(service); break;
                    case "0": return;
                }
            } while (true);
        }

     
        static void PrintSports(ISportService service)
        {
            var result = service.GetAll();
            foreach (var s in result.Value!)
                Console.WriteLine($"ID:{s.SportId,4} Name:{s.SportName}");
        }

        static void ListSports(ISportService service)
        {
            Console.Clear();
            Console.WriteLine("=== Sport List ===");
            PrintSports(service);
            Pause();
        }

        static void AddSport(ISportService service)
        {
            Console.Clear();
            Console.WriteLine("=== Add Sport ===");
            Console.Write("Sport Name: ");
            var name = Console.ReadLine() ?? "";

            var result = service.Add(new SportCreateDto { SportName = name });
            if (result.IsSuccess) Console.WriteLine("Sport added successfully!");
            else ShowErrors(result.Errors);
            Pause();
        }

        static void UpdateSport(ISportService service)
        {
            Console.Clear();
            Console.WriteLine("=== Update Sport ===");
            PrintSports(service);
            Console.Write("\nSelect Sport ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var dtoResult = service.GetForUpdate(id);
            if (dtoResult.IsFailure)
            {
                ShowErrors(dtoResult.Errors);
                Pause();
                return;
            }
            var dto = dtoResult.Value!;

            Console.Write($"New Name ({dto.SportName}): ");
            var name = Console.ReadLine();
            dto.SportName = string.IsNullOrWhiteSpace(name) ? dto.SportName : name;

            var result = service.Update(dto);
            if (result.IsSuccess) Console.WriteLine("Sport updated successfully!");
            else ShowErrors(result.Errors);
            Pause();
        }

        static void DeleteSport(ISportService service)
        {
            Console.Clear();
            Console.WriteLine("=== Delete Sport ===");
            PrintSports(service);
            Console.Write("\nSelect Sport ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var sportResult = service.GetById(id);
            if (sportResult.IsFailure)
            {
                ShowErrors(sportResult.Errors);
                Pause();
                return;
            }

            Console.Write($"Are you sure to delete '{sportResult.Value!.SportName}' (y/n)? ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                var result = service.Delete(id);
                if (result.IsSuccess) Console.WriteLine("Sport deleted successfully!");
                else ShowErrors(result.Errors);
            }
            Pause();
        }


        static void SizesMenu()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISizeService>();
            do
            {
                Console.Clear();
                Console.WriteLine("=== Sizes Manager ===");
                Console.WriteLine("1. List Sizes");
                Console.WriteLine("2. Update Size");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1": ListSizes(service); break;
                    case "2": UpdateSize(service); break;
                    case "0": return;
                }
            } while (true);
        }

        static void PrintSizes(ISizeService service)
        {
            var result = service.GetAll();
            foreach (var s in result.Value!)
                Console.WriteLine($"ID:{s.SizeId,4} Size:{s.SizeNumber,5}");
        }

        static void ListSizes(ISizeService service)
        {
            Console.Clear();
            Console.WriteLine("=== Size List ===");
            PrintSizes(service);
            Pause();
        }

        static void UpdateSize(ISizeService service)
        {
            Console.Clear();
            Console.WriteLine("=== Update Size ===");
            PrintSizes(service);
            Console.Write("\nSelect Size ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var dtoResult = service.GetForUpdate(id);
            if (dtoResult.IsFailure)
            {
                ShowErrors(dtoResult.Errors);
                Pause();
                return;
            }
            var dto = dtoResult.Value!;

            Console.Write($"New Size Number ({dto.SizeNumber}): ");
            var input = Console.ReadLine();
            if (decimal.TryParse(input, out var num))
                dto.SizeNumber = num;

            var result = service.Update(dto);
            if (result.IsSuccess) Console.WriteLine("Size updated successfully!");
            else ShowErrors(result.Errors);
            Pause();
        }


        static void SportShoesMenu()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISportShoeService>();
            do
            {
                Console.Clear();
                Console.WriteLine("=== SportShoes Manager ===");
                Console.WriteLine("1. List SportShoes");
                Console.WriteLine("2. Add SportShoe");
                Console.WriteLine("3. Update SportShoe");
                Console.WriteLine("4. Delete SportShoe");
                Console.WriteLine("5. View Details");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1": ListSportShoes(service); break;
                    case "2": AddSportShoe(service); break;
                    case "3": UpdateSportShoe(service); break;
                    case "4": DeleteSportShoe(service); break;
                    case "5": ViewSportShoeDetails(service); break;
                    case "0": return;
                }
            } while (true);
        }

        static void PrintSportShoes(ISportShoeService service)
        {
            var result = service.GetAll();
            foreach (var s in result.Value!)
                Console.WriteLine($"ID:{s.ShoeId,4} Model:{s.Model,-30} Price:{s.Price,10:C2} Brand:{s.BrandName,-15} Sport:{s.SportName}");
        }

        static void ListSportShoes(ISportShoeService service)
        {
            Console.Clear();
            Console.WriteLine("=== SportShoe List ===");
            PrintSportShoes(service);
            Pause();
        }

        static void AddSportShoe(ISportShoeService service)
        {
            Console.Clear();
            Console.WriteLine("=== Add SportShoe ===");

            Console.Write("Model: ");
            var model = Console.ReadLine() ?? "";
            Console.Write("Description: ");
            var description = Console.ReadLine() ?? "";
            Console.Write("Price: ");
            decimal.TryParse(Console.ReadLine(), out var price);
            Console.Write("Release Date (yyyy-MM-dd): ");
            DateTime.TryParse(Console.ReadLine(), out var releaseDate);

            Console.WriteLine("\n--- Select Brand ---");
            ShowBrands();
            Console.Write("Brand ID: ");
            int.TryParse(Console.ReadLine(), out var brandId);

            Console.WriteLine("\n--- Select Sport ---");
            ShowSports();
            Console.Write("Sport ID: ");
            int.TryParse(Console.ReadLine(), out var sportId);

            Console.WriteLine("\n--- Select Genre ---");
            ShowGenres();
            Console.Write("Genre ID: ");
            int.TryParse(Console.ReadLine(), out var genreId);

            var sizes = new List<ShoeSizeDto>();
            var allSizes = GetSizes();
            Console.WriteLine("\n--- Select Sizes ---");
            Console.Write("Available sizes: ");
            Console.WriteLine(string.Join("  ", allSizes.Select(s => s.SizeNumber)));
            Console.WriteLine("(press ENTER on Size Number to finish)");
            while (true)
            {
                Console.Write("Size Number (or ENTER to finish): ");
                var sizeInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sizeInput)) break;
                if (!decimal.TryParse(sizeInput, out var sizeNumber)) { Console.WriteLine("  Invalid number."); continue; }
                var match = allSizes.FirstOrDefault(s => s.SizeNumber == sizeNumber);
                if (match == null) { Console.WriteLine("  Size not found."); continue; }
                Console.Write("Quantity in Stock: ");
                int.TryParse(Console.ReadLine(), out var qty);
                sizes.Add(new ShoeSizeDto { SizeId = match.SizeId, QuantityInStock = qty });
            }

            var dto = new SportShoeCreateDto
            {
                Model = model,
                Description = description,
                Price = price,
                ReleaseDate = releaseDate,
                BrandId = brandId,
                SportId = sportId,
                GenreId = genreId,
                Sizes = sizes
            };

            var result = service.Add(dto);
            if (result.IsSuccess) Console.WriteLine("SportShoe added successfully!");
            else ShowErrors(result.Errors);
            Pause();
        }

        static void UpdateSportShoe(ISportShoeService service)
        {
            Console.Clear();
            Console.WriteLine("=== Update SportShoe ===");
            PrintSportShoes(service);
            Console.Write("\nSelect SportShoe ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var dtoResult = service.GetForUpdate(id);
            if (dtoResult.IsFailure)
            {
                ShowErrors(dtoResult.Errors);
                Pause();
                return;
            }
            var dto = dtoResult.Value!;

            Console.Write($"New Model ({dto.Model}): ");
            var model = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(model)) dto.Model = model;

            Console.Write($"New Description ({dto.Description}): ");
            var desc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(desc)) dto.Description = desc;

            Console.Write($"New Price ({dto.Price}): ");
            var price = Console.ReadLine();
            if (decimal.TryParse(price, out var p)) dto.Price = p;

            Console.Write($"New Release Date ({dto.ReleaseDate:yyyy-MM-dd}): ");
            var date = Console.ReadLine();
            if (DateTime.TryParse(date, out var dt)) dto.ReleaseDate = dt;

            Console.WriteLine("\n--- Select New Brand (ENTER to keep) ---");
            ShowBrands();
            Console.Write($"Brand ID ({dto.BrandId}): ");
            var brand = Console.ReadLine();
            if (int.TryParse(brand, out var b)) dto.BrandId = b;

            Console.WriteLine("\n--- Select New Sport (ENTER to keep) ---");
            ShowSports();
            Console.Write($"Sport ID ({dto.SportId}): ");
            var sport = Console.ReadLine();
            if (int.TryParse(sport, out var sp)) dto.SportId = sp;

            Console.WriteLine("\n--- Select New Genre (ENTER to keep) ---");
            ShowGenres();
            Console.Write($"Genre ID ({dto.GenreId}): ");
            var genre = Console.ReadLine();
            if (int.TryParse(genre, out var g)) dto.GenreId = g;

            var allSizes = GetSizes();
            Console.WriteLine("\n--- Update Sizes ---");
            Console.Write("Available sizes: ");
            Console.WriteLine(string.Join("  ", allSizes.Select(s => s.SizeNumber)));
            Console.WriteLine("(press ENTER on Size Number to finish)");
            dto.Sizes.Clear();
            while (true)
            {
                Console.Write("Size Number (or ENTER to finish): ");
                var sizeInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sizeInput)) break;
                if (!decimal.TryParse(sizeInput, out var sizeNumber)) { Console.WriteLine("  Invalid number."); continue; }
                var match = allSizes.FirstOrDefault(s => s.SizeNumber == sizeNumber);
                if (match == null) { Console.WriteLine("  Size not found."); continue; }
                Console.Write("Quantity in Stock: ");
                int.TryParse(Console.ReadLine(), out var qty);
                dto.Sizes.Add(new ShoeSizeDto { SizeId = match.SizeId, QuantityInStock = qty });
            }

            var result = service.Update(dto);
            if (result.IsSuccess) Console.WriteLine("SportShoe updated successfully!");
            else ShowErrors(result.Errors);
            Pause();
        }

        static void DeleteSportShoe(ISportShoeService service)
        {
            Console.Clear();
            Console.WriteLine("=== Delete SportShoe ===");
            PrintSportShoes(service);
            Console.Write("\nSelect SportShoe ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var shoeResult = service.GetById(id);
            if (shoeResult.IsFailure)
            {
                ShowErrors(shoeResult.Errors);
                Pause();
                return;
            }

            Console.Write($"Are you sure to delete '{shoeResult.Value!.Model}' (y/n)? ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                var result = service.Delete(id);
                if (result.IsSuccess) Console.WriteLine("SportShoe deleted successfully!");
                else ShowErrors(result.Errors);
            }
            Pause();
        }

        static void ViewSportShoeDetails(ISportShoeService service)
        {
            Console.Clear();
            Console.WriteLine("=== SportShoe Details ===");
            PrintSportShoes(service);
            Console.Write("\nSelect SportShoe ID: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var shoeResult = service.GetById(id);
            if (shoeResult.IsFailure)
            {
                ShowErrors(shoeResult.Errors);
                Pause();
                return;
            }
            var shoe = shoeResult.Value!;

            Console.Clear();
            Console.WriteLine("=== SportShoe Details ===");
            Console.WriteLine($"ID: {shoe.ShoeId}");
            Console.WriteLine($"Model: {shoe.Model}");
            Console.WriteLine($"Description: {shoe.Description}");
            Console.WriteLine($"Price: {shoe.Price:C2}");
            Console.WriteLine($"Release Date: {shoe.ReleaseDate:yyyy-MM-dd}");
            Console.WriteLine($"Brand: {shoe.BrandName}");
            Console.WriteLine($"Sport: {shoe.SportName}");
            Console.WriteLine($"Genre: {shoe.GenreName}");
            Console.WriteLine("Sizes:");
            foreach (var sz in shoe.Sizes)
                Console.WriteLine($"  - Size {sz.SizeNumber} (Stock: {sz.QuantityInStock})");
            Pause();
        }


        static void ReportsMenu()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISportShoeService>();
            do
            {
                Console.Clear();
                Console.WriteLine("=== Reports ===");
                Console.WriteLine("1. Filter by Brand");
                Console.WriteLine("2. Filter by Sport");
                Console.WriteLine("3. Filter by Size");
                Console.WriteLine("4. Sort by Model");
                Console.WriteLine("5. Sort by Price");
                Console.WriteLine("6. Sort by Brand");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1": FilterByBrand(service); break;
                    case "2": FilterBySport(service); break;
                    case "3": FilterBySize(service); break;
                    case "4": ShowShoeList(service.GetSortedByModel().Value!, "SportShoes sorted by Model"); break;
                    case "5": ShowShoeList(service.GetSortedByPrice().Value!, "SportShoes sorted by Price"); break;
                    case "6": ShowShoeList(service.GetSortedByBrand().Value!, "SportShoes sorted by Brand"); break;
                    case "0": return;
                }
            } while (true);
        }

        static void FilterByBrand(ISportShoeService service)
        {
            Console.Clear();
            Console.WriteLine("=== Filter by Brand ===");
            ShowBrands();
            Console.Write("Select Brand ID: ");
            if (!int.TryParse(Console.ReadLine(), out var brandId)) return;
            var result = service.GetByBrand(brandId);
            ShowShoeList(result.Value!, $"SportShoes for Brand ID {brandId}");
        }

        static void FilterBySport(ISportShoeService service)
        {
            Console.Clear();
            Console.WriteLine("=== Filter by Sport ===");
            ShowSports();
            Console.Write("Select Sport ID: ");
            if (!int.TryParse(Console.ReadLine(), out var sportId)) return;
            var result = service.GetBySport(sportId);
            ShowShoeList(result.Value!, $"SportShoes for Sport ID {sportId}");
        }

        static void FilterBySize(ISportShoeService service)
        {
            Console.Clear();
            Console.WriteLine("=== Filter by Size ===");
            var allSizes = GetSizes();
            Console.Write("Available sizes: ");
            Console.WriteLine(string.Join("  ", allSizes.Select(s => s.SizeNumber)));
            Console.Write("Select Size Number: ");
            if (!decimal.TryParse(Console.ReadLine(), out var sizeNumber)) return;
            var match = allSizes.FirstOrDefault(s => s.SizeNumber == sizeNumber);
            if (match == null) { Console.WriteLine("Size not found."); Pause(); return; }
            var result = service.GetBySize(match.SizeId);
            ShowShoeList(result.Value!, $"SportShoes for Size {sizeNumber}");
        }

        static void ShowShoeList(List<SportShoeListDto> shoes, string title)
        {
            Console.Clear();
            Console.WriteLine($"=== {title} ===");
            if (shoes.Count == 0)
                Console.WriteLine("No results found.");
            foreach (var s in shoes)
                Console.WriteLine($"ID:{s.ShoeId,4} Model:{s.Model,-30} Price:{s.Price,10:C2} Brand:{s.BrandName,-15} Sport:{s.SportName}");
            Pause();
        }


        static void ShowBrands()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IBrandService>();
            var result = service.GetAll();
            foreach (var b in result.Value!)
                Console.WriteLine($"ID:{b.BrandId,4} Name:{b.BrandName}");
        }

        static void ShowSports()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISportService>();
            var result = service.GetAll();
            foreach (var s in result.Value!)
                Console.WriteLine($"ID:{s.SportId,4} Name:{s.SportName}");
        }

        static void ShowGenres()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IGenreService>();
            var result = service.GetAll();
            foreach (var g in result.Value!)
                Console.WriteLine($"ID:{g.GenreId,4} Name:{g.GenreName}");
        }

        static void ShowSizes()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISizeService>();
            var result = service.GetAll();
            foreach (var s in result.Value!)
                Console.WriteLine($"ID:{s.SizeId,4} Size:{s.SizeNumber,5}");
        }

        static List<SizeListDto> GetSizes()
        {
            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISizeService>();
            return service.GetAll().Value!;
        }
    }
}
