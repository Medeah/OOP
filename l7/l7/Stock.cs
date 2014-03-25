using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l7
{
    public class Stock
    {
        public class StockArgs : EventArgs
        {
            public readonly decimal Value;
            public readonly decimal PreviousValue;
            public StockArgs(decimal value, decimal previousValue)
            {
                Value = value;
                PreviousValue = previousValue;
            }
        }

        //Properties
        public string Name { get; private set; }
        public decimal MaxValue { get; private set; }
        public decimal MinValue { get; private set; }
        public decimal PreviousValue { get; private set; }
        private decimal _currentValue;
        public Stock(string name)
        {
            this.Name = name;
            this.MaxValue = int.MinValue;
            this.MinValue = int.MaxValue;
        }

        public event EventHandler<StockArgs> OnValueChange = delegate { };
        protected virtual void OnValueChanged(StockArgs e)
        {
            OnValueChange(this, e);
        }

        public event EventHandler<StockArgs> OnNewHigh = delegate { };
        protected virtual void _OnNewHigh(StockArgs e)
        {
            OnNewHigh(this, e);
        }

        public event EventHandler<StockArgs> OnNewLow = delegate { };
        protected virtual void _OnNewLow(StockArgs e)
        {
            OnNewLow(this, e);
        }

        //State change that prompts event to be fired
        public decimal Value
        {
            get { return _currentValue; }
            set
            {
                if (value != _currentValue)
                {
                    PreviousValue = _currentValue;
                    _currentValue = value;
                    var args = new StockArgs(value, PreviousValue);
                    OnValueChanged(args);
                    if (value > MaxValue)
                    {
                        _OnNewHigh(args);
                        MaxValue = value;
                    }
                    if (value < MinValue)
                    {
                        _OnNewLow(args);
                        MinValue = value;
                    }
                }
            }
        }
    }
}
