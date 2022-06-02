//using System;
//using System.ComponentModel.DataAnnotations;

//namespace ApsideBookingRoomApp.Shared
//{
//    internal class AppointmentDto
//    {
//        public int Id { get; set; }

//        public DateTime Start { get; set; }

//        public DateTime End { get; set; }

//        public string? Title { get; set; }

//        public string? Description { get; set; }

//        public int? ManagerId { get; set; }

//        public int? RoomId { get; set; }

//        public bool IsAllDay { get; set; }

//        public string? RecurrenceRule { get; set; }

//        public int? RecurrenceId { get; set; }

//        public string? RecurrenceExceptions { get; set; }

//        public string? StartTimezone { get; set; }

//        public string? EndTimezone { get; set; }

//        public static Func<Appointment, AppointmentDto> AppointmentFunc = (appointment) =>
//            new AppointmentDto
//            {
//                Id = appointment.Id,
//                Start = appointment.Start,
//                End = appointment.End,
//                Title = appointment.Title,
//                Description = appointment.Description,
//                ManagerId = appointment.ManagerId,
//                RoomId = appointment.RoomId,
//                IsAllDay = appointment.IsAllDay,
//                RecurrenceRule = appointment.RecurrenceRule,
//                RecurrenceId = appointment.RecurrenceId,
//                RecurrenceExceptions = appointment.RecurrenceExceptions,
//                StartTimezone = appointment.StartTimezone,
//                EndTimezone = appointment.EndTimezone,
//            };
//    }
//}