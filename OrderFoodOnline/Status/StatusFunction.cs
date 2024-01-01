using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;

namespace OrderFoodOnline.Status
{
    public class StatusFunction : Istatus
    {

        public Status ReturnStatus(string Massage , int statuscode)
        {
            var status = new Status() 
            {
                Massage = Massage,
                status = statuscode
            };

            return status;
        }

    }
}
