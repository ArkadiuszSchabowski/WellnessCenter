﻿using AutoMapper;
using WellnessCenterBackend.Database;
using WellnessCenterBackend.Entities;
using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;

namespace WellnessCenterBackend.Services
{
    public interface IMassageService
    {
        int CreateMassage(CreateMassageDto dto);
        public List<MassageName> GetAll();
        MassageName GetMassage(int id);
        void RemoveMassage(int id);
        MassageName UpdateMassage(UpdateMassageDto dto, int id);
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


        public List<MassageName> GetAll()
        {
            if (!_context.MassageNames.Any())
            {
                throw new NotFoundException("Massage not found");
            }
            return _context.MassageNames.ToList();
        }

        public MassageName GetMassage(int id)
        {
            MassageName massage = GetMassageById(id);

            return massage;
        }

        public int CreateMassage(CreateMassageDto dto)
        {
            if(dto == null)
            {
                throw new BadRequestException("Bad request");
            }
            var massage = _mapper.Map<MassageName>(dto);

            _context.MassageNames.Add(massage);
            _context.SaveChanges();

            return massage.Id;
        }

        public void RemoveMassage(int id)
        {
            MassageName massage = GetMassageById(id);

            _context.MassageNames.Remove(massage);
            _context.SaveChanges();
        }

        public MassageName UpdateMassage(UpdateMassageDto dto, int id)
        {
            MassageName massage = GetMassageById(id);

            _mapper.Map(dto, massage);

            _context.SaveChanges();
            return massage;
        }
        public MassageName GetMassageById(int id)
        {
            var massage = _context.MassageNames.FirstOrDefault(m => m.Id == id);

            if (massage == null)
            {
                throw new BadRequestException("Not found");
            }
            return massage;
        }
    }

}
