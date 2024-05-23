using AutoMapper;
using WellnessCenterBackend.Database;
using WellnessCenterBackend.Database.Entities;
using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;

namespace WellnessCenterBackend.Services
{
    public interface IMassageService
    {
        int CreateMassage(CreateMassageDto dto);
        public List<Massage> GetAll();
        Massage GetMassage(int id);
        void RemoveMassage(int id);
        Massage UpdateMassage(UpdateMassageDto dto, int id);
    }
    public class MassageService : IMassageService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public MassageService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Massage> GetAll()
        {
            if (!_context.Massages.Any())
            {
                throw new NotFoundException("Massage not found");
            }
            return _context.Massages.ToList();
        }

        public Massage GetMassage(int id)
        {
            Massage massage = GetMassageById(id);

            return massage;
        }

        public int CreateMassage(CreateMassageDto dto)
        {
            if(dto == null)
            {
                throw new BadRequestException("Bad request");
            }
            var massage = _mapper.Map<Massage>(dto);

            _context.Massages.Add(massage);
            _context.SaveChanges();

            return massage.Id;
        }

        public void RemoveMassage(int id)
        {
            Massage massage = GetMassageById(id);

            _context.Massages.Remove(massage);
            _context.SaveChanges();
        }

        public Massage UpdateMassage(UpdateMassageDto dto, int id)
        {
            Massage massage = GetMassageById(id);

            _mapper.Map(dto, massage);

            _context.SaveChanges();
            return massage;
        }
        public Massage GetMassageById(int id)
        {
            var massage = _context.Massages.FirstOrDefault(m => m.Id == id);

            if (massage == null)
            {
                throw new BadRequestException("Not found");
            }
            return massage;
        }
    }

}
