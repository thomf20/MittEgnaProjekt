using MittEgnaProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MittEgnaProjekt.ViewModels
{
    internal partial class BookedBoatsViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Models.Boat> boats;

        [ObservableProperty]
        Guid id;
        [ObservableProperty]
        string boatName;
        [ObservableProperty]
        DateTime bookingDate;
        [ObservableProperty]
        string customerName;

        public BookedBoatsViewModel()
        {
            bookingDate = DateTime.Today;

            Boats = new ObservableCollection<Models.Boat>();

            Boats.Add(new Models.Boat
            {
                Id = Guid.NewGuid(),
                BoatName = "Båt 2",
                BookingDate = new DateTime(2023, 3, 8),
                CustomerName = "Jussi"
            });
            Boats.Add(new Models.Boat
            {
                Id = Guid.NewGuid(),
                BoatName = "Båt 1",
                BookingDate = new DateTime(2023, 3, 9),
                CustomerName = "Jonas"
            });
        }
        [RelayCommand]
        public async void AddBooking()
        {
            if (BookingDate < DateTime.Today)
            {
                await Application.Current.MainPage.DisplayAlert("Bokning misslyckades", "Bokningen måste vara från dagens datum och framåt", "OK");
                return;
            }
            if (CustomerName == null)
            {
                await Application.Current.MainPage.DisplayAlert("Bokning misslyckades - inkorrekt inmatning", "Fyll i erat namn", "OK");
                return;
            }
            if (BoatName != "Båt 1" && BoatName != "Båt 2")
            {
                await Application.Current.MainPage.DisplayAlert("Bokning misslyckades - inkorrekt inmatning", "Välj mellan Båt 1 och Båt 2", "OK");
                return;
            }

            Boat boat = new Boat()
            {
                Id = Guid.NewGuid(),
                BoatName = BoatName,
                BookingDate = BookingDate,
                CustomerName = CustomerName
            };

            bool isBooked = Boats.Any(b => b.BoatName == BoatName && b.BookingDate.Date == BookingDate.Date);

            if (isBooked)
            {
                await Application.Current.MainPage.DisplayAlert("Bokningen misslyckades", "Fullbokat datum", "OK");
                return;
            }

            await GetDbCollection().InsertOneAsync(boat);

            Boats.Add(boat);

            await Application.Current.MainPage.DisplayAlert("Bokningen lyckades", "Din båt har blivit bokad", "OK");

        }
        [RelayCommand]
        public async void DeleteBoat(object b)
        {
            var boa = (Boat)b;
            await GetDbCollection().FindOneAndDeleteAsync(x => x.Id == boa.Id);
            Boats.Remove(boa);
        }

        public async Task GetBoats()
        {
            List<Boat> boatsFromDb = await GetDbCollection().AsQueryable().ToListAsync();
            boatsFromDb.ForEach(b => Boats.Add(b));
        }

        public IMongoCollection<Models.Boat> GetDbCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://thomadmin:System22@clusterweather.4eu9uhj.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("BookingDb");
            var myCollection = database.GetCollection<Models.Boat>("MyBoatCollectionThom");
            return myCollection;
        }
    }
}
