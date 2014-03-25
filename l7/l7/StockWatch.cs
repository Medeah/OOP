using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l7
{
    class StockWatch
    {
        private Func<decimal, decimal, bool> criteria;

        public StockWatch(Stock stock, Func<decimal, decimal, bool> value)
        {
            criteria = value;
            stock.OnValueChange += Handler;
        }

        public void Handler(object sender, Stock.StockArgs args)
        {
            if (criteria(args.PreviousValue, args.Value))
            {
                OnBigChanged(args);
            }
        }

        public event EventHandler<Stock.StockArgs> OnBigChange = delegate { };
        protected virtual void OnBigChanged(Stock.StockArgs e)
        {
            OnBigChange(this, e);
        }
    }
}
