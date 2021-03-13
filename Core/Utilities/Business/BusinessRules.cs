using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business //Utilities == Araclar(Tools)
{
    public class BusinessRules
    {                                                   // logics == is kurallari
        public static IResult Run(params IResult[] logics) //params == parametreler(Isdediyin qeder IResul para metri vere bilerem)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) //* ! == basarisissza
                {
                    return logic; //kurala uymuyanlari bildirir bu
                }
            }
                return null;
        }
    }
}
