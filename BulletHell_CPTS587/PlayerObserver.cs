using CPTS587;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587
{
    public interface IObserver
    {
        void Update(Player subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    class PlayerObserver : IObserver
    {
        private HealthBar _healthbar;
       
        public void setHealthBar(HealthBar healthbar)
        {
            _healthbar = healthbar;
        }

        public void Update(Player subject)
        {
           _healthbar.updateHealthBar();
        }
    }

}
