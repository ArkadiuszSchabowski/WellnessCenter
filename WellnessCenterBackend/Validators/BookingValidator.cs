using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;

namespace WellnessCenterBackend.Validators
{
    public static class BookingValidator
    {
        public static BookingMassageDto ValidatorDto(BookingMassageDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Wprowadzono nieprawidłowe dane");
            }

            if (dto.MassageNameId != 1 && dto.MassageNameId != 2 && dto.MassageNameId != 3)
            {
                throw new BadRequestException("Nie ma takiej usługi");
            }

            if (dto.BookingDay < 1 || dto.BookingDay > 31)
            {
                throw new BadRequestException("Podano nieprawidłowy dzień");
            }

            if (dto.BookingHour < 1 || dto.BookingHour > 24)
            {
                throw new BadRequestException("Podano nieprawidłową godzinę");
            }
            return dto;
        }
    }
}
