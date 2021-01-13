using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.dbHMSEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new Database.dbHMSEntities();
        }
        public string CreateHotel(Hotel model)
        {
            try
            {
                if(model != null)
                {
                    Database.Hotel entity = new Database.Hotel();

                    entity.HotelName = model.HotelName;
                    entity.Address = model.Address;
                    entity.City = model.City;
                    entity.PinCode = model.PinCode;
                    entity.ContactNumber = model.ContactNumber;
                    entity.ContactPerson = model.ContactPerson;
                    entity.CreatedBy = model.CreatedBy;
                    entity.CreatedDate = DateTime.Now;

                    _dbContext.Hotels.Add(entity);
                    _dbContext.SaveChanges();

                    return "Successfully Added";
                }
                return "Model is null";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        

        public List<Hotel> GetAllHotel()
        {
            var entities = _dbContext.Hotels.OrderBy(x=>x.HotelName).ToList();
            List<Hotel> list = new List<Hotel>();
            if(entities!=null)
            {
                foreach (var item in entities)
                {
                    Hotel hotel = new Hotel();

                    hotel.id = item.id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.PinCode = item.PinCode;
                    hotel.ContactNumber = item.ContactNumber;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.CreatedDate = item.CreatedDate;
                    hotel.UpdatedDate = item.UpdatedDate;
                    hotel.UpdatedBy = item.UpdatedBy;

                    
                    list.Add(hotel);
                }
               
            }
            return list;
        }


      

    }
}
