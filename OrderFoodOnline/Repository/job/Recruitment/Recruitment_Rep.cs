using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.Ijob.IRecruitment;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.job.recruitment;

namespace OrderFoodOnline.Repository.job.Recruitment
{
    public class Recruitment_Rep :GenericRepository<Recruitment_En> ,  IRecruitment
    {
        private readonly Context_En _context;

        public Recruitment_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

    }
}
