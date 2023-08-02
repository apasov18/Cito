using Cito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Handlears
{
    public abstract class Handler
    {
        protected Handler nextHandler;

        public void SetNextHandler(Handler handler)

        {
            nextHandler = handler;

        }

        public virtual StyleModel LifeRequest(CellModel cell)
        {
            if (nextHandler != null)
            {
                return nextHandler.LifeRequest(cell);
            }
            return null;
            //throw new Exception("NOT FOUND DNA");
        }
    }
}
