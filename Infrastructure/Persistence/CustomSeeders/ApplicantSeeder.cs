using Bogus;
using Domain.Aggreagtes.ApplicantAggregate;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Initialization;

namespace Infrastructure.Persistence.CustomSeeders;
public class ApplicantSeeder : ICustomSeeder
{
    private readonly Context.ApplicationContext _db;
    public ApplicantSeeder(Context.ApplicationContext db)
    {
        _db = db;        
    }
    public async Task InitializeAsync()
    {
        if (_db.Applicants.Any())
        {
            var users =  _db.Users.ToList();
            var applicantFaker = new Faker<Applicant>()
                .CustomInstantiator(f => new Applicant(
                  firstName: f.Name.FirstName(),
                  lastName: f.Name.LastName(),
                  emailAddress:f.Internet.Email(),
                   userId: f.PickRandom(users).Id
                    ));
            var applicants = applicantFaker.Generate(10);
            await _db.Applicants.AddRangeAsync(applicants);
            await _db.SaveChangesAsync();
            
        }
    }
}

