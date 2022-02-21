using FirebaseAdmin.Auth;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Data;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface IReviewerService
    {
        Task<Reviewer> AddAsync(Reviewer reviewer);
        Task<AuthenticatedReviewer> Authenticate(ReviewerAuthRequest reviewerAuthRequest);
        AuthenticatedReviewer Authenticate(string username, string paswword);
        Task<Reviewer> DeleteAsync(Guid id);
        Task<IEnumerable<Reviewer>> GetAllAsync();
        Task<Reviewer> GetByFireBaseIdAsync(string fireBaseId);
        Task<ReviewerDetail> GetByIdAsync(Guid id);
        Task<Reviewer> UpdateAsync(Reviewer reviewer);
        Task<SearchReviewerResult> SearchReviewer(int page, int pageSize, Guid? campusId, Guid? universityId);
    }

    public class ReviewerService : IReviewerService
    {
        private readonly IReviewerRepository repository;

        public ReviewerService(IReviewerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AuthenticatedReviewer> Authenticate(ReviewerAuthRequest reviewerAuthRequest)
        {
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance
                    .VerifyIdTokenAsync(reviewerAuthRequest.IdToken);
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(decodedToken.Uid);

            if (userRecord == null)
            {
                return null;
            }

            Reviewer reviewer = await repository.GetByFireBaseUIdAsync(userRecord.Uid);
            // return null if user not found
            if (reviewer == null)
            {
                reviewer = await repository.AddtAsync(reviewerAuthRequest.ToReviewer(userRecord.Uid, userRecord.Email));
            }

            // authentication successful so generate jwt token
            JwtSecurityTokenHandler tokenHandler = new();
            var key = Encoding.ASCII.GetBytes(MyConstant.Secret);
            var Expires = DateTime.UtcNow.AddDays(MyConstant.DaysExpires);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, reviewer.Id.ToString()),
                    new Claim(ClaimTypes.Role, MyConstant.Reviewer)
                }),
                Expires = Expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticatedReviewer(reviewer, tokenHandler.WriteToken(token), Expires);
        }

        public AuthenticatedReviewer Authenticate(string username, string paswword)
        {
            if ((username != "admin") || (paswword != "admin"))
            {
                return null;
            }
            Reviewer reviewer = new()
            {
                Name = "Đỗ Thành Đạt",
                Email = "dat7124@gmail.com"
            };
            JwtSecurityTokenHandler tokenHandler = new();
            var key = Encoding.ASCII.GetBytes(MyConstant.Secret);
            var Expires = DateTime.UtcNow.AddDays(MyConstant.DaysExpires);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, MyConstant.Reviewer)
                }),
                Expires = Expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticatedReviewer(reviewer, tokenHandler.WriteToken(token), Expires);
        }

        public async Task<Reviewer> AddAsync(Reviewer reviewer)
        {
            return await repository.AddtAsync(reviewer);
        }

        public async Task<ReviewerDetail> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Reviewer>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Reviewer> UpdateAsync(Reviewer reviewer)
        {
            return await repository.UpdateAsync(reviewer);
        }

        public async Task<Reviewer> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<Reviewer> GetByFireBaseIdAsync(string fireBaseId)
        {
            return await repository.GetByFireBaseUIdAsync(fireBaseId);
        }

        public async Task<SearchReviewerResult> SearchReviewer(int page, int pageSize, Guid? campusId, Guid? universityId)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? MyConstant.DefaultsPageSizeForSerch : pageSize;
            return await repository.SearchReviewer(page, pageSize, campusId, universityId);
        }
    }
}
