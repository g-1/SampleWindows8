using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Shapes;


namespace GameScene
{
    class GameObject
    {
        private Point _pos = new Point();
        public Point Pos
        {
            get
            {
                return _pos;
            }
            set
            {
                _pos = value;
            }
        }

        private Shape _model;
        public Shape Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }

        }
        
        public GameObject()
        {
        }

        public void Update()
        {
           
        }
    }
}
