// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using SpacePark.API.Models;
// using SpacePark.source.Context;
// using System;
// using System.Linq;
// using System.Threading.Tasks;

// namespace SpacePark.API.Services
// {
//     public class VisitorparkingRepository : Repository, IVisitorparkingRepository
//     {
//         public VisitorparkingRepository(SpaceParkContext context) : base(context) { }
//         // public async Task<VisitorParking[]> GetVisitorParkings()
//         // {
//         //     IQueryable<VisitorParking> query = _context.VisitorParkings.OrderBy(visitorparking => visitorparking.VistorParkingID);

//         //     return await query.ToArrayAsync();
//         // }

//         // public async void ParkShip(Visitor visitor)
//         // {
//         //     var parkings= GetVisitorParkings();
//         //     var parking = parkings.Result.Where(x=> x.Parkinglot.Status == ParkingStatus.Available).FirstOrDefault();
//         //     parking.Parkinglot.Status = ParkingStatus.Occupied;
//         //     parking.VisitorID= visitor.VisitorID;

//         //     var parkinglot= _context.ParkingLots.Where(x=> x.ParkingLotID == parking.ParkingLotID).FirstOrDefault();
//         //     //parkinglot.Status= ParkingStatus.Occupied;

//         //     var visitorparking = new VisitorParking
//         //     {
//         //         VisitorID = visitor.VisitorID,
//         //         ParkingLotID = parkinglot.ParkingLotID,
//         //         DateOfEntry = DateTime.Now
//         //     };

//         //     await _context.VisitorParkings.AddAsync(visitorparking);
//         //     await _context.SaveChangesAsync();
//         // }
//     }
// }
