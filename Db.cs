namespace HotelStore.DB; 

 public record Hotel 
 {
   public int Id {get; set;} 
   public string ? Name { get; set; }
 }

 public class HotelDB
 {
   private static List<Hotel> _hotels = new List<Hotel>()
   {
     new Hotel{ Id=1, Name="Montemagno, Hotel shaped like a great mountain" },
     new Hotel{ Id=2, Name="The Galloway, Hotel shaped like a submarine"},
     new Hotel{ Id=3, Name="The Noring, Hotel shaped like a Viking helmet, where's the mead"} 
   };

   public static List<Hotel> GetHotels() 
   {
     return _hotels;
   } 

   public static Hotel ? GetHotel(int id) 
   {
     return _hotels.SingleOrDefault(hotel => hotel.Id == id);
   } 

   public static Hotel CreateHotel(Hotel hotel) 
   {
     _hotels.Add(hotel);
     return hotel;
   }

   public static Hotel UpdateHotel(Hotel update) 
   {
     _hotels = _hotels.Select(hotel =>
     {
       if (hotel.Id == update.Id)
       {
         hotel.Name = update.Name;
       }
       return hotel;
     }).ToList();
     return update;
   }

   public static void RemoveHotel(int id)
   {
     _hotels = _hotels.FindAll(hotel => hotel.Id != id).ToList();
   }
 }