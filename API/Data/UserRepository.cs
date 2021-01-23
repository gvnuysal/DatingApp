using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entitites;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
     public class UserRepository : IUserRepository
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;
          public UserRepository(DataContext context, IMapper mapper)
          {
               _mapper = mapper;
               _context = context;
          }

          public async Task<MemberDto> GetMemberAsync(string username)
          {
               return await _context.Users
                                    .Where(x => x.UserName == username)
                                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                                    .Select(user => new MemberDto
                                    {
                                         Id = user.Id,
                                         UserName = user.UserName
                                    }).SingleOrDefaultAsync();
          }

          public async Task<IEnumerable<MemberDto>> GetMembersAsync()
          {
               return await _context.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();
          }

          public async Task<AppUser> GetUserByIdasync(int id)
          {
               return await _context.Users.FindAsync(id);
          }

          public async Task<AppUser> GetUserByUsernameAsync(string username)
          {
               return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
          }

          public async Task<IEnumerable<AppUser>> GetUsersAsync()
          {
               return await _context.Users
                                    .Include(p => p.Photos)
                                    .ToListAsync();
          }

          public async Task<bool> SaveAll()
          {
               return await _context.SaveChangesAsync() > 0;
          }

          public void Update(AppUser user)
          {
               _context.Entry(user).State = EntityState.Modified;

          }
     }
}