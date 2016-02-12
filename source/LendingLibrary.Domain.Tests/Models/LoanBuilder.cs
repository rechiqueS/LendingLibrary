using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PeanutButter.RandomGenerators;


namespace LendingLibrary.Domain.Tests.Models
{
    public class LoanBuilder : GenericBuilder<LoanBuilder, Loan>
    {
        public LoanBuilder WithBorrowerName(string name)
        {
            return WithProp(l => l.BorrowerName = name);
        }

        public LoanBuilder WithItemDescription(string item)
        {
            return WithProp(l => l.ItemDescription = item);
        }

        public override LoanBuilder WithRandomProps()
        {
            // Name property is required, so we ensure that a random         
            // entity has a name (random builder could set the name to       
            //  an empty string!)                                            
            return base.WithRandomProps()
                .WithBorrowerName(RandomValueGen.GetRandomString(1, 10))
                .WithItemDescription(RandomValueGen.GetRandomString(1, 10));
        }
    }
}
