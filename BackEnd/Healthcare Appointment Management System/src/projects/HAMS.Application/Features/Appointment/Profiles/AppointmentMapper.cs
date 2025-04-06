using System.Globalization;
using AutoMapper;
using HAMS.Application.Features.Appointment.Commands.Add;
using HAMS.Application.Features.Appointment.Commands.Update;
using HAMS.Application.Features.Appointment.Queries.GetAll;
using HAMS.Application.Features.Appointment.Queries.GetById;

namespace HAMS.Application.Features.Appointment.Profiles;

public class AppointmentMapper : Profile
{
    public AppointmentMapper()
    {
        CreateMap<AppointmentAddCommand, Domain.Models.Appointment>();
        CreateMap<AppointmentUpdateCommand, Domain.Models.Appointment>();

        CreateMap<Domain.Models.Appointment, AppointmentGetAllQueryResponseDto>()
            .ForMember(x => x.DoctorFullName,
                opt => opt.MapFrom(x => $"{x.Doctor!.FirstName} {x.Doctor.LastName}"))
            .ForMember(x => x.PatientFullName,
                opt => opt.MapFrom(x => $"{x.Patient!.FirstName} {x.Patient!.LastName}"))
            .ForMember(x => x.AppointmentDate,
                opt => opt.MapFrom(x => x.AppointmentDate.ToShortDateString()))
            .ForMember(x => x.AppointmentDay,
                opt => opt.MapFrom(x => x.AppointmentDate.Day))
            .ForMember(x => x.AppointmentMonth,
                opt => opt.MapFrom(x => x.AppointmentDate.ToString("MMMM", new CultureInfo("tr-TR"))))
            .ForMember(x => x.AppointmentYear,
                opt => opt.MapFrom(x => x.AppointmentDate.Year));

        CreateMap<Domain.Models.Appointment, AppointmentGetByIdQueryResponseDto>()
            .ForMember(x => x.DoctorFullName,
                opt => opt.MapFrom(x => $"{x.Doctor!.FirstName} {x.Doctor.LastName}"))
            .ForMember(x => x.PatientFullName,
                opt => opt.MapFrom(x => $"{x.Patient!.FirstName} {x.Patient!.LastName}"))
            .ForMember(x => x.AppointmentDate,
                opt => opt.MapFrom(x => x.AppointmentDate.ToShortDateString()))
            .ForMember(x => x.AppointmentDay,
                opt => opt.MapFrom(x => x.AppointmentDate.Day))
            .ForMember(x => x.AppointmentMonth,
                opt => opt.MapFrom(x => x.AppointmentDate.ToString("MMMM", new CultureInfo("tr-TR"))))
            .ForMember(x => x.AppointmentYear,
                opt => opt.MapFrom(x => x.AppointmentDate.Year));
    }
}